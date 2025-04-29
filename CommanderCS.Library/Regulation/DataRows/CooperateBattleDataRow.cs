using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    public class CooperateBattleDataRow : DataRow
    {
        public string idx { get; private set; }

        public int step { get; private set; }

        public ECooperateBattleEnemyType enemyType { get; private set; }

        public string enemy { get; private set; }

        public int enemyLevel { get; private set; }

        public int enemyClass { get; private set; }

        public int power { get; private set; }

        public int endTurn { get; private set; }

        public int goalPoint { get; private set; }

        public int goalPointIncrease { get; private set; }

        public string name { get; private set; }

        public string description { get; private set; }

        public string battleMap { get; private set; }

        public string enemyMap { get; private set; }

        public string bgm { get; private set; }

        public int enemyrPos { get; private set; }

        public List<string> parts { get; private set; }

        public List<int> partsPos { get; private set; }

        public string GetKey()
        {
            return idx;
        }
    }
}