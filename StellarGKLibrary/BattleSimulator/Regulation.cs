using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using BattleSimulator.DataTables.DataRowTable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace StellarGKLibrary.BattleSimulator
{
    [JsonObject]
    [Serializable]
    public class Regulation
    {
        private Regulation()
        {
        }

        public static Regulation Create()
        {
            Regulation regulation = new();
            regulation.InitProperty();
            return regulation;
        }

        public double version { get; private set; }

        public DataTable<RewardDataRow> rewardDtbl { get; private set; }

        public DataTable<UserLevelDataRow> userLevelDtbl { get; private set; }

        public DataTable<PartDataRow> partDtbl { get; private set; }

        public DataTable<InteractionDataRow> interactionDtbl { get; private set; }

        public DataTable<GoodsDataRow> goodsDtbl { get; private set; }

        public DataTable<BuildingLevelDataRow> buildingLevelDtbl { get; private set; }

        public DataTable<CommanderDataRow> commanderDtbl { get; private set; }

        public DataTable<CommanderLevelDataRow> commanderLevelDtbl { get; private set; }

        public DataTable<CommanderRankDataRow> commanderRankDtbl { get; private set; }

        public DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl { get; private set; }

        public DataTable<CommanderClassDataRow> commanderClassDtbl { get; private set; }

        public DataTable<CommanderCostumeDataRow> commanderCostumeDtbl { get; private set; }

        public DataTable<CommanderGiftDataRow> commanderGiftDtbl { get; private set; }

        public DataTable<CommanderVoiceDataRow> commanderVoiceDtbl { get; private set; }

        public DataTable<FavorDataRow> favorDtbl { get; private set; }

        public DataTable<WorldMapDataRow> worldMapDtbl { get; private set; }

        public DataTable<WorldMapStageDataRow> worldMapStageDtbl { get; private set; }

        public DataTable<WorldMapStageTypeDataRow> worldMapStageTypeDtbl { get; private set; }

        public DataTable<EnemyCommanderDataRow> enemyCommanderDtbl { get; private set; }

        public DataTable<EnemyUnitDataRow> enemyUnitDtbl { get; private set; }

        public DataTable<FireActionDataRow> fireActionDtbl { get; private set; }

        public DataTable<UnitDataRow> unitDtbl { get; private set; }

        public DataTable<SkillDataRow> skillDtbl { get; private set; }

        public DataTable<SkillCostDataRow> skillCostDtbl { get; private set; }

        public DataTable<SkillUpgradeDataRow> skillUpgradeDtbl { get; private set; }

        public DataTable<ProjectileDataRow> projectileDtbl { get; private set; }

        public DataTable<StatusEffectDataRow> statusEffectDtbl { get; private set; }

        public DataTable<SkillDamagePatternDataRow> skillDamagePatternDtbl { get; private set; }

        public SkillDamagePatternTable skillDamagePattern
        {
            get
            {
                if (_skillDamagePattern == null)
                {
                    _skillDamagePattern = new SkillDamagePatternTable();
                    _skillDamagePattern.Init(this);
                }
                return _skillDamagePattern;
            }
        }

        public DataTable<UnitMotionDataRow> unitMotionDtbl { get; private set; }

        public DataTable<ProjectileMotionPhaseDataRow> projectileMotionPhaseDtbl { get; private set; }

        public DataTable<DailyBonusDataRow> dailyBonusDtbl { get; private set; }

        public DataTable<GachaDataRow> gachaDtbl { get; private set; }

        public DataTable<GachaRewardDataRow> gachaRewardDtbl { get; private set; }

        public DataTable<GachaCostDataRow> gachaCostDtbl { get; private set; }

        public DataTable<SweepDataRow> sweepDtbl { get; private set; }

        public DataTable<RaidDataRow> raidDtbl { get; private set; }

        public DataTable<RaidChallengeDataRow> raidChallengeDtbl { get; private set; }

        public DataTable<LevelPatternDataRow> levelPatternDtbl { get; private set; }

        public DataTable<ClassPatternDataRow> classPatternDtbl { get; private set; }

        public DataTable<DropGoldPatternDataRow> dropGoldPatternDtbl { get; private set; }

        public DataTable<MetroBankLuckDataRow> metroBankLuckDtbl { get; private set; }

        public DataTable<VipRechargeDataRow> vipRechargeDtbl { get; private set; }

        public DataTable<RankingRewardDataRow> rankingRewardDtbl { get; private set; }

        public DataTable<RankingDataRow> rankingDtbl { get; private set; }

        public DataTable<GuildSkillDataRow> guildSkillDtbl { get; private set; }

        public DataTable<GuildStruggleDataRow> guildStruggleDtbl { get; private set; }

        public DataTable<GuildLevelInfoDataRow> guildLevelInfoDtbl { get; private set; }

        public DataTable<GuildOccupyDataRow> guildOccupyDtbl { get; private set; }

        public DataTable<VipExpDataRow> vipExpDtbl { get; private set; }

        public DataTable<FavorStepDataRow> favorStepDtbl { get; private set; }

        public DataTable<ShopDataRow> shopDtbl { get; private set; }

        public DataTable<AlarmDataRow> reportDtbl { get; private set; }

        public DataTable<ThumbnailDataRow> thumbnailDtbl { get; private set; }

        public DataTable<ItemExchangeDataRow> itemExchangeDtbl { get; private set; }

        public DataTable<DailyEventDataRow> dailyEventDtbl { get; private set; }

        public DataTable<DefineDataRow> defineDtbl { get; private set; }

        public DataTable<LoadingTipDataRow> loadingTipDtbl { get; private set; }

        public DataTable<AnnihilateBattleDataRow> annihilateBattleDtbl { get; private set; }

        public DataTable<InAppProductDataRow> inAppProductDtbl { get; private set; }

        public DataTable<CarnivalDataRow> carnivalDtbl { get; private set; }

        public DataTable<CarnivalTypeDataRow> carnivalTypeDtbl { get; private set; }

        public DataTable<GroupInfoDataRow> groupInfoDtbl { get; private set; }

        public DataTable<GroupMemberDataRow> groupMemberDtbl { get; private set; }

        public DataTable<CommanderScenarioDataRow> commanderScenarioDtbl { get; private set; }

        public DataTable<ScenarioQuarterDataRow> scenarioQuarterDtbl { get; private set; }

        public DataTable<ScenarioBattleDataRow> scenarioBattleDtbl { get; private set; }

        public DataTable<ScenarioBattleUnitDataRow> scenarioBattleUnitDtbl { get; private set; }

        public DataTable<WaveBattleDataRow> waveBattleDtbl { get; private set; }

        public DataTable<EquipItemDataRow> equipItemDtbl { get; private set; }

        public DataTable<EquipItemUpgradeDataRow> equipItemUpgradeDtbl { get; private set; }

        public DataTable<EquipItemDisassembleDataRow> equipItemDisassembleDtbl { get; private set; }

        public DataTable<EventBattleDataRow> eventBattleDtbl { get; private set; }

        public DataTable<EventBattleFieldDataRow> eventBattleFieldDtbl { get; private set; }

        public DataTable<EventRaidDataRow> eventRaidDtbl { get; private set; }

        public DataTable<EventBattleScenarioDataRow> eventBattleScenarioDtbl { get; private set; }

        public DataTable<EventBattleGachaRewardDataRow> eventBattleGachaRewardDtbl { get; private set; }

        public DataTable<EventRemaingTimeDataRow> eventRemaingTimeDtbl { get; private set; }

        public DataTable<RandomBoxRewardDataRow> randomBoxRewardDtbl { get; private set; }

        [Table("battleFieldSearch")]
        public DataTable<ExplorationDataRow> explorationDtbl { get; private set; }

        public DataTable<DormitoryUpgradeDataRow> dormitoryUpgradeDtbl { get; private set; }

        public DataTable<DormitoryHeadCostumeDataRow> dormitoryHeadCostumeDtbl { get; private set; }

        public DataTable<DormitoryBodyCostumeDataRow> dormitoryBodyCostumeDtbl { get; private set; }

        public DataTable<DormitoryDecorationDataRow> dormitoryDecorationDtbl { get; private set; }

        public DataTable<DormitoryWallpaperDataRow> dormitoryWallPaperDtbl { get; private set; }

        public DataTable<DormitoryShopDataRow> dormitoryShopDtbl { get; private set; }

        public DataTable<DormitoryThemeDataRow> dormitoryThemeDtbl { get; private set; }

        public Dictionary<string, List<DormitoryHeadCostumeDataRow>> dormitoryHeadCostumeMap
        {
            get
            {
                if (_dormitoryHeadCostumeMap == null)
                {
                    _dormitoryHeadCostumeMap = new Dictionary<string, List<DormitoryHeadCostumeDataRow>>();
                    for (int i = 0; i < dormitoryHeadCostumeDtbl.length; i++)
                    {
                        string cid = dormitoryHeadCostumeDtbl[i].cid;
                        if (!_dormitoryHeadCostumeMap.ContainsKey(cid))
                        {
                            _dormitoryHeadCostumeMap.Add(cid, new List<DormitoryHeadCostumeDataRow>());
                        }
                        _dormitoryHeadCostumeMap[cid].Add(dormitoryHeadCostumeDtbl[i]);
                    }
                }
                return _dormitoryHeadCostumeMap;
            }
        }

        public Dictionary<string, List<DormitoryThemeDataRow>> dormitoryThemeMap
        {
            get
            {
                if (_dormitoryThemeMap == null)
                {
                    _dormitoryThemeMap = new Dictionary<string, List<DormitoryThemeDataRow>>();
                    for (int i = 0; i < dormitoryThemeDtbl.length; i++)
                    {
                        DormitoryThemeDataRow dormitoryThemeDataRow = dormitoryThemeDtbl[i];
                        if (!_dormitoryThemeMap.ContainsKey(dormitoryThemeDataRow.id))
                        {
                            _dormitoryThemeMap.Add(dormitoryThemeDataRow.id, new List<DormitoryThemeDataRow>());
                        }
                        _dormitoryThemeMap[dormitoryThemeDataRow.id].Add(dormitoryThemeDataRow);
                    }
                }
                return _dormitoryThemeMap;
            }
        }

        public DataTable<CooperateBattleDataRow> cooperateBattleDtbl { get; private set; }

        public DataTable<NPCMercenaryDataRow> npcMercenaryDtbl { get; private set; }

        public DataTable<InfinityFieldDataRow> infinityFieldDtbl { get; private set; }

        public Dictionary<int, List<CooperateBattleDataRow>> cooperateBattleStepDtbl
        {
            get
            {
                if (_cooperateBattleStepDtbl == null)
                {
                    _cooperateBattleStepDtbl = new Dictionary<int, List<CooperateBattleDataRow>>();
                    for (int i = 0; i < cooperateBattleDtbl.length; i++)
                    {
                        CooperateBattleDataRow cooperateBattleDataRow = cooperateBattleDtbl[i];
                        if (!_cooperateBattleStepDtbl.ContainsKey(cooperateBattleDataRow.step))
                        {
                            _cooperateBattleStepDtbl.Add(cooperateBattleDataRow.step, new List<CooperateBattleDataRow>());
                        }
                        _cooperateBattleStepDtbl[cooperateBattleDataRow.step].Add(cooperateBattleDataRow);
                    }
                }
                return _cooperateBattleStepDtbl;
            }
        }

        public DataTable<StrongestBuffBattleDataRow> strongestBuffBattleDtbl { get; private set; }

        public DataTable<WeaponDataRow> weaponDtbl { get; private set; }

        public DataTable<WeaponUpgradeDataRow> weaponUpgradeDtbl { get; private set; }

        public DataTable<WeaponSetDataRow> weaponSetDtbl { get; private set; }

        public DataTable<GoodsComposeDataRow> goodsComposeDtbl { get; private set; }

        public DataTable<TranscendenceSlotDataRow> transcendenceSlotDtbl { get; private set; }

        public DataTable<TranscendenceStepUpgradeDataRow> transcendenceStepUpgradeDtbl { get; private set; }

        public void InitProperty()
        {
            properties = new Dictionary<string, PropertyInfo>();
            Type type = GetType();
            string text = "Dtbl";
            PropertyInfo[] array = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Name.EndsWith(text))
                {
                    string text2 = string.Empty;
                    object[] customAttributes = array[i].GetCustomAttributes(typeof(TableAttribute), false);
                    if (customAttributes.Length != 0)
                    {
                        text2 = ((TableAttribute)customAttributes[0]).name;
                    }
                    else
                    {
                        text2 = array[i].Name.Replace(text, string.Empty);
                    }
                    properties.Add(text2, array[i]);
                }
            }
        }

        public bool HasTable(string name)
        {
            return properties.ContainsKey(name);
        }

        public void SetTable(string name, object obj)
        {
            properties[name].SetValue(this, obj, null);
        }

        public object SetTable(string name, string json)
        {
            object obj = JsonConvert.DeserializeObject(json, properties[name].PropertyType, SerializerSettings);
            SetTable(name, obj);
            return obj;
        }

        public object GetTable(string name)
        {
            return properties[name].GetValue(this, null);
        }

        [OnDeserialized]
        private void OnDeserialzed(StreamingContext context)
        {
        }

        public static void ExtendList<T>(ref List<T> list, int count)
        {
            if (list == null)
            {
                list = new List<T>();
            }
            for (int i = list.Count; i < count; i++)
            {
                list.Add(default);
            }
        }

        public static void FillList<T>(ref List<T> list, int count)
        {
            if (list == null)
            {
                list = new List<T>();
            }
            for (int i = list.Count; i < count; i++)
            {
                if (typeof(T) == typeof(string))
                {
                    (list as List<string>).Add(string.Empty);
                }
                else if (typeof(T).IsValueType)
                {
                    list.Add(default);
                }
                else
                {
                    list.Add((T)Activator.CreateInstance(typeof(T), true));
                }
            }
        }

        public static string[] GetTableNames()
        {
            string text = "Dtbl";
            Type typeFromHandle = typeof(Regulation);
            PropertyInfo[] array = typeFromHandle.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            List<string> list = new List<string>();
            foreach (PropertyInfo propertyInfo in array)
            {
                if (propertyInfo.Name.EndsWith(text))
                {
                    list.Add(propertyInfo.Name.Replace(text, string.Empty));
                }
            }
            return list.ToArray();
        }

        public void TestFromLocalResources(int dummyVersion = 1000000)
        {
            string text = "Regulation/";
            string[] tableNames = GetTableNames();
            List<string> list = new();
            foreach (string text2 in tableNames)
            {
                string text3 = text2.Substring(0, 1);
                string text4 = text + text3 + text2.Substring(1) + "DataTable";
                list.Add(text4);
            }
            version = dummyVersion;
        }

        public void SetFromLocalResources(string fileName, string json)
        {
            switch (fileName)
            {
                case "reward":
                    rewardDtbl = JsonConvert.DeserializeObject<DataTable<RewardDataRow>>(json, SerializerSettings);
                    break;
                case "userLevel":
                    userLevelDtbl = JsonConvert.DeserializeObject<DataTable<UserLevelDataRow>>(json, SerializerSettings);
                    break;
                case "part":
                    partDtbl = JsonConvert.DeserializeObject<DataTable<PartDataRow>>(json, SerializerSettings);
                    break;
                case "interaction":
                    interactionDtbl = JsonConvert.DeserializeObject<DataTable<InteractionDataRow>>(json, SerializerSettings);
                    break;
                case "goods":
                    goodsDtbl = JsonConvert.DeserializeObject<DataTable<GoodsDataRow>>(json, SerializerSettings);
                    break;
                case "buildingLevel":
                    buildingLevelDtbl = JsonConvert.DeserializeObject<DataTable<BuildingLevelDataRow>>(json, SerializerSettings);
                    break;
                case "commander":
                    commanderDtbl = JsonConvert.DeserializeObject<DataTable<CommanderDataRow>>(json, SerializerSettings);
                    break;
                case "commanderLevel":
                    commanderLevelDtbl = JsonConvert.DeserializeObject<DataTable<CommanderLevelDataRow>>(json, SerializerSettings);
                    break;
                case "commanderRank":
                    commanderRankDtbl = JsonConvert.DeserializeObject<DataTable<CommanderRankDataRow>>(json, SerializerSettings);
                    break;
                case "commanderTrainingTicket":
                    commanderTrainingTicketDtbl = JsonConvert.DeserializeObject<DataTable<CommanderTrainingTicketDataRow>>(json, SerializerSettings);
                    break;
                case "commanderClass":
                    commanderClassDtbl = JsonConvert.DeserializeObject<DataTable<CommanderClassDataRow>>(json, SerializerSettings);
                    break;
                case "commanderCostume":
                    commanderCostumeDtbl = JsonConvert.DeserializeObject<DataTable<CommanderCostumeDataRow>>(json, SerializerSettings);
                    break;
                case "commanderGift":
                    commanderGiftDtbl = JsonConvert.DeserializeObject<DataTable<CommanderGiftDataRow>>(json, SerializerSettings);
                    break;
                case "favor":
                    favorDtbl = JsonConvert.DeserializeObject<DataTable<FavorDataRow>>(json, SerializerSettings);
                    break;
                case "worldMap":
                    worldMapDtbl = JsonConvert.DeserializeObject<DataTable<WorldMapDataRow>>(json, SerializerSettings);
                    break;
                case "worldMapStage":
                    worldMapStageDtbl = JsonConvert.DeserializeObject<DataTable<WorldMapStageDataRow>>(json, SerializerSettings);
                    break;
                case "worldMapStageType":
                    worldMapStageTypeDtbl = JsonConvert.DeserializeObject<DataTable<WorldMapStageTypeDataRow>>(json, SerializerSettings);
                    break;
                case "enemyCommander":
                    enemyCommanderDtbl = JsonConvert.DeserializeObject<DataTable<EnemyCommanderDataRow>>(json, SerializerSettings);
                    break;
                case "enemyUnit":
                    enemyUnitDtbl = JsonConvert.DeserializeObject<DataTable<EnemyUnitDataRow>>(json, SerializerSettings);
                    break;
                case "unit":
                    unitDtbl = JsonConvert.DeserializeObject<DataTable<UnitDataRow>>(json, SerializerSettings);
                    break;
                case "skill":
                    skillDtbl = JsonConvert.DeserializeObject<DataTable<SkillDataRow>>(json, SerializerSettings);
                    break;
                case "skillCost":
                    skillCostDtbl = JsonConvert.DeserializeObject<DataTable<SkillCostDataRow>>(json, SerializerSettings);
                    break;
                case "skillUpgrade":
                    skillUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<SkillUpgradeDataRow>>(json, SerializerSettings);
                    break;
                case "projectile":
                    projectileDtbl = JsonConvert.DeserializeObject<DataTable<ProjectileDataRow>>(json, SerializerSettings);
                    break;
                case "statusEffect":
                    statusEffectDtbl = JsonConvert.DeserializeObject<DataTable<StatusEffectDataRow>>(json, SerializerSettings);
                    break;
                case "unitMotion":
                    unitMotionDtbl = JsonConvert.DeserializeObject<DataTable<UnitMotionDataRow>>(json, SerializerSettings);
                    break;
                case "projectileMotionPhase":
                    projectileMotionPhaseDtbl = JsonConvert.DeserializeObject<DataTable<ProjectileMotionPhaseDataRow>>(json, SerializerSettings);
                    break;
                case "dailyBonus":
                    dailyBonusDtbl = JsonConvert.DeserializeObject<DataTable<DailyBonusDataRow>>(json, SerializerSettings);
                    break;
                case "gacha":
                    gachaDtbl = JsonConvert.DeserializeObject<DataTable<GachaDataRow>>(json, SerializerSettings);
                    break;
                case "gachaReward":
                    gachaRewardDtbl = JsonConvert.DeserializeObject<DataTable<GachaRewardDataRow>>(json, SerializerSettings);
                    break;
                case "gachaCost":
                    gachaCostDtbl = JsonConvert.DeserializeObject<DataTable<GachaCostDataRow>>(json, SerializerSettings);
                    break;
                case "sweep":
                    sweepDtbl = JsonConvert.DeserializeObject<DataTable<SweepDataRow>>(json, SerializerSettings);
                    break;
                case "raid":
                    raidDtbl = JsonConvert.DeserializeObject<DataTable<RaidDataRow>>(json, SerializerSettings);
                    break;
                case "levelPattern":
                    levelPatternDtbl = JsonConvert.DeserializeObject<DataTable<LevelPatternDataRow>>(json, SerializerSettings);
                    break;
                case "classPattern":
                    classPatternDtbl = JsonConvert.DeserializeObject<DataTable<ClassPatternDataRow>>(json, SerializerSettings);
                    break;
                case "dropGoldPattern":
                    dropGoldPatternDtbl = JsonConvert.DeserializeObject<DataTable<DropGoldPatternDataRow>>(json, SerializerSettings);
                    break;
                case "metroBankLuck":
                    metroBankLuckDtbl = JsonConvert.DeserializeObject<DataTable<MetroBankLuckDataRow>>(json, SerializerSettings);
                    break;
                case "vipRecharge":
                    vipRechargeDtbl = JsonConvert.DeserializeObject<DataTable<VipRechargeDataRow>>(json, SerializerSettings);
                    break;
                case "rankingReward":
                    rankingRewardDtbl = JsonConvert.DeserializeObject<DataTable<RankingRewardDataRow>>(json, SerializerSettings);
                    break;
                case "ranking":
                    rankingDtbl = JsonConvert.DeserializeObject<DataTable<RankingDataRow>>(json, SerializerSettings);
                    break;
                case "guildSkill":
                    guildSkillDtbl = JsonConvert.DeserializeObject<DataTable<GuildSkillDataRow>>(json, SerializerSettings);
                    break;
                case "guildStruggle":
                    guildStruggleDtbl = JsonConvert.DeserializeObject<DataTable<GuildStruggleDataRow>>(json, SerializerSettings);
                    break;
                case "guildLevelInfo":
                    guildLevelInfoDtbl = JsonConvert.DeserializeObject<DataTable<GuildLevelInfoDataRow>>(json, SerializerSettings);
                    break;
                case "guildOccupy":
                    guildOccupyDtbl = JsonConvert.DeserializeObject<DataTable<GuildOccupyDataRow>>(json, SerializerSettings);
                    break;
                case "vipExp":
                    vipExpDtbl = JsonConvert.DeserializeObject<DataTable<VipExpDataRow>>(json, SerializerSettings);
                    break;
                case "favorStep":
                    favorStepDtbl = JsonConvert.DeserializeObject<DataTable<FavorStepDataRow>>(json, SerializerSettings);
                    break;
                case "shop":
                    shopDtbl = JsonConvert.DeserializeObject<DataTable<ShopDataRow>>(json, SerializerSettings);
                    break;
                case "report":
                    reportDtbl = JsonConvert.DeserializeObject<DataTable<AlarmDataRow>>(json, SerializerSettings);
                    break;
                case "thumbnail":
                    thumbnailDtbl = JsonConvert.DeserializeObject<DataTable<ThumbnailDataRow>>(json, SerializerSettings);
                    break;
                case "itemExchange":
                    itemExchangeDtbl = JsonConvert.DeserializeObject<DataTable<ItemExchangeDataRow>>(json, SerializerSettings);
                    break;
                case "dailyEvent":
                    dailyEventDtbl = JsonConvert.DeserializeObject<DataTable<DailyEventDataRow>>(json, SerializerSettings);
                    break;
                case "define":
                    defineDtbl = JsonConvert.DeserializeObject<DataTable<DefineDataRow>>(json, SerializerSettings);
                    break;
                case "fireAction":
                    fireActionDtbl = JsonConvert.DeserializeObject<DataTable<FireActionDataRow>>(json, SerializerSettings);
                    break;
                case "loadingTip":
                    loadingTipDtbl = JsonConvert.DeserializeObject<DataTable<LoadingTipDataRow>>(json, SerializerSettings);
                    break;
                case "annihilateBattle":
                    annihilateBattleDtbl = JsonConvert.DeserializeObject<DataTable<AnnihilateBattleDataRow>>(json, SerializerSettings);
                    break;
                case "inAppProduct":
                    inAppProductDtbl = JsonConvert.DeserializeObject<DataTable<InAppProductDataRow>>(json, SerializerSettings);
                    break;
                case "carnival":
                    carnivalDtbl = JsonConvert.DeserializeObject<DataTable<CarnivalDataRow>>(json, SerializerSettings);
                    break;
                case "carnivalType":
                    carnivalTypeDtbl = JsonConvert.DeserializeObject<DataTable<CarnivalTypeDataRow>>(json, SerializerSettings);
                    break;
                case "groupInfo":
                    groupInfoDtbl = JsonConvert.DeserializeObject<DataTable<GroupInfoDataRow>>(json, SerializerSettings);
                    break;
                case "groupMember":
                    groupMemberDtbl = JsonConvert.DeserializeObject<DataTable<GroupMemberDataRow>>(json, SerializerSettings);
                    break;
                case "raidChallenge":
                    raidChallengeDtbl = JsonConvert.DeserializeObject<DataTable<RaidChallengeDataRow>>(json, SerializerSettings);
                    break;
                case "commanderVoice":
                    commanderVoiceDtbl = JsonConvert.DeserializeObject<DataTable<CommanderVoiceDataRow>>(json, SerializerSettings);
                    break;
                case "commanderScenario":
                    commanderScenarioDtbl = JsonConvert.DeserializeObject<DataTable<CommanderScenarioDataRow>>(json, SerializerSettings);
                    break;
                case "scenarioQuarter":
                    scenarioQuarterDtbl = JsonConvert.DeserializeObject<DataTable<ScenarioQuarterDataRow>>(json, SerializerSettings);
                    break;
                case "scenarioBattle":
                    scenarioBattleDtbl = JsonConvert.DeserializeObject<DataTable<ScenarioBattleDataRow>>(json, SerializerSettings);
                    break;
                case "scenarioBattleUnit":
                    scenarioBattleUnitDtbl = JsonConvert.DeserializeObject<DataTable<ScenarioBattleUnitDataRow>>(json, SerializerSettings);
                    break;
                case "waveBattle":
                    waveBattleDtbl = JsonConvert.DeserializeObject<DataTable<WaveBattleDataRow>>(json, SerializerSettings);
                    break;
                case "equipItem":
                    equipItemDtbl = JsonConvert.DeserializeObject<DataTable<EquipItemDataRow>>(json, SerializerSettings);
                    break;
                case "equipItemUpgrade":
                    equipItemUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<EquipItemUpgradeDataRow>>(json, SerializerSettings);
                    break;
                case "equipItemDisassemble":
                    equipItemDisassembleDtbl = JsonConvert.DeserializeObject<DataTable<EquipItemDisassembleDataRow>>(json, SerializerSettings);
                    break;
                case "battleFieldSearch":
                    explorationDtbl = JsonConvert.DeserializeObject<DataTable<ExplorationDataRow>>(json, SerializerSettings);
                    break;
                case "cooperateBattle":
                    cooperateBattleDtbl = JsonConvert.DeserializeObject<DataTable<CooperateBattleDataRow>>(json, SerializerSettings);
                    break;
                case "eventBattle":
                    eventBattleDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleDataRow>>(json, SerializerSettings);
                    break;
                case "eventBattleField":
                    eventBattleFieldDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleFieldDataRow>>(json, SerializerSettings);
                    break;
                case "eventRaid":
                    eventRaidDtbl = JsonConvert.DeserializeObject<DataTable<EventRaidDataRow>>(json, SerializerSettings);
                    break;
                case "eventBattleScenario":
                    eventBattleScenarioDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleScenarioDataRow>>(json, SerializerSettings);
                    break;
                case "eventBattleGachaReward":
                    eventBattleGachaRewardDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleGachaRewardDataRow>>(json, SerializerSettings);
                    break;
                case "randomBoxReward":
                    randomBoxRewardDtbl = JsonConvert.DeserializeObject<DataTable<RandomBoxRewardDataRow>>(json, SerializerSettings);
                    break;
                case "skillDamagePattern":
                    skillDamagePatternDtbl = JsonConvert.DeserializeObject<DataTable<SkillDamagePatternDataRow>>(json, SerializerSettings);
                    break;
                case "eventRemaingTime":
                    eventRemaingTimeDtbl = JsonConvert.DeserializeObject<DataTable<EventRemaingTimeDataRow>>(json, SerializerSettings);
                    break;
                case "nPCMercenary":
                    npcMercenaryDtbl = JsonConvert.DeserializeObject<DataTable<NPCMercenaryDataRow>>(json, SerializerSettings);
                    break;
                case "transcendenceSlotDtbl":
                    transcendenceSlotDtbl = JsonConvert.DeserializeObject<DataTable<TranscendenceSlotDataRow>>(json, SerializerSettings);
                    break;
                case "transcendenceStepUpgradeDtbl":
                    transcendenceStepUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<TranscendenceStepUpgradeDataRow>>(json, SerializerSettings);
                    break;
                case "weapon":
                    weaponDtbl = JsonConvert.DeserializeObject<DataTable<WeaponDataRow>>(json, SerializerSettings);
                    break;
                case "weaponUpgrade":
                    weaponUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<WeaponUpgradeDataRow>>(json, SerializerSettings);
                    break;
                case "weaponSet":
                    weaponSetDtbl = JsonConvert.DeserializeObject<DataTable<WeaponSetDataRow>>(json, SerializerSettings);
                    break;
                case "goodsCompose":
                    goodsComposeDtbl = JsonConvert.DeserializeObject<DataTable<GoodsComposeDataRow>>(json, SerializerSettings);
                    break;
            }
        }

        public void SetVersion(double version)
        {
            version = version;
        }

        public static Regulation FromLocalResources(int dummyVersion = 1000000)
        {
            string text = "Regulation/";
            string[] tableNames = GetTableNames();
            List<string> list = new();
            foreach (string text2 in tableNames)
            {
                string text3 = text2.Substring(0, 1);
                string text4 = text + text3 + text2.Substring(1) + "DataTable";
                list.Add(text4);
            }
            JObject jobject = new()
            {
                { "version", dummyVersion }
            };
            for (int j = 0; j < tableNames.Length; j++)
            {
                string text5 = tableNames[j] + "Dtbl";
                string text6 = list[j];
                string text7 = RegulationFile[tableNames[j]];
                JArray jarray = JsonConvert.DeserializeObject<JArray>(text7, SerializerSettings);
                jobject.Add(text5, jarray);
            }
            return FromJson(jobject.ToString());
        }

        public static Regulation FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Regulation>(json, SerializerSettings);
        }

        public static bool ParseBool(string str)
        {
            bool flag = false;
            if (!bool.TryParse(str, out flag))
            {
                flag = str.ToUpper() == "Y";
            }
            return flag;
        }

        public static EBranch ParseEBranch(string str)
        {
            EBranch ebranch = EBranch.Undefined;
            try
            {
                ebranch = (EBranch)Enum.Parse(typeof(EBranch), str);
            }
            catch (Exception ex)
            {
                if (str == "L")
                {
                    ebranch = EBranch.Army;
                }
                else if (str == "S")
                {
                    ebranch = EBranch.Navy;
                }
            }
            return ebranch;
        }



        public CommanderCostumeDataRow FindCostumeData(int ctid)
        {
            return commanderCostumeDtbl.Find((row) => row.ctid == ctid);
        }




        public TranscendenceSlotDataRow FindTranscendenceSlot(int slot)
        {
            return transcendenceSlotDtbl.Find((row) => row.slot == slot);
        }


        public const int Rate100 = 10000;

        public const string DataTableSuffix = "Dtbl";

        public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            DefaultValueHandling = DefaultValueHandling.Include,
            NullValueHandling = NullValueHandling.Include,
            ContractResolver = new DefaultContractResolver
            {
                DefaultMembersSearchFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            }
        };

        private SkillDamagePatternTable _skillDamagePattern;

        private Dictionary<string, List<DormitoryHeadCostumeDataRow>> _dormitoryHeadCostumeMap;

        private Dictionary<string, List<DormitoryThemeDataRow>> _dormitoryThemeMap;

        private Dictionary<int, List<CooperateBattleDataRow>> _cooperateBattleStepDtbl;

        public List<Protocols.CashShopData> cashShopDtbl;

        protected Dictionary<string, PropertyInfo> properties;

        public static Dictionary<string, string> RegulationFile = new Dictionary<string, string>();

        [AttributeUsage(AttributeTargets.Property, Inherited = false)]
        public class TableAttribute : Attribute
        {
            public TableAttribute(string name)
            {
                name = name;
            }

            public string name { get; private set; }
        }
    }
}
