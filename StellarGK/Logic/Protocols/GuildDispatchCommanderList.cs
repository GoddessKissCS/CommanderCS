using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GuildDispatchCommanderList
    {
        [JsonPropertyName("guild")]
        public List<GuildDispatchCommanderInfo> commanderList;

        [JsonPropertyName("npc")]
        public Dictionary<string, int> npcList;


        public class GuildDispatchCommanderInfo
        {
            [JsonPropertyName("tuno")]
            public int userIdx { get; set; }

            [JsonPropertyName("tlv")]
            public int userLevel { get; set; }

            [JsonPropertyName("tunm")]
            public string userName { get; set; }

            [JsonPropertyName("thmb")]
            public string userThumbnail { get; set; }

            [JsonPropertyName("tcid")]
            public int cid { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("grd")]
            public int grade { get; set; }

            [JsonPropertyName("cls")]
            public int cls { get; set; }

            [JsonPropertyName("skv1")]
            public int skillLv_1 { get; set; }

            [JsonPropertyName("skv2")]
            public int skillLv_2 { get; set; }

            [JsonPropertyName("skv3")]
            public int skillLv_3 { get; set; }

            [JsonPropertyName("skv4")]
            public int skillLv_4 { get; set; }

            [JsonPropertyName("cos")]
            public int costumeIdx { get; set; }

            [JsonPropertyName("rfs")]
            public int favorStep { get; set; }

            [JsonPropertyName("mry")]
            public int marry { get; set; }

            [JsonPropertyName("tsdc")]
            public List<int> transcendence { get; set; }

            [JsonPropertyName("empl")]
            public int possibleEngage { get; set; }

            [JsonPropertyName("exst")]
            public int existEngaged { get; set; }

            [JsonPropertyName("sp")]
            public int sp { get; set; }

            [JsonPropertyName("dmghp")]
            public int dmghp { get; set; }

            [JsonPropertyName("hp")]
            public int hp { get; set; }

            [JsonPropertyName("equip")]
            public Dictionary<string, int> equipItem { get; set; }

            [JsonPropertyName("wp")]
            public Dictionary<string, WeaponData> weaponItem { get; set; }
        }
    }
}
