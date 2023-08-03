using PokemonPRNG.XorShift128;
using PokemonPRNG.Xoroshiro128p;
using PokemonStandardLibrary.Gen8;
using PokemonStandardLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonBDSPRNGLibrary.Generators
{
    public class RoamerGenerator
        : PokemonPRNG.XorShift128.IGeneratable<Pokemon.Individual>, PokemonPRNG.XorShift128.IGeneratable<Pokemon.Individual, Synchronize>
    {
        private readonly bool _neverShiny;
        private readonly uint _flawlessIVs;
        private readonly Pokemon.Species _species;
        private readonly uint _lv;

        private readonly uint _tsv;

        public Pokemon.Individual Generate((uint s0, uint s1, uint s2, uint s3) seed)
        {
            var ec = seed.GetRand();
            var rng = ((ulong)ec).Initialize();

            var tempTSV = rng.GetRandBDSP(0xFFFFFFFF).ToShinyValue();
            var pid = rng.GetRandBDSP(0xFFFFFFFF);
            var psv = pid.ToShinyValue();

            var shinyType = _neverShiny ? ShinyType.NotShiny : psv.ToShinyType(tempTSV);
            if (shinyType == 0 && pid.ToShinyType(_tsv) != 0)
                pid ^= 0x10000000; // Antishiny
            else if (shinyType != 0 && pid.ToShinyType(_tsv) == 0)
                pid = (_tsv ^ pid) << 16 | pid & 0xFFFF;

            var ivs = rng.GenerateIVs(_flawlessIVs);

            var ability = (uint)rng.GetRandBDSP(2);
            var gender = rng.GenerateGender(_species.GenderRatio);
            var nature = (Nature)rng.GetRandBDSP(25);

            var height = (byte)(rng.GetRandBDSP(129) + rng.GetRandBDSP(128));
            var weight = (byte)(rng.GetRandBDSP(129) + rng.GetRandBDSP(128));

            return _species.GetIndividual(_lv, ivs, ec, pid, nature, ability, gender, height, weight).SetShinyType(shinyType);
        }

        public Pokemon.Individual Generate((uint s0, uint s1, uint s2, uint s3) seed, Synchronize synchronize)
        {
            var ec = seed.GetRand();
            var rng = ((ulong)ec).Initialize();

            var tempTSV = rng.GetRandBDSP(0xFFFFFFFF).ToShinyValue();
            var pid = rng.GetRandBDSP(0xFFFFFFFF);
            var psv = pid.ToShinyValue();

            var shinyType = _neverShiny ? ShinyType.NotShiny : psv.ToShinyType(tempTSV);
            if (shinyType == 0 && pid.ToShinyType(_tsv) != 0)
                pid ^= 0x10000000; // Antishiny
            else if (shinyType != 0 && pid.ToShinyType(_tsv) == 0)
                pid = (_tsv ^ pid) << 16 | pid & 0xFFFF;

            var ivs = rng.GenerateIVs(_flawlessIVs);

            var ability = rng.GetRandBDSP(2);
            var gender = rng.GenerateGender(_species.GenderRatio);
            var nature = (uint)synchronize.FixedNature < 25 ? synchronize.FixedNature : (Nature)rng.GetRandBDSP(25);

            var height = (byte)(rng.GetRandBDSP(129) + rng.GetRandBDSP(128));
            var weight = (byte)(rng.GetRandBDSP(129) + rng.GetRandBDSP(128));

            return _species.GetIndividual(_lv, ivs, ec, pid, nature, ability, gender, height, weight).SetShinyType(shinyType);
        }

        public RoamerGenerator(string name, uint lv, uint tsv, uint flawlessIVs = 3, bool neverShiny = false)
            => (_species, _lv, _flawlessIVs, _neverShiny, _tsv) = (Pokemon.GetPokemon(name), lv, flawlessIVs, neverShiny, tsv);
    }

    static class RoamerGenerationExt
    {
        public static uint ToShinyValue(this ulong val)
            => (uint)(val & 0xFFFF) ^ (uint)(val >> 16);

        public static uint[] GenerateIVs(ref this (ulong S0, ulong S1) seed, uint flawlessIVs)
        {
            var ivs = Enumerable.Repeat(32u, 6).ToArray();
            for (int i = 0; i < flawlessIVs; i++)
            {
                while (true)
                {
                    var idx = seed.GetRandBDSP(6);
                    if (ivs[idx] == 32)
                    {
                        ivs[idx] = 31;
                        break;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
                if (ivs[i] == 32) ivs[i] = (uint)seed.GetRandBDSP(32);

            return ivs;
        }

        public static Gender GenerateGender(ref this (ulong S0, ulong S1) seed, GenderRatio ratio)
            => ratio.ToFixedGender() ?? ((seed.GetRandBDSP(253) + 1) < (uint)ratio ? Gender.Female : Gender.Male);

    }

}
