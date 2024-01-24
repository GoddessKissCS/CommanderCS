using MongoDB.Bson;
using Newtonsoft.Json;

namespace StellarGK.MongoDB.Schemes
{
    public class RaidRankScheme
    {
        public ObjectId Id { get; set; }
        public int Uno { get; set; }

        [JsonProperty("rank")]
        public int ranking { get; set; }

        [JsonProperty("prct")]
        public float rankingRate { get; set; }

        [JsonProperty("score")]
        public int score { get; set; }

        [JsonProperty("nScore")]
        public int nextScore { get; set; }

        [JsonProperty("wst")]
        public int winningStreak { get; set; }

        [JsonProperty("lst")]
        public int losingStreak { get; set; }

        [JsonProperty("win")]
        public int winCnt { get; set; }

        [JsonProperty("lose")]
        public int loseCnt { get; set; }

        [JsonProperty("rcnt")]
        public int raidCnt { get; set; }

        [JsonProperty("nscr")]
        public int bestScore { get; set; }

        [JsonProperty("avrg")]
        public int averageScore { get; set; }

        [JsonProperty("ridx")]
        public int rewardId { get; set; }

        [JsonProperty("dpnt")]
        public int duelPoint { get; set; }

        [JsonProperty("didx")]
        public int rewardDuelPoint { get; set; }

        [JsonProperty("wrank")]
        public int winRank { get; set; }

        [JsonProperty("wridx")]
        public int winRankIdx { get; set; }

        [JsonProperty("drank")]
        public int raidRank { get; set; }

        [JsonProperty("dridx")]
        public int raidRewardPoint { get; set; }
    }
}
