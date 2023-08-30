using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WorldDuelData
    {
        //public void Init(Regulation regulation)
        //{
        //	if (_init)
        //	{
        //		return;
        //	}
        //	plyerBuffs = InitBuffs(regulation, _playerBuffs, _enemyBuffs);
        //	enemyBuffs = InitBuffs(regulation, _enemyBuffs, _playerBuffs);
        //	_init = true;
        //}

        //private Dictionary<EWorldDuelBuff, int> InitBuffs(Regulation regulation, List<string> ownerBuffs, List<string> enemyBuffs)
        //{
        //	Dictionary<EWorldDuelBuff, int> dictionary = new Dictionary<EWorldDuelBuff, int>
        //	{
        //		{
        //			EWorldDuelBuff.att,
        //			0
        //		},
        //		{
        //			EWorldDuelBuff.def,
        //			0
        //		},
        //		{
        //			EWorldDuelBuff.sup,
        //			0
        //		}
        //	};
        //	for (int i = 0; i < ownerBuffs.Count; i++)
        //	{
        //		StrongestBuffBattleDataRow strongestBuffBattleDataRow = regulation.strongestBuffBattleDtbl[ownerBuffs[i]];
        //		if (strongestBuffBattleDataRow.buffEffectType == EWorldDuelBuffEffect.b)
        //		{
        //			Dictionary<EWorldDuelBuff, int> dictionary2;
        //			EWorldDuelBuff buffTarget;
        //			(dictionary2 = dictionary)[buffTarget = strongestBuffBattleDataRow.buffTarget] = dictionary2[buffTarget] + strongestBuffBattleDataRow.buffAdd;
        //		}
        //	}
        //	for (int j = 0; j < enemyBuffs.Count; j++)
        //	{
        //		StrongestBuffBattleDataRow strongestBuffBattleDataRow2 = regulation.strongestBuffBattleDtbl[enemyBuffs[j]];
        //		if (strongestBuffBattleDataRow2.buffEffectType == EWorldDuelBuffEffect.d)
        //		{
        //			Dictionary<EWorldDuelBuff, int> dictionary2;
        //			EWorldDuelBuff buffTarget2;
        //			(dictionary2 = dictionary)[buffTarget2 = strongestBuffBattleDataRow2.buffTarget] = dictionary2[buffTarget2] - strongestBuffBattleDataRow2.buffAdd;
        //		}
        //	}
        //	return dictionary;
        //}

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
            JArray jarray = new JArray();
            jarray.Add(value._playerWorld);
            if (value._playerBuffs != null)
            {
                JArray jarray2 = new JArray();
                for (int i = 0; i < value._playerBuffs.Count; i++)
                {
                    jarray2.Add(value._playerBuffs[i]);
                }
                jarray.Add(jarray2);
            }
            else
            {
                jarray.Add(string.Empty);
            }
            jarray.Add(value._enemyWorld);
            if (value._enemyBuffs != null)
            {
                JArray jarray3 = new JArray();
                for (int j = 0; j < value._enemyBuffs.Count; j++)
                {
                    jarray3.Add(value._enemyBuffs[j]);
                }
                jarray.Add(jarray3);
            }
            else
            {
                jarray.Add(string.Empty);
            }
            return jarray;
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
                JArray jarray = (JArray)value[1];
                if (jarray.Count > 0)
                {
                    worldDuelData._playerBuffs = new List<string>();
                    for (int i = 0; i < jarray.Count; i++)
                    {
                        worldDuelData._playerBuffs.Add((string)jarray[i]);
                    }
                }
            }
            worldDuelData._enemyWorld = (int)value[2];
            if (value[3].Type == JTokenType.Array)
            {
                JArray jarray2 = (JArray)value[3];
                if (jarray2.Count > 0)
                {
                    worldDuelData._enemyBuffs = new List<string>();
                    for (int j = 0; j < jarray2.Count; j++)
                    {
                        worldDuelData._enemyBuffs.Add((string)jarray2[j]);
                    }
                }
            }
            return worldDuelData;
        }

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
    }
}
