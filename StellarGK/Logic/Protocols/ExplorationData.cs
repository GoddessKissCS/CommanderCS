using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ExplorationData
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        public long _timeTick { get; set; }

        public double _remainTime { get; set; }

        [JsonProperty("rmtm")]
        public double remainTime
        {
            get
            {
                double num = _remainTime - elapsedTime;
                return num < 0.0 ? 0.0 : num;
            }
            set
            {
                _timeTick = DateTime.Now.Ticks;
                _remainTime = value;
            }
        }

        public double elapsedTime
        {
            get
            {
                return TimeSpan.FromTicks(DateTime.Now.Ticks - _timeTick).TotalSeconds;
            }
        }

        [JsonProperty("cid")]
        public List<string> cids { get; set; }
    }

}
