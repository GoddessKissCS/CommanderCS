using System;
using System.Collections.Generic;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class WeaponEffect
{
	internal int _clingingTurn;

	internal int _statusDri;

	internal static List<WeaponEffect> _Create(Shared.Regulation.Regulation rg, WeaponDataRow weapon)
	{
		List<WeaponEffect> list = new List<WeaponEffect>();
		for (int i = 0; i < weapon.statusEffectDrks.Count; i++)
		{
			string text = weapon.statusEffectDrks[i];
			if (!string.IsNullOrEmpty(text) && !(text == "0"))
			{
				list.Add(_Create(rg, text, weapon.clingingTurn[i]));
			}
		}
		return list;
	}

	internal static WeaponEffect _Create(Shared.Regulation.Regulation rg, string statusDrk, int clingingTurn)
	{
		WeaponEffect weaponEffect = new WeaponEffect();
		weaponEffect._statusDri = rg.statusEffectDtbl.FindIndex(statusDrk);
		if (weaponEffect._statusDri < 0)
		{
			throw new ArgumentException("statusEffectDtbl drk doesn't exist. : " + statusDrk);
		}
		weaponEffect._clingingTurn = clingingTurn;
		return weaponEffect;
	}

	internal static WeaponEffect _Copy(WeaponEffect src)
	{
		WeaponEffect weaponEffect = new WeaponEffect();
		weaponEffect._clingingTurn = src._clingingTurn;
		weaponEffect._statusDri = src._statusDri;
		return weaponEffect;
	}
}
