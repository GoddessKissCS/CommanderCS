using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class GuildDispatchCommanderList
    {
        [JsonProperty("guild")]
        public List<GuildDispatchCommanderInfo> commanderList;

        [JsonProperty("npc")]
        public Dictionary<string, int> npcList;

        public class GuildDispatchCommanderInfo
        {
            [JsonProperty("tuno")]
            public int userIdx { get; set; }

            [JsonProperty("tlv")]
            public int userLevel { get; set; }

            [JsonProperty("tunm")]
            public string userName { get; set; }

            [JsonProperty("thmb")]
            public string userThumbnail { get; set; }

            [JsonProperty("tcid")]
            public int cid { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("grd")]
            public int grade { get; set; }

            [JsonProperty("cls")]
            public int cls { get; set; }

            [JsonProperty("skv1")]
            public int skillLv_1 { get; set; }

            [JsonProperty("skv2")]
            public int skillLv_2 { get; set; }

            [JsonProperty("skv3")]
            public int skillLv_3 { get; set; }

            [JsonProperty("skv4")]
            public int skillLv_4 { get; set; }

            [JsonProperty("cos")]
            public int costumeIdx { get; set; }

            [JsonProperty("rfs")]
            public int favorStep { get; set; }

            [JsonProperty("mry")]
            public int marry { get; set; }

            [JsonProperty("tsdc")]
            public List<int> transcendence { get; set; }

            [JsonProperty("empl")]
            public int possibleEngage { get; set; }

            [JsonProperty("exst")]
            public int existEngaged { get; set; }

            [JsonProperty("sp")]
            public int sp { get; set; }

            [JsonProperty("dmghp")]
            public int dmghp { get; set; }

            [JsonProperty("hp")]
            public int hp { get; set; }

            [JsonProperty("equip")]
            public Dictionary<string, int> equipItem { get; set; }

            [JsonProperty("wp")]
            public Dictionary<string, WeaponData> weaponItem { get; set; }
        }
    }
}