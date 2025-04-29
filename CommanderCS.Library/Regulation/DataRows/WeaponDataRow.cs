using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class WeaponDataRow : DataRow
    {
        public const int StatPointCount = 4;

        public string idx { get; private set; }

        public string weaponName { get; private set; }

        public int slotType { get; private set; }

        public int weaponGrade { get; private set; }

        public List<EItemStatType> statType { get; private set; }

        public List<int> statBasePoint { get; private set; }

        public List<int> statAddPoint { get; private set; }

        public ESkillTargetType targetType { get; private set; }

        public List<int> clingingTurn { get; private set; }

        public List<string> statusEffectDrks { get; private set; }

        public List<string> explanation { get; private set; }

        public int privateWeapon { get; private set; }

        public EWeaponSkill skillPoint { get; private set; }

        public string unitIdx { get; private set; }

        public string skillIdx { get; private set; }

        public string decompositionReward { get; private set; }

        public int value { get; private set; }

        public List<int> materialMax { get; private set; }

        public List<int> materialMin { get; private set; }

        public int productionTime { get; private set; }

        public string weaponIcon { get; private set; }

        public string weaponDescription { get; private set; }

        public string weaponSetType { get; private set; }

        public string GetKey()
        {
            return idx;
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