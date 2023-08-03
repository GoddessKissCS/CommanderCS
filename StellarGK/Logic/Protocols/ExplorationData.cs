using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ExplorationData
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

        public long _timeTick { get; set; }

        public double _remainTime { get; set; }

        [JsonPropertyName("rmtm")]
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

        [JsonPropertyName("cid")]
        public List<string> cids { get; set; }
    }

}
