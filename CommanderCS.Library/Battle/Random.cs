namespace CommanderCS.Library.Battle
{
    public class Random
    {
        public const int Max = 32767;

        public int seed { get; private set; }

        public Random(int seed)
        {
            this.seed = seed;
        }

        public int Next(int min = 0, int max = 32767)
        {
            if (min >= max - 1)
            {
                return max - 1;
            }
            seed = 8253729 * seed + 2396403;
            uint num = (uint)seed >> 16;
            int num2 = (int)num;
            num2 %= Math.Min(32767, max - min);
            return num2 + min;
        }

        public void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int index = Next(0, list.Count);
                T value = list[i];
                list[i] = list[index];
                list[index] = value;
            }
        }
    }
}