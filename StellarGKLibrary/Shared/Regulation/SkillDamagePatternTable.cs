using StellarGKLibrary.Enums;
using System.Collections.Generic;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class SkillDamagePatternTable
	{
		public void Init(Regulation rg)
		{
			_datas = new Dictionary<int, SkillDamagePattern>();
			for (int i = 0; i < rg.skillDamagePatternDtbl.length; i++)
			{
				SkillDamagePatternDataRow skillDamagePatternDataRow = rg.skillDamagePatternDtbl[i];
				if (!_datas.ContainsKey(skillDamagePatternDataRow.key))
				{
					_datas.Add(skillDamagePatternDataRow.key, new SkillDamagePattern());
				}
				_datas[skillDamagePatternDataRow.key].Add(skillDamagePatternDataRow);
			}
		}

		public SkillDamagePattern Get(int key)
		{
			if (!_datas.ContainsKey(key))
			{
				return null;
			}
			return _datas[key];
		}

		public SkillDamagePatternDataRow Get(int key, int hpRate)
		{
			SkillDamagePattern skillDamagePattern = Get(key);
			if (skillDamagePattern == null)
			{
				return null;
			}
			return skillDamagePattern.Get(hpRate);
		}

		private Dictionary<int, SkillDamagePattern> _datas;
	}
}
