using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class RankingDataRow : DataRow
    {
        public int r_idx { get; private set; }

        public ERankingContentsType type { get; private set; }

        public ERankingType rankingType1 { get; private set; }

        public int ranking1 { get; private set; }

        public ERankingType rankingType2 { get; private set; }

        public int ranking2 { get; private set; }

        public int rankingWin { get; private set; }

        public int rankingLose { get; private set; }

        public string icon { get; private set; }

        public string name { get; private set; }

        public string GetKey()
        {
            return r_idx.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}