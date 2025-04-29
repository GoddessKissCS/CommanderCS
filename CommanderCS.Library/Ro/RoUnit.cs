using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using CommanderCS.Library.Regulation.DataRows;
using Newtonsoft.Json;

namespace CommanderCS.Library.Ro
{
    [JsonObject]
    public class RoUnit
    {
        [JsonIgnore]
        private string _id;

        [JsonIgnore]
        private int _level = 0;

        [JsonIgnore]
        private int _rank;

        [JsonIgnore]
        private int _cls = 0;

        [JsonIgnore]
        private int _costume = 0;

        [JsonIgnore]
        private UnitDataRow _currLevelReg;

        [JsonIgnore]
        private UnitDataRow _prevLevelReg;

        [JsonIgnore]
        private UnitDataRow _unitReg;

        [JsonIgnore]
        private UnitDataRow _currClsReg;

        [JsonIgnore]
        private UnitDataRow _prevClsReg;

        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    unitReg = null;
                    currLevelReg = null;
                }
            }
        }

        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    unitReg = null;
                    currLevelReg = null;
                }
            }
        }

        public int rank
        {
            get
            {
                return _rank;
            }
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    currLevelReg = null;
                }
            }
        }

        public int cls
        {
            get
            {
                return _cls;
            }
            set
            {
                if (_cls != value)
                {
                    _cls = value;
                    unitReg = null;
                    currLevelReg = null;
                }
            }
        }

        public int costume
        {
            get
            {
                return _costume;
            }
            set
            {
                if (_costume != value)
                {
                    _costume = value;
                    unitReg = null;
                    currLevelReg = null;
                }
            }
        }

        public string commanderId { get; set; }

        public int favorRewardStep { get; set; }

        public int marry { get; set; }

        public List<int> transcendence { get; set; }

        public EBattleType battleType { get; set; }

        public TimeData trainingTime { get; set; }

        public UnitDataRow currLevelReg
        {
            get
            {
                if (_currLevelReg is null)
                {
                    _currLevelReg = InvokeLevel(unitReg, rank, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, battleType, equipItem, isItemSet, weaponItem);
                }
                return _currLevelReg;
            }
            private set
            {
                _currLevelReg = value;
            }
        }

        public UnitDataRow prevLevelReg
        {
            get
            {
                if (_currLevelReg is null)
                {
                    _prevLevelReg = InvokeLevel(unitReg, rank, level - 1, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, equipItem, isItemSet, weaponItem);
                }
                return _prevLevelReg;
            }
            private set
            {
                _prevLevelReg = value;
            }
        }

        public UnitDataRow unitReg
        {
            get
            {
                if (_unitReg is null)
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        return null;
                    }
                    DataTable<UnitDataRow> unitDtbl = RemoteObjectManager.instance.regulation.unitDtbl;
                    if (!unitDtbl.ContainsKey(id))
                    {
                        return null;
                    }
                    _unitReg = unitDtbl[id];
                }
                return _unitReg;
            }
            private set
            {
                _unitReg = value;
            }
        }

        public UnitDataRow currClsReg
        {
            get
            {
                if (_currClsReg is null)
                {
                    _currClsReg = InvokeLevel(unitReg, rank, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, equipItem, isItemSet, weaponItem);
                }
                return _currClsReg;
            }
            private set
            {
                _currClsReg = value;
            }
        }

        public UnitDataRow prevClsReg
        {
            get
            {
                if (_currClsReg is null)
                {
                    _prevClsReg = InvokeLevel(unitReg, rank, level, cls - 1, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, equipItem, isItemSet, weaponItem);
                }
                return _prevClsReg;
            }
            private set
            {
                _prevClsReg = value;
            }
        }

        public string resourceId => currLevelReg.resourceName;

        //public bool unlocked
        //{
        //	get
        //	{
        //		if (unitReg is null)
        //		{
        //			return false;
        //		}
        //		return unitReg.unlockLevel <= RemoteObjectManager.instance.localUser.buildingDict[EBuilding.UnitResearch].level;
        //	}
        //}

        public Dictionary<int, RoItem> equipItem { get; set; }

        public Dictionary<int, RoWeapon> weaponItem { get; set; }

        public bool isItemSet { get; set; }

        public static RoUnit Create(string id, int level, int rank, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, EBattleType battleType = EBattleType.Undefined, Dictionary<int, RoItem> equipItem = null, Dictionary<int, RoWeapon> weaponItem = null)
        {
            RoUnit roUnit = new()
            {
                id = id,
                level = level,
                cls = cls,
                rank = rank,
                costume = costume,
                commanderId = commanderId,
                favorRewardStep = favorRewardStep,
                marry = marry,
                transcendence = transcendence,
                trainingTime = TimeData.Create(-1.0, -1.0),
                battleType = battleType,
                equipItem = equipItem,
                weaponItem = weaponItem
            };
            if (equipItem is not null && equipItem.Count == 4)
            {
                roUnit.isItemSet = equipItem[1].setType == equipItem[2].setType && equipItem[2].setType == equipItem[3].setType && equipItem[3].setType == equipItem[4].setType;
            }
            return roUnit;
        }

        public static UnitDataRow InvokeLevel(UnitDataRow pureUnitReg, int grade, int level, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, EBattleType battleType = EBattleType.Undefined, Dictionary<int, RoItem> equipItem = null, bool isItemSet = false, Dictionary<int, RoWeapon> weaponItem = null)
        {
            UnitDataRow unitDataRow = pureUnitReg.Clone();
            //unitDataRow.InvokeLevel(grade, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, battleType, equipItem, isItemSet, weaponItem);
            return unitDataRow;
        }

        public RoUnit CreateNextLevel()
        {
            return Create(id, level + 1, 1, cls, costume, commanderId, favorRewardStep, marry, transcendence);
        }

        public RoUnit CreateNextGrade()
        {
            return Create(id, level, rank + 1, cls, costume, commanderId, favorRewardStep, marry, transcendence);
        }

        public void StartLevelUp()
        {
            trainingTime.SetByDuration(5000.0);
        }

        public void EndLevelUp()
        {
            if (trainingTime.IsValid())
            {
                trainingTime.Set(-1.0, -1.0);
                ++level;
            }
        }
    }
}