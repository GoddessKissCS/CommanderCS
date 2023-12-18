using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class FireActionDataRow : DataRow
    {
        [Serializable]
        [JsonObject]
        public class TimeSet
        {
            public int duration { get; private set; }

            public int eventTime { get; private set; }

            public int fireDelayTime { get; private set; }

            public int hitDelayTime { get; private set; }

            public bool timeSleepDuringFire { get; private set; }
        }

        public string key { get; private set; }

        public TimeSet on { get; private set; }

        public TimeSet off { get; private set; }

        public FireActionDataRow()
        {
            on = new TimeSet();
            off = new TimeSet();
        }

        public string GetKey()
        {
            return key;
        }

        public TimeSet GetTimeSet(bool enableEffect)
        {
            if (enableEffect)
            {
                return on;
            }
            return off;
        }
    }

}

