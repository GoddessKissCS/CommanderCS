using StellarGKLibrary.Enums;
using System.Collections.Generic;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class SkillDamagePattern
	{
		public SkillDamagePattern()
		{
			_dataRows = new List<SkillDamagePatternDataRow>();
		}

		public SkillDamagePatternDataRow Get(int hpRate)
		{
			for (int i = 0; i < _dataRows.Count; i++)
			{
				SkillDamagePatternDataRow skillDamagePatternDataRow = _dataRows[i];
				if (skillDamagePatternDataRow.maxHpRate >= hpRate && skillDamagePatternDataRow.minHpRate <= hpRate)
				{
					return skillDamagePatternDataRow;
				}
			}
			return null;
		}

		public void Add(SkillDamagePatternDataRow row)
		{
			_dataRows.Add(row);
		}

		private List<SkillDamagePatternDataRow> _dataRows;
	}
}