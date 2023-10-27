using System;
using System.Collections.Generic;

namespace BattleSimulator.Battle
{
	public class Random
	{
		public Random(int seed)
		{
			Seed = seed;
		}

		public int Seed { get; private set; }

		public int Next(int min = 0, int max = 32767)
		{
			if (min >= max - 1)
			{
				return max - 1;
			}
			Seed = 8253729 * Seed + 2396403;
			uint num = (uint)Seed >> 16;
			int num2 = (int)num;
			num2 %= Math.Min(32767, max - min);
			return num2 + min;
		}

		public void Shuffle<T>(List<T> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int num = Next(0, list.Count);
                (list[num], list[i]) = (list[i], list[num]);
            }
        }

		public const int Max = 32767;
	}
}
