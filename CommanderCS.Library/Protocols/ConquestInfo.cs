using CommanderCS.Library.Enums;
using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class ConquestInfo
    {

        /// <summary>
        /// Gets or sets state of the Conquest.
        /// None is idk
        /// Join means we joined
        /// Match means matching for opponent
        /// Setting is if we are in the battle state
        /// and Battle is for finishing the guild battle
        /// </summary>
        [JsonProperty("step")]
        public EConquestState state { get; set; }


        /// <summary>
        /// Gets or sets remaing time for the certain state
        /// </summary>
        [JsonProperty("remain")]
        public int remain { get; set; }
        
        /// <summary>
        /// Gets or sets , if we signed up for guild battle
        /// </summary>

        [JsonProperty("signed")]
        public int sign { get; set; }

        /// <summary>
        /// Gets or sets join of the Guild Battle
        /// </summary>
        [JsonProperty("join")]
        public int join { get; set; }

        /// <summary>
        /// Gets or sets the side can only be R for Red or B for Blue
        /// </summary>
        [JsonProperty("side")]
        public string side { get; set; }

        [JsonProperty("prev")]
        public PrevState prev { get; set; }

        public class PrevState
        {
            [JsonProperty("isWin")]
            public int isWin { get; set; }

            [JsonProperty("exdt")]
            public int exdt { get; set; }

            [JsonProperty("point")]
            public Point pointData { get; set; }

            [JsonProperty("users")]
            public Dictionary<string, int> userList { get; set; }

            [JsonProperty("usrpnt")]
            public List<int> standbyList { get; set; }

            public class Point
            {
                [JsonProperty("win")]
                public List<int> win { get; set; }

                [JsonProperty("lose")]
                public List<int> lose { get; set; }
            }
        }
    }
}