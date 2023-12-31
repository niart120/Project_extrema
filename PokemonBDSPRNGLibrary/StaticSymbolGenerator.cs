﻿using PokemonPRNG.XorShift128;
using PokemonStandardLibrary.Gen8;
using PokemonStandardLibrary;

namespace PokemonBDSPRNGLibrary.Generators
{
    public class StaticSymbolGenerator 
        : IGeneratable<Pokemon.Individual>, IGeneratable<Pokemon.Individual, Synchronize>, IGeneratable<Pokemon.Individual, CuteCharm>
    {
        private readonly bool _neverShiny;
        private readonly uint _fixedAbility;
        private readonly uint _flawlessIVs;
        private readonly Pokemon.Species _species;
        private readonly uint _lv;

        private readonly uint _tsv;

        public Pokemon.Individual Generate((uint s0, uint s1, uint s2, uint s3) seed)
        {
            var ec = seed.GetRand();
            var tempTSV = seed.GetRand().ToShinyValue();
            var pid = seed.GetRand();
            var psv = pid.ToShinyValue();

            var shinyType = _neverShiny ? ShinyType.NotShiny : psv.ToShinyType(tempTSV);
            if (shinyType == 0 && pid.ToShinyType(_tsv) != 0)
                pid ^= 0x10000000; // Antishiny
            else if (shinyType != 0 && pid.ToShinyType(_tsv) == 0)
                pid = (_tsv ^ pid) << 16 | pid & 0xFFFF;

            var ivs = seed.GenerateIVs(_flawlessIVs);

            var ability = _fixedAbility;
            //特性固定無しの場合
            if (_fixedAbility == 3)
            {
                ability = seed.GetRand(2);
            }
            //夢特性固定の場合
            else if (_fixedAbility == 2)
            {
                seed.GetRand(2);//カラ消費
                ability = _fixedAbility;
            }
            //その他 -> _fixedAbility

            var gender = seed.GenerateGender(_species.GenderRatio);
            var nature = (Nature)seed.GetRand(25);

            var height = (byte)(seed.GetRand(129) + seed.GetRand(128));
            var weight = (byte)(seed.GetRand(129) + seed.GetRand(128));

            return _species.GetIndividual(_lv, ivs, ec, pid, nature, ability, gender, height, weight).SetShinyType(shinyType);
        }

        public Pokemon.Individual Generate((uint s0, uint s1, uint s2, uint s3) seed, Synchronize synchronize)
        {
            var ec = seed.GetRand();
            var tempTSV = seed.GetRand().ToShinyValue();
            var pid = seed.GetRand();
            var psv = pid.ToShinyValue();

            var shinyType = _neverShiny ? ShinyType.NotShiny : psv.ToShinyType(tempTSV);
            if (shinyType == 0 && pid.ToShinyType(_tsv) != 0)
                pid ^= 0x10000000; // Antishiny
            else if (shinyType != 0 && pid.ToShinyType(_tsv) == 0)
                pid = (_tsv ^ pid) << 16 | pid & 0xFFFF;

            var ivs = seed.GenerateIVs(_flawlessIVs);

            var ability = _fixedAbility;
            //特性固定無しの場合
            if (_fixedAbility == 3)
            {
                ability = seed.GetRand(2);
            }
            //夢特性固定の場合
            else if (_fixedAbility == 2)
            {
                seed.GetRand(2);//カラ消費
                ability = _fixedAbility;
            }
            //その他 -> _fixedAbility

            var gender = seed.GenerateGender(_species.GenderRatio);
            var nature = (uint)synchronize.FixedNature < 25 ? synchronize.FixedNature : (Nature)seed.GetRand(25);

            var height = (byte)(seed.GetRand(129) + seed.GetRand(128));
            var weight = (byte)(seed.GetRand(129) + seed.GetRand(128));

            return _species.GetIndividual(_lv, ivs, ec, pid, nature, ability, gender, height, weight).SetShinyType(shinyType);
        }

        public Pokemon.Individual Generate((uint s0, uint s1, uint s2, uint s3) seed, CuteCharm cuteCharm)
        {
            var ec = seed.GetRand();
            var tempTSV = seed.GetRand().ToShinyValue();
            var pid = seed.GetRand();
            var psv = pid.ToShinyValue();

            var shinyType = _neverShiny ? ShinyType.NotShiny : psv.ToShinyType(tempTSV);
            if (shinyType == 0 && pid.ToShinyType(_tsv) != 0)
                pid ^= 0x10000000; // Antishiny
            else if (shinyType != 0 && pid.ToShinyType(_tsv) == 0)
                pid = (_tsv ^ pid) << 16 | pid & 0xFFFF;

            var ivs = seed.GenerateIVs(_flawlessIVs);

            var ability = _fixedAbility;
            //特性固定無しの場合
            if (_fixedAbility == 3)
            {
                ability = seed.GetRand(2);
            }
            //夢特性固定の場合
            else if (_fixedAbility == 2)
            {
                seed.GetRand(2);//カラ消費
                ability = _fixedAbility;
            }
            //その他 -> _fixedAbility

            var gender = seed.GenerateGender(_species.GenderRatio, cuteCharm.FixedGender);
            var nature = (Nature)seed.GetRand(25);

            var height = (byte)(seed.GetRand(129) + seed.GetRand(128));
            var weight = (byte)(seed.GetRand(129) + seed.GetRand(128));

            return _species.GetIndividual(_lv, ivs, ec, pid, nature, ability, gender, height, weight).SetShinyType(shinyType);
        }

        public StaticSymbolGenerator(string name, uint lv, uint tsv, uint flawlessIVs = 0, uint fixedAbility = 3, bool neverShiny = false)
            => (_species, _lv, _flawlessIVs, _fixedAbility, _neverShiny, _tsv) = (Pokemon.GetPokemon(name), lv, flawlessIVs, fixedAbility, neverShiny, tsv);
    }

    public readonly struct Synchronize
    {
        public Nature FixedNature { get; }
        public Synchronize(Nature nature)
            => FixedNature = nature;
    }

    public readonly struct CuteCharm
    {
        public Gender FixedGender { get; }
        public CuteCharm(Gender gender)
            => FixedGender = gender;
    }

    public class StaticSymbolCriteria
    {
        private Nature? nature;
        private uint[] stats;

        public bool Fulfills(Pokemon.Individual individual)
        {
            if (stats != null && !individual.Stats.SequenceEqual(stats)) return false;
            if (nature.HasValue && individual.Nature != nature.Value) return false;

            return true;
        }

        public StaticSymbolCriteria SetNature(Nature nature)
        {
            this.nature = nature;
            return this;
        }
        public StaticSymbolCriteria SetStats(uint[] stats)
        {
            this.stats = stats;
            return this;
        }
    }

    static class GenerationExt
    {
        public static uint ToShinyValue(this uint val)
            => (val & 0xFFFF) ^ (val >> 16);

        public static ShinyType ToShinyType(this uint psv, uint tsv)
        {
            var sv = psv ^ tsv;
            if (sv >= 16) return ShinyType.NotShiny;

            return sv == 0 ? ShinyType.Square : ShinyType.Star;
        }

        public static uint[] GenerateIVs(ref this (uint S0, uint S1, uint S2, uint S3) seed, uint flawlessIVs)
        {
            var ivs = Enumerable.Repeat(32u, 6).ToArray();
            for (int i = 0; i < flawlessIVs; i++)
            {
                while (true)
                {
                    var idx = seed.GetRand(6);
                    if (ivs[idx] == 32)
                    {
                        ivs[idx] = 31;
                        break;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
                if (ivs[i] == 32) ivs[i] = seed.GetRand(32);

            return ivs;
        }

        public static Gender? ToFixedGender(this GenderRatio ratio)
        {
            switch (ratio)
            {
                case GenderRatio.Genderless: return Gender.Genderless;
                case GenderRatio.FemaleOnly: return Gender.Female;
                case GenderRatio.MaleOnly: return Gender.Male;
                default: return null;
            }
        }

        public static Gender GenerateGender(ref this (uint S0, uint S1, uint S2, uint S3) seed, GenderRatio ratio)
            => ratio.ToFixedGender() ?? ((seed.GetRand(253) + 1) < (uint)ratio ? Gender.Female : Gender.Male);

        public static Gender GenerateGender(ref this (uint S0, uint S1, uint S2, uint S3) seed, GenderRatio ratio, Gender cuteCharmGender)
            => ratio.ToFixedGender() ??
                ((cuteCharmGender != Gender.Genderless && seed.GetRand(3) != 0) ? cuteCharmGender :
                ((seed.GetRand(253) + 1) < (uint)ratio ? Gender.Female : Gender.Male));
    }
}
