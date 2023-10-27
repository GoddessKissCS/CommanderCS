using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using BattleSimulator.Regulation;

namespace BattleSimulator.Battle
{
	[JsonObject(MemberSerialization.OptIn)]
	public class WeaponEffect
	{
		internal static List<WeaponEffect> _Create(Regulation rg, WeaponDataRow weapon)
		{
			List<WeaponEffect> list = new();
			for (int i = 0; i < weapon.statusEffectDrks.Count; i++)
			{
				string text = weapon.statusEffectDrks[i];
				if (!string.IsNullOrEmpty(text))
				{
					if (!(text == "0"))
					{
						list.Add(_Create(rg, text, weapon.clingingTurn[i]));
					}
				}
			}
			return list;
		}

		internal static WeaponEffect _Create(Regulation rg, string statusDrk, int clingingTurn)
		{
            WeaponEffect weaponEffect = new()
            {
                _statusDri = rg.statusEffectDtbl.FindIndex(statusDrk)
            };
            if (weaponEffect._statusDri < 0)
			{
				throw new ArgumentException("statusEffectDtbl drk doesn't exist. : " + statusDrk);
			}
			weaponEffect._clingingTurn = clingingTurn;
			return weaponEffect;
		}

		internal static WeaponEffect _Copy(WeaponEffect src)
		{
			return new()
            {
				_clingingTurn = src._clingingTurn,
				_statusDri = src._statusDri
			};
		}

		internal int _clingingTurn;

		internal int _statusDri;
	}
}
