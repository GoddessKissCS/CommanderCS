﻿using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class FirstPaymentRewardInfo
    {
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

        [JsonProperty("uifo")]
        public UserInformationResponse.BattleStatistics userInfo { get; set; }
    }
}