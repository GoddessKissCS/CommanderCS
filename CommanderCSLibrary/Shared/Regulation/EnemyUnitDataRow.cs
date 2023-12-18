using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class EnemyUnitDataRow : DataRow
    {
        public int index { get; private set; }

        public string id { get; private set; }

        public int wave { get; private set; }

        public string unitId { get; private set; }

        public int unitLevel { get; private set; }

        public int unitPosition { get; private set; }

        public int unitGrade { get; private set; }

        public int unitClass { get; private set; }

        public List<int> skillLevel { get; private set; }

        public int unitScale { get; private set; }

        private EnemyUnitDataRow()
        {
        }

        public string GetKey()
        {
            return index.ToString();
        }
    }

}

