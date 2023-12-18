using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class InitState
{
    [JsonProperty("type")]
    internal int _battleType;

    [JsonProperty("stgn")]
    internal string _stageId;

    [JsonProperty("rdsd")]
    internal int _randomSeed;

    [JsonProperty("ltrp")]
    internal List<Troop> _lhsTroops;

    [JsonProperty("rtrp")]
    internal List<Troop> _rhsTroops;

    [JsonIgnore]
    internal long _rhsTroopsHealth;

    [JsonIgnore]
    internal long _rhsTroopsMaxHealth;

    [JsonIgnore]
    internal int _lhsUnitCount;

    [JsonIgnore]
    internal int _lhsAttackerCount;

    [JsonIgnore]
    internal int _lhsDefenderCount;

    [JsonIgnore]
    internal int _lhsSupporterCount;

    [JsonIgnore]
    internal int _lhsInitGrade2Count;

    [JsonIgnore]
    internal int _lhsInitGrade3Count;

    [JsonIgnore]
    internal int _lhsInitGrade4Count;

    [JsonIgnore]
    internal int _lhsInitGrade5Count;

    [JsonProperty("raid", NullValueHandling = NullValueHandling.Ignore)]
    internal RaidData _raidData;

    [JsonProperty("dual", NullValueHandling = NullValueHandling.Ignore)]
    internal DualData _dualData;

    [JsonProperty("wbttl", NullValueHandling = NullValueHandling.Ignore)]
    internal WaveBattleData _waveBattleData;

    [JsonProperty("bitm", NullValueHandling = NullValueHandling.Ignore)]
    internal List<string> _battleItemDrks;

    [JsonProperty("gskl", NullValueHandling = NullValueHandling.Ignore)]
    internal List<GuildSkillState> _guildSkills;

    [JsonProperty("grp")]
    internal List<string> _groupBuffs;

    public IList<Troop> lhsTroops => _lhsTroops.AsReadOnly();

    public IList<Troop> rhsTroops => _rhsTroops.AsReadOnly();

    public List<GuildSkillState> guildSkills => _guildSkills;

    public List<string> battleItemDrks => _battleItemDrks;

    public int randomSeed => _randomSeed;

    public EBattleType battleType => (EBattleType)_battleType;

    public string stageID => _stageId;

    public RaidData raidData => _raidData;

    public DualData dualData => _dualData;

    public long rhsTroopsHealth => _rhsTroopsHealth;

    public long rhsTroopsMaxHealth => _rhsTroopsMaxHealth;

    public WaveBattleData waveBattleData => _waveBattleData;

    internal InitState()
    {
    }

    public static InitState Create(EBattleType battleType, List<Troop> lhsTroops, List<Troop> rhsTroops, List<string> battleItemDrks, int randomSeed)
    {
        string text = "must not be empty.";
        if (lhsTroops == null || lhsTroops.Count == 0)
        {
            throw new ArgumentException("lhsTroops " + text);
        }
        if (rhsTroops == null || rhsTroops.Count == 0)
        {
            throw new ArgumentException("rhsTroops " + text);
        }
        InitState initState = new()
        {
            _battleType = (int)battleType,
            _lhsTroops = lhsTroops,
            _rhsTroops = rhsTroops,
            _rhsTroopsHealth = 0L,
            _rhsTroopsMaxHealth = 0L,
            _randomSeed = randomSeed,
            _battleItemDrks = battleItemDrks,
            _stageId = string.Empty
        };
        return initState;
    }

    public static InitState Copy(InitState src)
    {
        if (src == null)
        {
            throw new ArgumentNullException("src");
        }
        InitState initState = new()
        {
            _battleType = src._battleType,
            _lhsTroops = []
        };
        foreach (Troop lhsTroop in src._lhsTroops)
        {
            initState._lhsTroops.Add(Troop.Copy(lhsTroop));
        }
        initState._rhsTroops = [];
        foreach (Troop rhsTroop in src._rhsTroops)
        {
            initState._rhsTroops.Add(Troop.Copy(rhsTroop));
        }
        if (src._battleItemDrks != null)
        {
            initState._battleItemDrks = [];
            for (int i = 0; i < src._battleItemDrks.Count; i++)
            {
                initState._battleItemDrks.Add(src._battleItemDrks[i]);
            }
        }
        if (src._guildSkills != null)
        {
            initState._guildSkills = [];
            for (int j = 0; j < src._guildSkills.Count; j++)
            {
                initState._guildSkills.Add(GuildSkillState.Copy(src._guildSkills[j]));
            }
        }
        if (src._groupBuffs != null)
        {
            initState._groupBuffs = [];
            for (int k = 0; k < src._groupBuffs.Count; k++)
            {
                initState._groupBuffs.Add(src._groupBuffs[k]);
            }
        }
        initState._stageId = src._stageId;
        initState._raidData = RaidData.Copy(src.raidData);
        initState._dualData = DualData.Copy(src.dualData);
        initState._waveBattleData = WaveBattleData.Copy(src.waveBattleData);
        initState._randomSeed = src._randomSeed;
        initState._rhsTroopsHealth = src._rhsTroopsHealth;
        initState._rhsTroopsMaxHealth = src._rhsTroopsMaxHealth;
        return initState;
    }

    public static explicit operator JToken(InitState value)
    {
        JArray jArray = [value._battleType, value._stageId, value._randomSeed];
        JArray jArray2 = [];
        for (int i = 0; i < value._lhsTroops.Count; i++)
        {
            jArray2.Add((JToken)value._lhsTroops[i]);
        }
        jArray.Add(jArray2);
        JArray jArray3 = [];
        for (int j = 0; j < value._rhsTroops.Count; j++)
        {
            jArray3.Add((JToken)value._rhsTroops[j]);
        }
        jArray.Add(jArray3);
        if (value._battleType == 5)
        {
            jArray.Add((JToken)value._raidData);
        }
        else if (value._battleType == 6 || value._battleType == 12 || value._battleType == 17 || value._battleType == 13)
        {
            jArray.Add((JToken)value._dualData);
        }
        else if (value._battleType == 10)
        {
            jArray.Add((JToken)value._waveBattleData);
        }
        else
        {
            jArray.Add(string.Empty);
        }
        if (value._guildSkills != null)
        {
            JArray jArray4 = [];
            for (int k = 0; k < value._guildSkills.Count; k++)
            {
                jArray4.Add((JToken)value._guildSkills[k]);
            }
            jArray.Add(jArray4);
        }
        else
        {
            jArray.Add(string.Empty);
        }
        if (value._groupBuffs != null)
        {
            JArray jArray5 = [];
            for (int l = 0; l < value._groupBuffs.Count; l++)
            {
                jArray5.Add(value._groupBuffs[l]);
            }
            jArray.Add(jArray5);
        }
        else
        {
            jArray.Add(string.Empty);
        }
        return jArray;
    }

    public static explicit operator InitState(JToken value)
    {
        InitState initState = new()
        {
            _battleType = (int)value[0],
            _stageId = (string)value[1],
            _randomSeed = (int)value[2],
            _lhsTroops = new List<Troop>()
        };
        JArray jArray = (JArray)value[3];
        for (int i = 0; i < jArray.Count; i++)
        {
            initState._lhsTroops.Add((Troop)jArray[i]);
        }
        initState._rhsTroops = [];
        JArray jArray2 = (JArray)value[4];
        for (int j = 0; j < jArray2.Count; j++)
        {
            initState._rhsTroops.Add((Troop)jArray2[j]);
        }
        if (initState._battleType == 5)
        {
            initState._raidData = (RaidData)value[5];
        }
        else if (initState._battleType == 6 || initState._battleType == 12 || initState._battleType == 17 || initState._battleType == 13)
        {
            initState._dualData = (DualData)value[5];
        }
        else if (initState._battleType == 10)
        {
            initState._waveBattleData = (WaveBattleData)value[5];
        }
        if (value[6].Type == JTokenType.Array)
        {
            JArray jArray3 = (JArray)value[6];
            if (jArray3.Count > 0)
            {
                initState._guildSkills = new List<GuildSkillState>();
                for (int k = 0; k < jArray3.Count; k++)
                {
                    initState._guildSkills.Add((GuildSkillState)jArray3[k]);
                }
            }
        }
        if (value[7].Type == JTokenType.Array)
        {
            JArray jArray4 = (JArray)value[7];
            if (jArray4.Count > 0)
            {
                initState._groupBuffs = [];
                for (int l = 0; l < jArray4.Count; l++)
                {
                    initState._groupBuffs.Add((string)jArray4[l]);
                }
            }
        }
        return initState;
    }

    public static bool IsSame(InitState f1, InitState f2)
    {
        if (f1 == f2)
        {
            return true;
        }
        if (f1 == null || f2 == null)
        {
            return false;
        }
        if (f1.randomSeed != f2.randomSeed)
        {
            return false;
        }
        if (f1.battleItemDrks.Count != f2.battleItemDrks.Count)
        {
            return false;
        }
        if (f1.lhsTroops.Count != f2.lhsTroops.Count)
        {
            return false;
        }
        if (f1.rhsTroops.Count != f2.rhsTroops.Count)
        {
            return false;
        }
        for (int i = 0; i < f1.battleItemDrks.Count; i++)
        {
            if (!string.Equals(f1.battleItemDrks[i], f2.battleItemDrks[i]))
            {
                return false;
            }
        }
        for (int j = 0; j < f1.lhsTroops.Count; j++)
        {
            if (!Troop.IsSame(f1.lhsTroops[j], f2.lhsTroops[j]))
            {
                return false;
            }
        }
        for (int k = 0; k < f1.rhsTroops.Count; k++)
        {
            if (!Troop.IsSame(f1.rhsTroops[k], f2.rhsTroops[k]))
            {
                return false;
            }
        }
        return true;
    }
}