using Newtonsoft.Json;


namespace StellarGKLibrary.Protocols
{

    public class CarnivalList
    {
        [JsonProperty("list")]
        public Dictionary<string, CarnivaTime> carnivalList { get; set; }

        [JsonProperty("ctnt")]
        public Dictionary<string, Dictionary<string, ProcessData>> carnivalProcessList { get; set; }

        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> rewardList { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }

        [JsonProperty("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonProperty("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItemData { get; set; }

        [JsonProperty("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonProperty("ctm")]
        public int connectTime { get; set; }
        public class CarnivaTime
        {
            [JsonProperty("rtm")]
            public string remain { get; set; }
        }
        public class ProcessData
        {
            [JsonProperty("cnt")]
            public int count { get; set; }

            [JsonProperty("comp")]
            public int complete { get; set; }

            [JsonProperty("recv")]
            public int receive { get; set; }

            [JsonProperty("able")]
            public int able { get; set; }

            [JsonProperty("lup")]
            public string lup { get; set; }

            [JsonProperty("nstm")]
            public string startTime { get; set; }

            [JsonProperty("netm")]
            public string endTime { get; set; }

            [JsonProperty("rtm")]
            public string remain { get; set; }

        }
    }
}
