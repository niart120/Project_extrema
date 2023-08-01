﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace PokemonPRNG.XorShift128
{
    public static class XorShift128Ext
    {
        public static uint GetRand(ref this (uint s0, uint s1, uint s2, uint s3) state)
        {
            var t1 = state.s0 ^ (state.s0 << 11);
            var t2 = state.s3 ^ (state.s3 >> 19) ^ t1 ^ (t1 >> 8);

            state = (state.s1, state.s2, state.s3, t2);

            return (t2 % 0xFFFFFFFF) + 0x80000000;
        }
        public static uint GetRand(ref this (uint s0, uint s1, uint s2, uint s3) state, uint n)
        {
            var t1 = state.s0 ^ (state.s0 << 11);
            var t2 = state.s3 ^ (state.s3 >> 19) ^ t1 ^ (t1 >> 8);

            state = (state.s1, state.s2, state.s3, t2);

            return ((t2 % 0xFFFFFFFF) + 0x80000000) % n;
        }

        public static float GetRand_f(ref this (uint s0, uint s1, uint s2, uint s3) state)
        {
            var t1 = state.s0 ^ (state.s0 << 11);
            var t2 = state.s3 ^ (state.s3 >> 19) ^ t1 ^ (t1 >> 8);

            state = (state.s1, state.s2, state.s3, t2);

            return (t2 & 0x7F_FFFF) / 8388607.0f;
        }
        public static float GetRand_f(ref this (uint s0, uint s1, uint s2, uint s3) state, float min, float max)
        {
            var t1 = state.s0 ^ (state.s0 << 11);
            var t2 = state.s3 ^ (state.s3 >> 19) ^ t1 ^ (t1 >> 8);

            state = (state.s1, state.s2, state.s3, t2);

            var r = (t2 & 0x7F_FFFF) / 8388607.0f;

            return r * min + (1 - r) * max;
        }

        public static (uint s0, uint s1, uint s2, uint s3) Next(this (uint s0, uint s1, uint s2, uint s3) state)
        {
            var t1 = state.s0 ^ (state.s0 << 11);
            var t2 = state.s3 ^ (state.s3 >> 19) ^ t1 ^ (t1 >> 8);

            return (state.s1, state.s2, state.s3, t2);
        }
        public static (uint s0, uint s1, uint s2, uint s3) Next(this (uint s0, uint s1, uint s2, uint s3) state, uint n)
        {
            for (int i = 0; i < n; i++)
                state.Advance();

            return state;
        }
        public static (uint s0, uint s1, uint s2, uint s3) Advance(ref this (uint s0, uint s1, uint s2, uint s3) state)
        {
            var t1 = state.s0 ^ (state.s0 << 11);
            var t2 = state.s3 ^ (state.s3 >> 19) ^ t1 ^ (t1 >> 8);

            return state = (state.s1, state.s2, state.s3, t2);
        }
        public static (uint s0, uint s1, uint s2, uint s3) Advance(ref this (uint s0, uint s1, uint s2, uint s3) state, uint n)
        {
            for (int i = 0; i < n; i++)
                state.Advance();

            return state;
        }

        public static (uint s0, uint s1, uint s2, uint s3) Prev(this (uint s0, uint s1, uint s2, uint s3) state)
        {
            var t = state.s3 ^ state.s2 ^ (state.s2 >> 19);
            t = t ^ (t >> 8) ^ (t >> 16) ^ (t >> 24);
            t = t ^ (t << 11) ^ (t << 22);

            return (t, state.s0, state.s1, state.s2);
        }
        public static (uint s0, uint s1, uint s2, uint s3) Prev(this (uint s0, uint s1, uint s2, uint s3) state, uint n)
        {
            for (int i = 0; i < n; i++)
                state.Back();

            return state;
        }
        public static (uint s0, uint s1, uint s2, uint s3) Back(ref this (uint s0, uint s1, uint s2, uint s3) state)
        {
            var t = state.s3 ^ state.s2 ^ (state.s2 >> 19);
            t = t ^ (t >> 8) ^ (t >> 16) ^ (t >> 24);
            t = t ^ (t << 11) ^ (t << 22);

            return state = (t, state.s0, state.s1, state.s2);
        }
        public static (uint s0, uint s1, uint s2, uint s3) Back(ref this (uint s0, uint s1, uint s2, uint s3) state, uint n)
        {
            for (int i = 0; i < n; i++)
                state.Back();

            return state;
        }

        public static string ToU128String(this (uint s0, uint s1, uint s2, uint s3) state) => $"{state.s0:X8}{state.s1:X8}{state.s2:X8}{state.s3:X8}";
        public static (uint s0, uint s1, uint s2, uint s3) FromU128String(this string hex)
        {
            if (hex.Length > 32 || hex.Length == 0) throw new ArgumentException("bad argument");

            hex = hex.PadLeft(32, '0');

            var t0 = hex.Substring(0, 8);
            var t1 = hex.Substring(8, 8);
            var t2 = hex.Substring(16, 8);
            var t3 = hex.Substring(24, 8);

            var s0 = Convert.ToUInt32(t0, 16);
            var s1 = Convert.ToUInt32(t1, 16);
            var s2 = Convert.ToUInt32(t2, 16);
            var s3 = Convert.ToUInt32(t3, 16);

            return (s0, s1, s2, s3);
        }
    }

    public interface IGeneratable<out TResult>
    {
        TResult Generate((uint s0, uint s1, uint s2, uint s3) seed);
    }
    public interface IGeneratable<out TResult, in TArg1>
    {
        TResult Generate((uint s0, uint s1, uint s2, uint s3) seed, TArg1 arg1);
    }

    public static class CommonEnumerator
    {
        public static IEnumerable<(int index, T element)> WithIndex<T>(this IEnumerable<T> enumerator)
            => enumerator.Select((_, i) => (i, _));

        public static IEnumerable<(uint s0, uint s1, uint s2, uint s3)> EnumerateSeed(this (uint s0, uint s1, uint s2, uint s3) seed)
        {
            yield return seed;
            while (true) yield return seed.Advance();
        }

        public static IEnumerable<TResult> EnumerateGeneration<TResult>
            (this IEnumerable<(uint s0, uint s1, uint s2, uint s3)> seedEnumerator, IGeneratable<TResult> igenerator)
            => seedEnumerator.Select(igenerator.Generate);

        public static IEnumerable<TResult> EnumerateGeneration<TResult, TArg1>
            (this IEnumerable<(uint s0, uint s1, uint s2, uint s3)> seedEnumerator, IGeneratable<TResult, TArg1> igenerator, TArg1 arg1)
            => seedEnumerator.Select(_ => igenerator.Generate(_, arg1));
    }
}
