using System.Collections.Generic;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class WorldDuelData
{
	[JsonProperty("pwld")]
	internal int _playerWorld;

	[JsonProperty("pbuf")]
	internal List<string> _playerBuffs;

	[JsonProperty("ewld")]
	internal int _enemyWorld;

	[JsonProperty("ebuf")]
	internal List<string> _enemyBuffs;

	[JsonIgnore]
	private bool _init;

	[JsonIgnore]
	public Dictionary<EWorldDuelBuff, int> plyerBuffs;

	[JsonIgnore]
	public Dictionary<EWorldDuelBuff, int> enemyBuffs;

	public void Init(Shared.Regulation.Regulation regulation)
	{
		if (!_init)
		{
			plyerBuffs = InitBuffs(regulation, _playerBuffs, _enemyBuffs);
			enemyBuffs = InitBuffs(regulation, _enemyBuffs, _playerBuffs);
			_init = true;
		}
	}

	private Dictionary<EWorldDuelBuff, int> InitBuffs(Shared.Regulation.Regulation regulation, List<string> ownerBuffs, List<string> enemyBuffs)
	{
		Dictionary<EWorldDuelBuff, int> dictionary = new Dictionary<EWorldDuelBuff, int>();
		dictionary.Add(EWorldDuelBuff.att, 0);
		dictionary.Add(EWorldDuelBuff.def, 0);
		dictionary.Add(EWorldDuelBuff.sup, 0);
		Dictionary<EWorldDuelBuff, int> dictionary2 = dictionary;
		for (int i = 0; i < ownerBuffs.Count; i++)
		{
			StrongestBuffBattleDataRow strongestBuffBattleDataRow = regulation.strongestBuffBattleDtbl[ownerBuffs[i]];
			if (strongestBuffBattleDataRow.buffEffectType == EWorldDuelBuffEffect.b)
			{
				dictionary2[strongestBuffBattleDataRow.buffTarget] += strongestBuffBattleDataRow.buffAdd;
			}
		}
		for (int j = 0; j < enemyBuffs.Count; j++)
		{
			StrongestBuffBattleDataRow strongestBuffBattleDataRow2 = regulation.strongestBuffBattleDtbl[enemyBuffs[j]];
			if (strongestBuffBattleDataRow2.buffEffectType == EWorldDuelBuffEffect.d)
			{
				dictionary2[strongestBuffBattleDataRow2.buffTarget] -= strongestBuffBattleDataRow2.buffAdd;
			}
		}
		return dictionary2;
	}

	public static WorldDuelData Copy(WorldDuelData src)
	{
		if (src == null)
		{
			return null;
		}
		WorldDuelData worldDuelData = new WorldDuelData();
		worldDuelData._playerWorld = src._playerWorld;
		if (src._playerBuffs != null)
		{
			worldDuelData._playerBuffs = new List<string>();
			for (int i = 0; i < src._playerBuffs.Count; i++)
			{
				worldDuelData._playerBuffs.Add(src._playerBuffs[i]);
			}
		}
		worldDuelData._enemyWorld = src._enemyWorld;
		if (src._enemyBuffs != null)
		{
			worldDuelData._enemyBuffs = new List<string>();
			for (int j = 0; j < src._enemyBuffs.Count; j++)
			{
				worldDuelData._enemyBuffs.Add(src._enemyBuffs[j]);
			}
		}
		return worldDuelData;
	}

	public static explicit operator JToken(WorldDuelData value)
	{
		if (value == null)
		{
			return string.Empty;
		}
		JArray jArray = new JArray();
		jArray.Add(value._playerWorld);
		if (value._playerBuffs != null)
		{
			JArray jArray2 = new JArray();
			for (int i = 0; i < value._playerBuffs.Count; i++)
			{
				jArray2.Add(value._playerBuffs[i]);
			}
			jArray.Add(jArray2);
		}
		else
		{
			jArray.Add(string.Empty);
		}
		jArray.Add(value._enemyWorld);
		if (value._enemyBuffs != null)
		{
			JArray jArray3 = new JArray();
			for (int j = 0; j < value._enemyBuffs.Count; j++)
			{
				jArray3.Add(value._enemyBuffs[j]);
			}
			jArray.Add(jArray3);
		}
		else
		{
			jArray.Add(string.Empty);
		}
		return jArray;
	}

	public static explicit operator WorldDuelData(JToken value)
	{
		if (value.Type != JTokenType.Array)
		{
			return null;
		}
		WorldDuelData worldDuelData = new WorldDuelData();
		worldDuelData._playerWorld = (int)value[0];
		if (value[1].Type == JTokenType.Array)
		{
			JArray jArray = (JArray)value[1];
			if (jArray.Count > 0)
			{
				worldDuelData._playerBuffs = new List<string>();
				for (int i = 0; i < jArray.Count; i++)
				{
					worldDuelData._playerBuffs.Add((string)jArray[i]);
				}
			}
		}
		worldDuelData._enemyWorld = (int)value[2];
		if (value[3].Type == JTokenType.Array)
		{
			JArray jArray2 = (JArray)value[3];
			if (jArray2.Count > 0)
			{
				worldDuelData._enemyBuffs = new List<string>();
				for (int j = 0; j < jArray2.Count; j++)
				{
					worldDuelData._enemyBuffs.Add((string)jArray2[j]);
				}
			}
		}
		return worldDuelData;
	}
}
