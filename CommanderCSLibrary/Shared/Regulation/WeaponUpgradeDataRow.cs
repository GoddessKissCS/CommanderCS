using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class WeaponUpgradeDataRow : DataRow
    {
        public int slotType { get; private set; }

        public int level { get; private set; }

        public int gold { get; private set; }

        public string pIdx { get; private set; }

        public int value { get; private set; }

        public string GetKey()
        {
            return $"{slotType}-{level}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }

}