using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using BattleSimulator.Regulation;

namespace BattleSimulator.Battle
{
	[JsonObject(MemberSerialization.OptIn)]
	public class FirePoint
	{
		private FirePoint()
		{
		}

		public int subIdx
		{
			get
			{
				return _subIdx;
			}
		}

		public int projectileDri
		{
			get
			{
				return _projectileDri;
			}
		}

		public string firePattern
		{
			get
			{
				return _firePattern;
			}
		}

		public IList<int> statusEffectDris
		{
			get
			{
				return _statusEffectDris.AsReadOnly();
			}
		}

		public IList<Projectile> projectiles
		{
			get
			{
				return _projectiles.AsReadOnly();
			}
		}

		internal static FirePoint _Create(Regulation rg, SkillDataRow skillDr, int index, int subIdx)
		{
			string text = ((subIdx != 0) ? skillDr.fireSubProjectileDrks[index] : skillDr.projectileDrks[index]);
			int num = rg.projectileDtbl.FindIndex(text);
			if (num < 0)
			{
				throw new ArgumentException("projectileDtbl drk doesn't exist. : " + text);
			}
            FirePoint firePoint = new FirePoint
            {
                _subIdx = subIdx,
                _projectiles = new List<Projectile>(),
                _statusEffectDris = new List<int>(),
                _projectileDri = num,
                _firePattern = ((subIdx != 0) ? skillDr.fireSubPatterns[index] : skillDr.firePatterns[index])
            };
            ProjectileDataRow projectileDataRow = rg.projectileDtbl[firePoint._projectileDri];
			foreach (string text2 in projectileDataRow.statusEffectDrks)
			{
				if (!string.IsNullOrEmpty(text2) && text2 != "0")
				{
					int num2 = rg.statusEffectDtbl.FindIndex(text2);
					if (num2 < 0)
					{
						throw new ArgumentException("statusEffectDtbl drk doesn't exist. : " + text2);
					}
					firePoint._statusEffectDris.Add(num2);
				}
			}
			return firePoint;
		}

		internal static FirePoint _Copy(FirePoint src)
		{
            FirePoint firePoint = new FirePoint
            {
                _subIdx = src._subIdx,
                _projectileDri = src._projectileDri,
                _firePattern = src._firePattern,
                _statusEffectDris = new List<int>(src._statusEffectDris),
                _projectiles = new List<Projectile>(src._projectiles.Count)
            };
            for (int i = 0; i < src._projectiles.Count; i++)
			{
				firePoint._projectiles.Add(Projectile._Copy(src._projectiles[i]));
			}
			return firePoint;
		}

		[JsonProperty]
		internal int _subIdx;

		[JsonProperty]
		internal int _projectileDri;

		[JsonProperty]
		internal List<int> _statusEffectDris;

		[JsonProperty]
		internal List<Projectile> _projectiles;

		[JsonProperty]
		internal string _firePattern;
	}
}
