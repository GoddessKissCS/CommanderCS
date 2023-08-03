using System.Text.Json.Serialization;


namespace StellarGK.Logic.Protocols
{

    public class CarnivalList
    {
        [JsonPropertyName("list")]
        public Dictionary<string, CarnivaTime> carnivalList { get; set; }

        [JsonPropertyName("ctnt")]
        public Dictionary<string, Dictionary<string, ProcessData>> carnivalProcessList { get; set; }

        [JsonPropertyName("reward")]
        public List<RewardInfo.RewardData> rewardList { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("comm")]
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }

        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("clst")]
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }

        [JsonPropertyName("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItemData { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonPropertyName("ctm")]
        public int connectTime { get; set; }


        public class CarnivaTime
        {
            [JsonPropertyName("rtm")]
            public string remain
            {
                set
                {
                    double byDuration = 0.0;
                    if (!string.IsNullOrEmpty(value))
                    {
                        byDuration = double.Parse(value);
                    }
                    if (remainTimeData == null)
                    {
                        remainTimeData = new TimeData();
                    }
                    remainTimeData.SetByDuration(byDuration);
                }
            }

            public TimeData remainTimeData;
        }


        public class ProcessData
        {
            [JsonPropertyName("cnt")]
            public int count { get; set; }

            [JsonPropertyName("comp")]
            public int complete { get; set; }

            [JsonPropertyName("recv")]
            public int receive { get; set; }

            [JsonPropertyName("able")]
            public int able { get; set; }

            [JsonPropertyName("lup")]
            public string lup { get; set; }

            [JsonPropertyName("nstm")]
            public string startTime
            {
                set
                {
                    double byDuration = 0.0;
                    if (!string.IsNullOrEmpty(value))
                    {
                        byDuration = double.Parse(value);
                    }
                    if (startTimeData == null)
                    {
                        startTimeData = new TimeData();
                    }
                    startTimeData.SetByDuration(byDuration);
                }
            }

            [JsonPropertyName("netm")]
            public string endTime
            {
                set
                {
                    double byDuration = 0.0;
                    if (!string.IsNullOrEmpty(value))
                    {
                        byDuration = double.Parse(value);
                    }
                    if (endTimeData == null)
                    {
                        endTimeData = new TimeData();
                    }
                    endTimeData.SetByDuration(byDuration);
                }
            }

            [JsonPropertyName("rtm")]
            public string remain
            {
                set
                {
                    double byDuration = 0.0;
                    if (!string.IsNullOrEmpty(value))
                    {
                        byDuration = double.Parse(value);
                    }
                    if (remainTimeData == null)
                    {
                        remainTimeData = new TimeData();
                    }
                    remainTimeData.SetByDuration(byDuration);
                }
            }

            public TimeData startTimeData;

            public TimeData endTimeData;

            public TimeData remainTimeData;
        }
    }
}
