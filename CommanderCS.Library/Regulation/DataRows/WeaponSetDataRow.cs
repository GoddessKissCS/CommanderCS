using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class WeaponSetDataRow : DataRow
    {
        public const int StatPointCount = 4;

        public string type { get; private set; }

        public EItemSetType weaponSetStatType { get; private set; }

        public int weaponSetStatAddPoint { get; private set; }

        public string GetKey()
        {
            return type;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }

        public static int GetStatPoint(int level, int basePoint, int addPoint)
        {
            return basePoint + level * addPoint;
        }
    }
}