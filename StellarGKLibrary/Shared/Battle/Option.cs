using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject]
    public struct Option
    {
        public static explicit operator JToken(Option value)
        {
            return new JArray { value.enableEffect };
        }

        public static explicit operator Option(JToken value)
        {
            Option @default = Option.Default;
            @default.enableEffect = (bool)value[0];
            return @default;
        }

        public static Option Default = new Option
        {
            playMode = Option.PlayMode.Default,
            timeLimit = 900000,
            turnLimit = -1,
            winSideByTimeOut = 1,
            canSelectTarget = false,
            canEnemyUnitCtl = false,
            immediatelyUseActiveSkill = true,
            canInterfereSkill = false,
            waitingInputMode = false,
            enableEffect = true,
            canLhsCutIn = true,
            canRhsCutIn = false,
            enableLhsFireAction = true,
            enableRhsFireAction = false,
            enableFatalCut = true,
            delayTurnChangeTime = 1200
        };

        [JsonIgnore]
        public Option.PlayMode playMode;

        [JsonIgnore]
        public int timeLimit;

        [JsonIgnore]
        public int turnLimit;

        [JsonIgnore]
        public int winSideByTimeOut;

        [JsonIgnore]
        public bool canEnemyUnitCtl;

        [JsonIgnore]
        public bool canSelectTarget;

        [JsonIgnore]
        public bool immediatelyUseActiveSkill;

        [JsonIgnore]
        public bool canInterfereSkill;

        [JsonIgnore]
        public bool waitingInputMode;

        [JsonProperty("efct")]
        public bool enableEffect;

        [JsonIgnore]
        public bool enableLhsFireAction;

        [JsonIgnore]
        public bool enableRhsFireAction;

        [JsonIgnore]
        public bool enableFatalCut;

        [JsonIgnore]
        public bool canLhsCutIn;

        [JsonIgnore]
        public bool canRhsCutIn;

        [JsonIgnore]
        public int delayTurnChangeTime;

        public enum PlayMode
        {
            Default,
            PureTurn,
            RealTime
        }
    }
}
