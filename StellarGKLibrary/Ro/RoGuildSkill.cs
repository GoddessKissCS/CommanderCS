using System;
using Shared.Battle;
using Shared.Regulation;

public class RoGuildSkill
{
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

	public bool isMaxLevel
	{
		get
		{
			return nextLevelReg == null;
		}
	}

	public static RoGuildSkill Create(int idx, int level = 0)
	{
		RoGuildSkill roGuildSkill = new RoGuildSkill();
		roGuildSkill.idx = idx;
		roGuildSkill.skillLevel = level;
		roGuildSkill.name = roGuildSkill.reg.name;
		roGuildSkill.description = roGuildSkill.reg.description;
		return roGuildSkill;
	}

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

	private GuildSkillDataRow _GetReguilation(int level)
	{
		RemoteObjectManager instance = RemoteObjectManager.instance;
		string text = string.Format("{0}_{1}", idx, level);
		int num = instance.regulation.guildSkillDtbl.FindIndex(text);
		if (num < 0)
		{
			return null;
		}
		return instance.regulation.guildSkillDtbl[num];
	}

	public GuildSkillState ToBattleGuildSkillData()
	{
		return GuildSkillState.Create(idx, skillLevel, reg);
	}

	public bool isUpgrade
	{
		get
		{
			return nextLevelReg.level <= RemoteObjectManager.instance.localUser.guildInfo.level;
		}
	}

	public bool isEnoughUpgradePoint
	{
		get
		{
			return nextLevelReg.cost <= RemoteObjectManager.instance.localUser.guildInfo.point;
		}
	}

	private int _skillLevel;

	private GuildSkillDataRow _reg;

	private GuildSkillDataRow _nextLevelReg;

	private GuildSkillDataRow _firstLevelReg;
}
