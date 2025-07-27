using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class BuildingLevelDataRow : DataRow
    {
        public static readonly string ResourceIdFormat = "thum_{0}";

        public int index { get; set; }

        public EBuilding type { get; private set; }

        public string resourceId => type.ToString();

        public int level { get; private set; }

        public string name { get; private set; }

        public int userLevel { get; private set; }

        public int vipLevel { get; private set; }

        public string locNameKey => name;

        public string locInformationMessageKey => _CombineLocalizeKey("Information.Message");

        public string locInformationSubMessageKey => _CombineLocalizeKey("Information.SubMessage");

        public string locDescriptionKey => _CombineLocalizeKey("Description");

        public string locFuctionKey => _CombineLocalizeKey("Function");

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }

        public string GetKey()
        {
            return index.ToString();
        }

        private string _CombineLocalizeKey(string postfix)
        {
            if (postfix == "Name")
            {
                return (type + 1899).ToString();
            }
            return $"Building.{type}.{postfix}";
        }

        public string GetLocalizedDescriptionTitleKey(int idx)
        {
            return $"Building.{type}.Information.Description.{idx}.Title";
        }

        public string GetLocalizedDescriptionValueKey(int idx)
        {
            return $"Building.{type}.Information.Description.{idx}.Value";
        }
    }
}