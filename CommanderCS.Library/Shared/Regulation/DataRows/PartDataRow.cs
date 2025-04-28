using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class PartDataRow : DataRow
    {
        public static readonly string itemBGPrefix = "icon_bg";

        public static readonly string itemMarkPrefix = "icon_mark";

        public static readonly string itemOutlinePrefix = "icon_outline";

        public string type { get; private set; }

        public int grade { get; private set; }

        public string name { get; private set; }

        public EUnitType mark { get; private set; }

        public string serverFieldName { get; private set; }

        public int max { get; private set; }

        public string description { get; private set; }

        public string bgResource => itemBGPrefix + grade;

        public string markResource => itemMarkPrefix + (int)mark;

        public string gradeResource => itemOutlinePrefix + grade;

        public string GetKey()
        {
            return type.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}