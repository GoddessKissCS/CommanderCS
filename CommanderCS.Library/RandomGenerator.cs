namespace CommanderCS.Library
{
    public static class RandomGenerator
    {
        private static int SeedCache = (int)TimeManager.CurrentEpoch;
        private static Random SharedPrivate = new(SeedCache);

        public static Random Shared
        {
            get
            {
                var now = TimeManager.CurrentEpoch;
                if (now != SeedCache)
                {
                    SeedCache = (int)now;
                    SharedPrivate = new Random(SeedCache);
                }
                return SharedPrivate;
            }
        }

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