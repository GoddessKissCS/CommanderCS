using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class ThumbnailDataRow : DataRow
    {
        public int idx { get; private set; }

        public ThumbnailType category { get; private set; }

        public string c_idx { get; private set; }

        public string resource { get; private set; }

        public string resourceName => resource;

        private ThumbnailDataRow()
        {
        }

        public string GetKey()
        {
            return idx.ToString();
        }
    }
}