using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RankingUserData
    {
        [JsonPropertyName("rank")]
        public int ranking { get; set; }

        [JsonPropertyName("prct")]
        public float rankingRate { get; set; }

        [JsonPropertyName("score")]
        public int score { get; set; }

        [JsonPropertyName("nScore")]
        public int nextScore { get; set; }

        [JsonPropertyName("wst")]
        public int winningStreak { get; set; }

        [JsonPropertyName("lst")]
        public int losingStreak { get; set; }

        [JsonPropertyName("win")]
        public int winCnt { get; set; }

        [JsonPropertyName("lose")]
        public int loseCnt { get; set; }

        [JsonPropertyName("rcnt")]
        public int raidCnt { get; set; }

        [JsonPropertyName("nscr")]
        public int bestScore { get; set; }

        [JsonPropertyName("avrg")]
        public int averageScore { get; set; }

        [JsonPropertyName("ridx")]
        public int rewardId { get; set; }

        [JsonPropertyName("dpnt")]
        public int duelPoint { get; set; }

        [JsonPropertyName("didx")]
        public int rewardDuelPoint { get; set; }

        [JsonPropertyName("wrank")]
        public int winRank { get; set; }

        [JsonPropertyName("wridx")]
        public int winRankIdx { get; set; }

        [JsonPropertyName("drank")]
        public int raidRank { get; set; }

        [JsonPropertyName("dridx")]
        public int raidRewardPoint { get; set; }
    }
}
