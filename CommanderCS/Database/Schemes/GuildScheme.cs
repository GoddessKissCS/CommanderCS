using MongoDB.Bson;
using CommanderCS.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Database.Schemes
{
    public class GuildScheme
    {
        public ObjectId Id { get; set; }
        public int GuildId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Point { get; set; }
        public int aPoint { get; set; }
        public int Emblem { get; set; }
        public int GuildType { get; set; }
        public int Limitlevel { get; set; }
        public string Notice { get; set; }
        public int State { get; set; }
        public double CloseTime { get; set; }
        public double CreateTime { get; set; }
        public int MaxCount { get; set; }
        public int Count { get; set; }
        public List<UserInformationResponse.UserGuild.GuildSkill> SkillDada { get; set; }
        public List<MemberData> MemberData { get; set; }
        public int Occupy { get; set; }
        public int World { get; set; }
        public List<GuildBoardData> BoardListData { get; set; }
        public double LastEdit { get; set; }
    }



    public class MemberData
    {
        [JsonProperty("uno")]
        public int uno { get; set; }

        [JsonProperty("unm")]
        public string name { get; set; }

        [JsonProperty("thumb")]
        public int thumnail { get; set; }

        [JsonProperty("lv")]
        public int level { get; set; }

        [JsonProperty("time")]
        public double lastTime { get; set; }

        [JsonProperty("jdate")]
        public double joinDate { get; set; }

        [JsonProperty("mstr")]
        public int memberGrade { get; set; }

        [JsonProperty("dpnt")]
        public int todayPoint { get; set; }

        [JsonProperty("mpnt")]
        public int totalPoint { get; set; }

        [JsonProperty("pbpnt")]
        public int paymentBonusPoint { get; set; }

        [JsonProperty("world")]
        public int world { get; set; }
    }

}