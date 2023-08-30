using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Battle
{
    public class ClearMissionItem
    {
        public ClearMissionItem(EBattleClearCondition condition, int id, string conditionValue = "0")
        {
            this.id = id;
            this._finish = false;
            this._success = true;
            this._condition = condition;
            this._conditionValue = conditionValue;
        }

        public bool isFinish
        {
            get
            {
                return this._finish;
            }
            set
            {
                this._finish = value;
            }
        }

        public bool isSuccess
        {
            get
            {
                return this._success;
            }
            set
            {
                this._success = value;
            }
        }

        public EBattleClearCondition condition
        {
            get
            {
                return this._condition;
            }
        }

        public string conditionValue
        {
            get
            {
                return this._conditionValue;
            }
        }

        public int id;

        private bool _finish;

        private bool _success = true;

        private EBattleClearCondition _condition;

        private string _conditionValue;
    }
}
