using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class UnitMotionDataRow : DataRow
    {
        public const int FirePointTypeCount = 3;

        public const int FireEventCount = 20;

        [JsonProperty("fireEvent")]
        private List<FireEvent> _fireEvents;

        [JsonProperty("atkSwitchEvents")]
        private List<AttackSwitchEvent> _atkSwitchEvents;

        [JsonProperty("fireCounts")]
        private List<int> _fireCounts;

        public string key { get; private set; }

        public int playTime { get; private set; }

        [JsonIgnore]
        public IList<FireEvent> fireEvents => _fireEvents.AsReadOnly();

        [JsonIgnore]
        public IList<AttackSwitchEvent> atkSwitchEvents => _atkSwitchEvents.AsReadOnly();

        [JsonIgnore]
        public IList<int> fireCounts => _fireCounts.AsReadOnly();

        [JsonIgnore]
        public int totalFireCount
        {
            get
            {
                int num = 0;
                foreach (int fireCount in fireCounts)
                {
                    num += fireCount;
                }
                return num;
            }
        }

        private UnitMotionDataRow()
        {
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Regulation.ExtendList(ref _fireEvents, 20);
            Regulation.FillList(ref _fireCounts, 3);
        }

        public string GetKey()
        {
            return key;
        }

        public static string MakeKey(string assetPath, string animationClipName)
        {
            string prefabHome = UnitDataRow.PrefabHome;
            if (assetPath.IndexOf(prefabHome) != 0)
            {
                throw new ArgumentException();
            }
            string text = assetPath.Substring((prefabHome + "/").Length);
            text = text.Substring(0, text.LastIndexOf("/"));
            if (text.StartsWith(UnitDataRow.ResourceIdPrefix))
            {
                string s = text.Substring(UnitDataRow.ResourceIdPrefix.Length);
                int result = 0;
                if (int.TryParse(s, out result))
                {
                    text = result.ToString();
                }
            }
            return text + "/" + animationClipName;
        }

        public static string MakeAnimationClipName(string key)
        {
            int num = key.LastIndexOf("/") + 1;
            if (num <= 0 || num >= key.Length)
            {
                return string.Empty;
            }
            return key.Substring(num);
        }

        public static UnitMotionDataRow Create(string key, int playTime, List<FireEvent> fireEvents, List<AttackSwitchEvent> atkSwitchEvents)
        {
            UnitMotionDataRow unitMotionDataRow = new()
            {
                key = key,
                playTime = playTime,
                _fireEvents = fireEvents,
                _atkSwitchEvents = atkSwitchEvents,
                _fireCounts = new List<int>(new int[3])
            };
            foreach (FireEvent fireEvent in fireEvents)
            {
                if (fireEvent is not null)
                {
                    unitMotionDataRow._fireCounts[fireEvent.firePointTypeIndex]++;
                }
            }
            return unitMotionDataRow;
        }
    }
}