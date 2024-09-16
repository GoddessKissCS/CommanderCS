namespace CommanderCSLibrary.Shared
{
    public static class Constants
    {
        public static Dictionary<int, int> GradeCostList { get; set; } = new Dictionary<int, int>()
        {
            { 1, 10 },
            { 2, 30 },
            { 3, 80 }
        };

        public static Dictionary<int, int> RankCostList { get; set; } = new Dictionary<int, int>()
        {
            { 1, 20 },
            { 2, 50 },
            { 3, 100 },
            { 4, 150 },
            { 5, 250 }
        };

        public static Dictionary<int, int> AffectionList = new()
        {
            { 50, 10 },
            { 51, 30 },
            { 52, 50 },
            { 53, 150 },
            { 54, 300 },
            { 55, 500 },
            { 59, 1000 },
            { 60, 2000 },
            { 61, 3000 },
            { 62, 4000 },
            { 63, 6000 },
            { 64, 9000 }
        };

    }

}