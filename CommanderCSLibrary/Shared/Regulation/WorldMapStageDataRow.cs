using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Numerics;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class WorldMapStageDataRow : DataRow
    {
        [Serializable]
        [JsonObject]
        public class Range
        {
            public int min { get; private set; }

            public int max { get; private set; }
        }

        public string id { get; private set; }

        public string worldMapId { get; private set; }

        public float positionX { get; private set; }

        public float positionY { get; private set; }

        public Vector3 position => new Vector3(positionX, positionY, 0f);

        public string typeId { get; private set; }

        public EStageTypeIdRange type
        {
            get
            {
                int result = 0;
                if (!int.TryParse(typeId, out result))
                {
                    return EStageTypeIdRange.Undefined;
                }
                if (1 <= result && 100 >= result)
                {
                    return EStageTypeIdRange.GuardPost;
                }
                if (101 <= result && 200 >= result)
                {
                    return EStageTypeIdRange.Storage;
                }
                if (201 <= result && 300 >= result)
                {
                    return EStageTypeIdRange.Factory;
                }
                if (301 <= result && 400 >= result)
                {
                    return EStageTypeIdRange.Terrorist;
                }
                if (401 <= result && 500 >= result)
                {
                    return EStageTypeIdRange.PowerPlant;
                }
                return EStageTypeIdRange.Undefined;
            }
        }

        public int bullet { get; private set; }

        public ETerrainType terrain { get; private set; }

        public int order { get; private set; }

        public string enemyId { get; private set; }

        public int rewardGold { get; private set; }

        public string title { get; private set; }

        public string description { get; private set; }

        public int favorup { get; private set; }

        public string battlemap { get; private set; }

        public string enemymap { get; private set; }

        public int turn1 { get; private set; }

        public int turn2 { get; private set; }

        public int turn3 { get; private set; }

        [JsonProperty("getStar01")]
        public EBattleClearCondition clearCondition1 { get; private set; }

        [JsonProperty("getStar01Count")]
        public string clearCondition1_Value { get; private set; }

        [JsonProperty("getStar02")]
        public EBattleClearCondition clearCondition2 { get; private set; }

        [JsonProperty("getStar02Count")]
        public string clearCondition2_Value { get; private set; }

        public int commanderexp { get; private set; }

        private WorldMapStageDataRow()
        {
        }

        public string GetKey()
        {
            return id;
        }
    }
}