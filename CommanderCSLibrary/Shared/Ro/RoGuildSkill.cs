using CommanderCSLibrary.Shared.Battle;
using CommanderCSLibrary.Shared.Regulation;

namespace CommanderCSLibrary.Shared.Ro
{
    public class RoGuildSkill
    {
        private int _skillLevel;

        private GuildSkillDataRow _reg;

        private GuildSkillDataRow _nextLevelReg;

        private GuildSkillDataRow _firstLevelReg;

        public int idx { get; set; }

        public int skillLevel
        {
            get
            {
                return _skillLevel;
            }
            set
            {
                if (_skillLevel != value)
                {
                    _skillLevel = value;
                    _reg = null;
                    _nextLevelReg = null;
                }
            }
        }

        public string name { get; set; }

        public string description { get; set; }

        public bool isMaxLevel => nextLevelReg == null;

        public GuildSkillDataRow reg
        {
            get
            {
                if (_reg == null)
                {
                    _reg = _GetReguilation(skillLevel);
                }
                return _reg;
            }
        }

        public GuildSkillDataRow nextLevelReg
        {
            get
            {
                if (_nextLevelReg == null)
                {
                    _nextLevelReg = _GetReguilation(skillLevel + 1);
                }
                return _nextLevelReg;
            }
        }

        public GuildSkillDataRow firstLevelReg
        {
            get
            {
                if (_firstLevelReg == null)
                {
                    _firstLevelReg = _GetReguilation(0);
                }
                return _firstLevelReg;
            }
        }

        //public bool isUpgrade => nextLevelReg.level <= RemoteObjectManager.instance.localUser.guildInfo.level;

        //public bool isEnoughUpgradePoint => nextLevelReg.cost <= RemoteObjectManager.instance.localUser.guildInfo.point;

        public static RoGuildSkill Create(int idx, int level = 0)
        {
            RoGuildSkill roGuildSkill = new()
            {
                idx = idx,
                skillLevel = level
            };
            roGuildSkill.name = roGuildSkill.reg.name;
            roGuildSkill.description = roGuildSkill.reg.description;
            return roGuildSkill;
        }

        private GuildSkillDataRow _GetReguilation(int level)
        {
            Regulation.Regulation regulation = Constants.regulation;
            string key = $"{idx}_{level}";
            int num = regulation.guildSkillDtbl.FindIndex(key);
            if (num < 0)
            {
                return null;
            }
            return regulation.guildSkillDtbl[num];
        }

        public GuildSkillState ToBattleGuildSkillData()
        {
            return GuildSkillState.Create(idx, skillLevel, reg);
        }
    }
}