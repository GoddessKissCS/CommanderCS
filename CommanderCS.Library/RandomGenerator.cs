namespace CommanderCS.Library
{
    public static class RandomGenerator
    {
        public static Random Shared => Random.Shared;

        public static List<int> BankRoulletLuck(int spins)
        {
            List<int> luck = [];

            for (int i = 0; i < spins; i++)
            {
                luck.Add(Shared.Next(1, 10));
            };

            return luck;
        }
    }
}
