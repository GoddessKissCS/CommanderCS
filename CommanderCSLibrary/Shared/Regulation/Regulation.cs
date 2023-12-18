using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class Regulation
    {
        [AttributeUsage(AttributeTargets.Property, Inherited = false)]
        public class TableAttribute : Attribute
        {
            public string name { get; private set; }

            public TableAttribute(string name)
            {
                this.name = name;
            }
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
                DefaultMembersSearchFlags = (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            }
        };

        private SkillDamagePatternTable _skillDamagePattern;

        private Dictionary<string, List<DormitoryHeadCostumeDataRow>> _dormitoryHeadCostumeMap;

        private Dictionary<string, List<DormitoryThemeDataRow>> _dormitoryThemeMap;

        private Dictionary<int, List<CooperateBattleDataRow>> _cooperateBattleStepDtbl;

        public List<Protocols.CashShopData> cashShopDtbl;

        protected Dictionary<string, PropertyInfo> properties;

        public static Dictionary<string, string> RegulationFile = new Dictionary<string, string>();

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

        private Regulation()
        {
        }

        public static Regulation Create()
        {
            Regulation regulation = new();
            regulation.Init();
            return regulation;
        }

        public string LoadJson(string filename)
        {
            return File.ReadAllText($"Resources\\ExcelOutputAsset\\{filename}");
        }

#pragma warning disable CS8601 // Possible null reference assignment.
        public void Init()
        {

            rewardDtbl = JsonConvert.DeserializeObject<DataTable<RewardDataRow>>(LoadJson("RewardDataTable.json"), SerializerSettings);
            userLevelDtbl = JsonConvert.DeserializeObject<DataTable<UserLevelDataRow>>(LoadJson("UserLevelDataTable.json"), SerializerSettings);
            partDtbl = JsonConvert.DeserializeObject<DataTable<PartDataRow>>(LoadJson("PartDataTable.json"), SerializerSettings);
            interactionDtbl = JsonConvert.DeserializeObject<DataTable<InteractionDataRow>>(LoadJson("InteractionDataTable.json"), SerializerSettings);
            goodsDtbl = JsonConvert.DeserializeObject<DataTable<GoodsDataRow>>(LoadJson("GoodsDataTable.json"), SerializerSettings);
            buildingLevelDtbl = JsonConvert.DeserializeObject<DataTable<BuildingLevelDataRow>>(LoadJson("BuildingLevelDataTable.json"), SerializerSettings);
            commanderDtbl = JsonConvert.DeserializeObject<DataTable<CommanderDataRow>>(LoadJson("CommanderDataTable.json"), SerializerSettings);
            commanderLevelDtbl = JsonConvert.DeserializeObject<DataTable<CommanderLevelDataRow>>(LoadJson("CommanderLevelDataTable.json"), SerializerSettings);
            commanderRankDtbl = JsonConvert.DeserializeObject<DataTable<CommanderRankDataRow>>(LoadJson("CommanderRankDataTable.json"), SerializerSettings);
            commanderTrainingTicketDtbl = JsonConvert.DeserializeObject<DataTable<CommanderTrainingTicketDataRow>>(LoadJson("CommanderTrainingTicketDataTable.json"), SerializerSettings);
            commanderClassDtbl = JsonConvert.DeserializeObject<DataTable<CommanderClassDataRow>>(LoadJson("CommanderClassDataTable.json"), SerializerSettings);
            commanderCostumeDtbl = JsonConvert.DeserializeObject<DataTable<CommanderCostumeDataRow>>(LoadJson("CommanderCostumeDataTable.json"), SerializerSettings);
            commanderGiftDtbl = JsonConvert.DeserializeObject<DataTable<CommanderGiftDataRow>>(LoadJson("CommanderGiftDataTable.json"), SerializerSettings);
            favorDtbl = JsonConvert.DeserializeObject<DataTable<FavorDataRow>>(LoadJson("FavorDataTable.json"), SerializerSettings);
            worldMapDtbl = JsonConvert.DeserializeObject<DataTable<WorldMapDataRow>>(LoadJson("WorldMapDataTable.json"), SerializerSettings);
            worldMapStageDtbl = JsonConvert.DeserializeObject<DataTable<WorldMapStageDataRow>>(LoadJson("WorldMapStageDataTable.json"), SerializerSettings);
            worldMapStageTypeDtbl = JsonConvert.DeserializeObject<DataTable<WorldMapStageTypeDataRow>>(LoadJson("WorldMapStageTypeDataTable.json"), SerializerSettings);
            enemyCommanderDtbl = JsonConvert.DeserializeObject<DataTable<EnemyCommanderDataRow>>(LoadJson("EnemyCommanderDataTable.json"), SerializerSettings);
            enemyUnitDtbl = JsonConvert.DeserializeObject<DataTable<EnemyUnitDataRow>>(LoadJson("EnemyUnitDataTable.json"), SerializerSettings);
            unitDtbl = JsonConvert.DeserializeObject<DataTable<UnitDataRow>>(LoadJson("UnitDataTable.json"), SerializerSettings);
            skillDtbl = JsonConvert.DeserializeObject<DataTable<SkillDataRow>>(LoadJson("SkillDataTable.json"), SerializerSettings);
            skillCostDtbl = JsonConvert.DeserializeObject<DataTable<SkillCostDataRow>>(LoadJson("SkillCostDataTable.json"), SerializerSettings);
            skillUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<SkillUpgradeDataRow>>(LoadJson("SkillUpgradeDataTable.json"), SerializerSettings);
            projectileDtbl = JsonConvert.DeserializeObject<DataTable<ProjectileDataRow>>(LoadJson("ProjectileDataTable.json"), SerializerSettings);
            statusEffectDtbl = JsonConvert.DeserializeObject<DataTable<StatusEffectDataRow>>(LoadJson("StatusEffectDataTable.json"), SerializerSettings);
            unitMotionDtbl = JsonConvert.DeserializeObject<DataTable<UnitMotionDataRow>>(LoadJson("UnitMotionDataTable.json"), SerializerSettings);
            projectileMotionPhaseDtbl = JsonConvert.DeserializeObject<DataTable<ProjectileMotionPhaseDataRow>>(LoadJson("ProjectileMotionPhaseDataTable.json"), SerializerSettings);
            dailyBonusDtbl = JsonConvert.DeserializeObject<DataTable<DailyBonusDataRow>>(LoadJson("DailyBonusDataTable.json"), SerializerSettings);
            gachaDtbl = JsonConvert.DeserializeObject<DataTable<GachaDataRow>>(LoadJson("GachaDataTable.json"), SerializerSettings);
            gachaRewardDtbl = JsonConvert.DeserializeObject<DataTable<GachaRewardDataRow>>(LoadJson("GachaRewardDataTable.json"), SerializerSettings);
            gachaCostDtbl = JsonConvert.DeserializeObject<DataTable<GachaCostDataRow>>(LoadJson("GachaCostDataTable.json"), SerializerSettings);
            sweepDtbl = JsonConvert.DeserializeObject<DataTable<SweepDataRow>>(LoadJson("SweepDataTable.json"), SerializerSettings);
            raidDtbl = JsonConvert.DeserializeObject<DataTable<RaidDataRow>>(LoadJson("RaidDataTable.json"), SerializerSettings);
            levelPatternDtbl = JsonConvert.DeserializeObject<DataTable<LevelPatternDataRow>>(LoadJson("LevelPatternDataTable.json"), SerializerSettings);
            classPatternDtbl = JsonConvert.DeserializeObject<DataTable<ClassPatternDataRow>>(LoadJson("ClassPatternDataTable.json"), SerializerSettings);
            dropGoldPatternDtbl = JsonConvert.DeserializeObject<DataTable<DropGoldPatternDataRow>>(LoadJson("DropGoldPatternDataTable.json"), SerializerSettings);
            metroBankLuckDtbl = JsonConvert.DeserializeObject<DataTable<MetroBankLuckDataRow>>(LoadJson("MetroBankLuckDataTable.json"), SerializerSettings);
            vipRechargeDtbl = JsonConvert.DeserializeObject<DataTable<VipRechargeDataRow>>(LoadJson("VipRechargeDataTable.json"), SerializerSettings);
            rankingRewardDtbl = JsonConvert.DeserializeObject<DataTable<RankingRewardDataRow>>(LoadJson("RankingRewardDataTable.json"), SerializerSettings);
            rankingDtbl = JsonConvert.DeserializeObject<DataTable<RankingDataRow>>(LoadJson("RankingDataTable.json"), SerializerSettings);
            guildSkillDtbl = JsonConvert.DeserializeObject<DataTable<GuildSkillDataRow>>(LoadJson("GuildSkillDataTable.json"), SerializerSettings);
            guildStruggleDtbl = JsonConvert.DeserializeObject<DataTable<GuildStruggleDataRow>>(LoadJson("GuildStruggleDataTable.json"), SerializerSettings);
            guildLevelInfoDtbl = JsonConvert.DeserializeObject<DataTable<GuildLevelInfoDataRow>>(LoadJson("GuildLevelInfoDataTable.json"), SerializerSettings);
            guildOccupyDtbl = JsonConvert.DeserializeObject<DataTable<GuildOccupyDataRow>>(LoadJson("GuildOccupyDataTable.json"), SerializerSettings);
            vipExpDtbl = JsonConvert.DeserializeObject<DataTable<VipExpDataRow>>(LoadJson("VipExpDataTable.json"), SerializerSettings);
            favorStepDtbl = JsonConvert.DeserializeObject<DataTable<FavorStepDataRow>>(LoadJson("FavorStepDataTable.json"), SerializerSettings);
            shopDtbl = JsonConvert.DeserializeObject<DataTable<ShopDataRow>>(LoadJson("ShopDataTable.json"), SerializerSettings);
            thumbnailDtbl = JsonConvert.DeserializeObject<DataTable<ThumbnailDataRow>>(LoadJson("ThumbnailDataTable.json"), SerializerSettings);
            itemExchangeDtbl = JsonConvert.DeserializeObject<DataTable<ItemExchangeDataRow>>(LoadJson("ItemExchangeDataTable.json"), SerializerSettings);
            dailyEventDtbl = JsonConvert.DeserializeObject<DataTable<DailyEventDataRow>>(LoadJson("DailyEventDataTable.json"), SerializerSettings);
            //defineDtbl = JsonConvert.DeserializeObject<DataTable<DefineDataRow>>(LoadJson(""),SerializerSettings);
            fireActionDtbl = JsonConvert.DeserializeObject<DataTable<FireActionDataRow>>(LoadJson("FireActionDataTable.json"), SerializerSettings);
            //loadingTipDtbl = JsonConvert.DeserializeObject<DataTable<LoadingTipDataRow>>(LoadJson(""),SerializerSettings);
            annihilateBattleDtbl = JsonConvert.DeserializeObject<DataTable<AnnihilateBattleDataRow>>(LoadJson("AnnihilateBattleDataTable.json"), SerializerSettings);
            inAppProductDtbl = JsonConvert.DeserializeObject<DataTable<InAppProductDataRow>>(LoadJson("InAppProductDataTable.json"), SerializerSettings);
            carnivalDtbl = JsonConvert.DeserializeObject<DataTable<CarnivalDataRow>>(LoadJson("CarnivalDataTable.json"), SerializerSettings);
            carnivalTypeDtbl = JsonConvert.DeserializeObject<DataTable<CarnivalTypeDataRow>>(LoadJson("CarnivalTypeDataTable.json"), SerializerSettings);
            groupInfoDtbl = JsonConvert.DeserializeObject<DataTable<GroupInfoDataRow>>(LoadJson("GroupInfoDataTable.json"), SerializerSettings);
            groupMemberDtbl = JsonConvert.DeserializeObject<DataTable<GroupMemberDataRow>>(LoadJson("GroupMemberDataTable.json"), SerializerSettings);
            raidChallengeDtbl = JsonConvert.DeserializeObject<DataTable<RaidChallengeDataRow>>(LoadJson("RaidChallengeDataTable.json"), SerializerSettings);
            //commanderVoiceDtbl = JsonConvert.DeserializeObject<DataTable<CommanderVoiceDataRow>>(LoadJson("CommanderVoiceDataTable.json"),SerializerSettings);
            commanderScenarioDtbl = JsonConvert.DeserializeObject<DataTable<CommanderScenarioDataRow>>(LoadJson("CommanderScenarioDataTable.json"), SerializerSettings);
            scenarioQuarterDtbl = JsonConvert.DeserializeObject<DataTable<ScenarioQuarterDataRow>>(LoadJson("ScenarioQuarterDataTable.json"), SerializerSettings);
            scenarioBattleDtbl = JsonConvert.DeserializeObject<DataTable<ScenarioBattleDataRow>>(LoadJson("ScenarioBattleDataTable.json"), SerializerSettings);
            //  scenarioBattleUnitDtbl = JsonConvert.DeserializeObject<DataTable<ScenarioBattleUnitDataRow>>(LoadJson("ScenarioBattleUnitData.json"),SerializerSettings);
            waveBattleDtbl = JsonConvert.DeserializeObject<DataTable<WaveBattleDataRow>>(LoadJson("WaveBattleDataTable.json"), SerializerSettings);
            equipItemDtbl = JsonConvert.DeserializeObject<DataTable<EquipItemDataRow>>(LoadJson("EquipItemDataTable.json"), SerializerSettings);
            equipItemUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<EquipItemUpgradeDataRow>>(LoadJson("EquipItemUpgradeDataTable.json"), SerializerSettings);
            equipItemDisassembleDtbl = JsonConvert.DeserializeObject<DataTable<EquipItemDisassembleDataRow>>(LoadJson("EquipItemDisassembleDataTable.json"), SerializerSettings);
            explorationDtbl = JsonConvert.DeserializeObject<DataTable<ExplorationDataRow>>(LoadJson("BattleFieldSearchDataTable.json"), SerializerSettings);
            cooperateBattleDtbl = JsonConvert.DeserializeObject<DataTable<CooperateBattleDataRow>>(LoadJson("CooperateBattleDataTable.json"), SerializerSettings);
            eventBattleDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleDataRow>>(LoadJson("EventBattleDataTable.json"), SerializerSettings);
            eventBattleFieldDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleFieldDataRow>>(LoadJson("EventBattleFieldDataTable.json"), SerializerSettings);
            eventRaidDtbl = JsonConvert.DeserializeObject<DataTable<EventRaidDataRow>>(LoadJson("EventRaidDataTable.json"), SerializerSettings);
            eventBattleScenarioDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleScenarioDataRow>>(LoadJson("EventBattleScenarioDataTable.json"), SerializerSettings);
            eventBattleGachaRewardDtbl = JsonConvert.DeserializeObject<DataTable<EventBattleGachaRewardDataRow>>(LoadJson("EventBattleGachaRewardDataTable.json"), SerializerSettings);
            randomBoxRewardDtbl = JsonConvert.DeserializeObject<DataTable<RandomBoxRewardDataRow>>(LoadJson("RandomBoxRewardDataTable.json"), SerializerSettings);
            skillDamagePatternDtbl = JsonConvert.DeserializeObject<DataTable<SkillDamagePatternDataRow>>(LoadJson("SkillDamagePatternDataTable.json"), SerializerSettings);
            eventRemaingTimeDtbl = JsonConvert.DeserializeObject<DataTable<EventRemaingTimeDataRow>>(LoadJson("EventRemaingTimeDataTable.json"), SerializerSettings);
            npcMercenaryDtbl = JsonConvert.DeserializeObject<DataTable<NPCMercenaryDataRow>>(LoadJson("NPCMercenaryDataTable.json"), SerializerSettings);
            transcendenceSlotDtbl = JsonConvert.DeserializeObject<DataTable<TranscendenceSlotDataRow>>(LoadJson("TranscendenceSlotDataTable.json"), SerializerSettings);
            transcendenceStepUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<TranscendenceStepUpgradeDataRow>>(LoadJson("TranscendenceStepUpgradeDataTable.json"), SerializerSettings);
            weaponDtbl = JsonConvert.DeserializeObject<DataTable<WeaponDataRow>>(LoadJson("WeaponDataTable.json"), SerializerSettings);
            weaponUpgradeDtbl = JsonConvert.DeserializeObject<DataTable<WeaponUpgradeDataRow>>(LoadJson("WeaponUpgradeDataTable.json"), SerializerSettings);
            weaponSetDtbl = JsonConvert.DeserializeObject<DataTable<WeaponSetDataRow>>(LoadJson("WeaponSetDataTable.json"), SerializerSettings);
            goodsComposeDtbl = JsonConvert.DeserializeObject<DataTable<GoodsComposeDataRow>>(LoadJson("GoodsComposeDataTable.json"), SerializerSettings);
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public static void ExtendList<T>(ref List<T> list, int count)
        {
            if (list == null)
            {
                list = new List<T>();
            }
            for (int i = list.Count; i < count; i++)
            {
                list.Add(default(T));
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
                    list.Add(default(T));
                }
                else
                {
                    list.Add((T)Activator.CreateInstance(typeof(T), nonPublic: true));
                }
            }
        }

        public static bool ParseBool(string str)
        {
            bool result = false;
            if (!bool.TryParse(str, out result))
            {
                result = str.ToUpper() == "Y";
            }
            return result;
        }

        public static EBranch ParseEBranch(string str)
        {
            EBranch result = EBranch.Undefined;
            try
            {
                result = (EBranch)System.Enum.Parse(typeof(EBranch), str);
            }
            catch (Exception)
            {
                if (str == "L")
                {
                    result = EBranch.Army;
                }
                else if (str == "S")
                {
                    result = EBranch.Navy;
                }
            }
            return result;
        }

        public List<string> GetCommanderIdList(EBranch branch, bool isNpc)
        {
            List<string> list = [];
            commanderDtbl.ForEach(delegate (CommanderDataRow row)
            {
                if (unitDtbl[row.unitId].branch == branch || branch == EBranch.Undefined)
                {
                    list.Add(row.id);
                }
            });
            return list;
        }

        public List<CommanderDataRow> GetCommanderList(EBranch branch, bool isNpc)
        {
            List<CommanderDataRow> list = [];
            commanderDtbl.ForEach(delegate (CommanderDataRow row)
            {
                if (unitDtbl[row.unitId].branch == branch || branch == EBranch.Undefined)
                {
                    list.Add(row);
                }
            });
            return list;
        }

        public List<CommanderDataRow> GetCommanderList(ECommanderType type)
        {
            List<CommanderDataRow> list = new List<CommanderDataRow>();
            commanderDtbl.ForEach(delegate (CommanderDataRow row)
            {
                if (row.C_Type == type)
                {
                    list.Add(row);
                }
            });
            return list;
        }

        public CommanderDataRow GetCommanderByUnitId(string unitId)
        {
            return commanderDtbl.Find((CommanderDataRow row) => row.unitId == unitId);
        }
        public CommanderDataRow GetCommander(string commanderId)
        {
            return commanderDtbl.Find((CommanderDataRow row) => row.id == commanderId);
        }

        public CommanderDataRow GetCommanderByResourceId(string resourceId)
        {
            return commanderDtbl.Find((CommanderDataRow row) => row.resourceId == resourceId);
        }

        public List<CommanderTrainingTicketDataRow> GetTrainingTicketList()
        {
            return commanderTrainingTicketDtbl.FindAll((CommanderTrainingTicketDataRow row) => true);
        }

        public List<SkillDataRow> GetSkillList()
        {
            return skillDtbl.FindAll((SkillDataRow row) => true);
        }

        public int GetSkillMaxLevel(int index, int unitLevel)
        {
            int max = 1;
            skillCostDtbl.ForEach(delegate (SkillCostDataRow row)
            {
                if (row.typeLimitLevel[index] == unitLevel)
                {
                    max = row.level + 1;
                }
            });
            return max;
        }

        public List<UnitDataRow> GetUnitList(EBranch branch, bool includeHidden)
        {
            return unitDtbl.FindAll((UnitDataRow row) => (branch == EBranch.Undefined || branch == row.branch) && (!row.isHidden || (includeHidden && row.isHidden)));
        }

        public CommanderLevelDataRow GetCommanderLevelDataRow(int level)
        {
            if (!commanderLevelDtbl.ContainsKey(level))
            {
                return null;
            }
            return commanderLevelDtbl[level.ToString()];
        }

        public CommanderRankDataRow GetCommanderRankDataRow(int rank)
        {
            if (!commanderRankDtbl.ContainsKey(rank))
            {
                return null;
            }
            return commanderRankDtbl[rank.ToString()];
        }

        public GoodsDataRow FindGoodsServerFieldName(string id)
        {
            return goodsDtbl.Find((GoodsDataRow row) => row.type == id);
        }

        public List<SweepDataRow> FindSweepRow(int type)
        {
            return sweepDtbl.FindAll((SweepDataRow row) => row.type == type);
        }

        public SweepDataRow FindSweepRow(int type, int level)
        {
            return sweepDtbl.Find((SweepDataRow row) => row.type == type && row.level == level);
        }

        public List<GachaRewardDataRow> FindGachaRewardList(string gachaType)
        {
            return gachaRewardDtbl.FindAll((GachaRewardDataRow row) => row.gachaType == gachaType);
        }

        public UserLevelDataRow GetUserLevelDataRow(int level)
        {
            if (!userLevelDtbl.ContainsKey(level))
            {
                return null;
            }
            return userLevelDtbl[level.ToString()];
        }

        public GoodsDataRow FindGoodsByServerFieldName(string fieldName)
        {
            return goodsDtbl.Find((GoodsDataRow row) => row.serverFieldName == fieldName);
        }

        public GoodsDataRow FindGoodsServerFieldName(int id)
        {
            return goodsDtbl.Find((GoodsDataRow row) => row.type == id.ToString());
        }

        public GachaCostDataRow FindGachaCost(string gachaType, int count)
        {
            return gachaCostDtbl.Find((GachaCostDataRow row) => row.type == gachaType && row.count == count);
        }

        public CommanderTrainingTicketDataRow FindCommanderTrainingTicketData(ETrainingTicketType Type)
        {
            return commanderTrainingTicketDtbl.Find((CommanderTrainingTicketDataRow row) => row.type == Type);
        }

        public CommanderRankDataRow FindCommanderRankData(int rank)
        {
            return commanderRankDtbl.Find((CommanderRankDataRow row) => row.rank == rank);
        }

        public List<BuildingLevelDataRow> GetOpenBuildingDataList()
        {
            return buildingLevelDtbl.FindAll((BuildingLevelDataRow row) => row.type != EBuilding.Headquarters);
        }

        public List<int> FindMetroBankLuckList()
        {
            List<int> list = new List<int>();
            metroBankLuckDtbl.ForEach(delegate (MetroBankLuckDataRow row)
            {
                if (int.Parse(row.Luck) < 100)
                {
                    list.Add(int.Parse(row.Luck));
                }
            });
            return list;
        }

        public int GetMetroBankCost(int start, int count = 1)
        {
            VipRechargeDataRow vipRechargeDataRow = FindVipRechargeData(EVipRechargeType.metroBank);
            int num = 0;
            int num2 = start + count;
            for (int i = start; i < num2; i++)
            {
                num += vipRechargeDataRow.startRechargePrice * (int)MathF.Pow(vipRechargeDataRow.priceAddPercent / 100, MathF.Floor(i / vipRechargeDataRow.numberMeasure));
            }
            return num;
        }

        public int GetMetroBankMaxRecharge(int count)
        {
            VipRechargeDataRow vipRechargeDataRow = FindVipRechargeData(EVipRechargeType.metroBank);
            return vipRechargeDataRow.startRecharge + count / vipRechargeDataRow.vipMeasure * vipRechargeDataRow.rechargeAddPoint;
        }

        public List<int> FindRaidDataIndexList(int raidId)
        {
            List<int> list = new List<int>();
            string key = $"{raidId}_{1}";
            int num = raidDtbl.FindIndex(key);
            if (num >= 0)
            {
                for (int i = num; i < raidDtbl.length; i++)
                {
                    if (raidDtbl[i].key == raidId)
                    {
                        list.Add(i);
                    }
                }
            }
            return list;
        }

        public PartDataRow FindPartData(string partType)
        {
            return partDtbl.Find((PartDataRow row) => row.type == partType);
        }

        public InteractionDataRow FindInteractionData(string id, InteractionType type, int count)
        {
            return interactionDtbl.Find((InteractionDataRow row) => row.resourceId == id && row.type == type && row.count == count);
        }

        public List<InteractionDataRow> FindInteractionData(string id, InteractionType type)
        {
            return interactionDtbl.FindAll((InteractionDataRow row) => row.resourceId == id && row.type == type);
        }

        public List<InteractionDataRow> FindVoiceInteractionData(string id)
        {
            return interactionDtbl.FindAll((InteractionDataRow row) => row.resourceId == id && row.type < InteractionType.DATE_HEAD_FAVOR1);
        }

        public InteractionDataRow FindInteractionData(string id, int idx)
        {
            return interactionDtbl.Find((InteractionDataRow row) => row.resourceId == id && row.favorup == idx);
        }

        public List<RankingDataRow> FindDuelRankingList(ERankingContentsType type)
        {
            return rankingDtbl.FindAll((RankingDataRow row) => row.type == type);
        }

        public List<RewardDataRow> FindDuelRankingRewardList(int type, int typeIdx)
        {
            return rewardDtbl.FindAll((RewardDataRow row) => row.category == ERewardCategory.Ranking && row.type == type && row.typeIndex == typeIdx && row.rewardType != ERewardType.Costume);
        }

        public GuildSkillDataRow FindGuildSkillData(int idx, int level)
        {
            return guildSkillDtbl.Find((GuildSkillDataRow row) => row.idx == idx && row.level == level);
        }

        public List<GuildSkillDataRow> FindGuildSkillDataLevel(int level)
        {
            return guildSkillDtbl.FindAll((GuildSkillDataRow row) => row.level == level);
        }

        public GuildLevelInfoDataRow FindGuildLevelInfoData(int level)
        {
            return guildLevelInfoDtbl.Find((GuildLevelInfoDataRow row) => row.level == level);
        }

        public VipExpDataRow FindVipExpData(int idx)
        {
            return vipExpDtbl.Find((VipExpDataRow row) => row.Idx == idx);
        }

        public VipRechargeDataRow FindVipRechargeData(EVipRechargeType type)
        {
            return vipRechargeDtbl.Find(delegate (VipRechargeDataRow row)
            {
                string idx = row.idx;
                int num = (int)type;
                return idx == num.ToString();
            });
        }

        public FavorStepDataRow FindFavorStepData(int step)
        {
            return favorStepDtbl.Find((FavorStepDataRow row) => row.step == step);
        }

        public ItemExchangeDataRow FindExchangeItemData(EStorageType type, string idx)
        {
            return itemExchangeDtbl.Find((ItemExchangeDataRow row) => row.type == type && row.typeidx == idx);
        }

        public CommanderClassDataRow FindCommandClassData(int cidx, int cls)
        {
            return commanderClassDtbl.Find((CommanderClassDataRow row) => row.index == cidx && row.cls == cls);
        }

        public List<CommanderCostumeDataRow> FindCommandCostumeData(string cid)
        {
            return commanderCostumeDtbl.FindAll((CommanderCostumeDataRow row) => row.cid == int.Parse(cid));
        }

        public CommanderCostumeDataRow FindCostumeData(int ctid)
        {
            return commanderCostumeDtbl.Find((CommanderCostumeDataRow row) => row.ctid == ctid);
        }

        public string GetCostumeName(string ctid)
        {
            if (string.IsNullOrEmpty(ctid))
            {
                return "1";
            }
            return GetCostumeName(int.Parse(ctid));
        }

        public string GetCostumeName(int ctid)
        {
            CommanderCostumeDataRow commanderCostumeDataRow = FindCostumeData(ctid);
            if (commanderCostumeDataRow == null)
            {
                return "1";
            }
            return commanderCostumeDataRow.skinName;
        }

        public string GetCostumeThumbnailName(int ctid)
        {
            CommanderCostumeDataRow commanderCostumeDataRow = FindCostumeData(ctid);
            if (commanderCostumeDataRow != null)
            {
                CommanderDataRow commanderDataRow = commanderDtbl[commanderCostumeDataRow.cid.ToString()];
                return commanderDataRow.resourceId + "_" + commanderCostumeDataRow.skinName;
            }
            return " ";
        }

        public List<FavorDataRow> FindFavorData(int cid)
        {
            return favorDtbl.FindAll((FavorDataRow row) => row.cid == cid);
        }

        public CommanderGiftDataRow FindGiftData(int idx)
        {
            return commanderGiftDtbl.Find((CommanderGiftDataRow row) => row.idx == idx);
        }

        public List<CommanderGiftDataRow> GetCommanderAllGiftList()
        {
            return commanderGiftDtbl.FindAll((CommanderGiftDataRow row) => true);
        }

        public List<CommanderGiftDataRow> GetCommanderGiftList()
        {
            return commanderGiftDtbl.FindAll((CommanderGiftDataRow row) => row.type == 1);
        }

        public CommanderGiftDataRow GetCommanderGift(string idx)
        {
            return commanderGiftDtbl.Find((CommanderGiftDataRow row) => row.idx == int.Parse(idx));
        }

        public CommanderDataRow FindRaidCommander(int raidId)
        {
            int num = raidChallengeDtbl.FindIndex(raidId.ToString());
            if (num < 0)
            {
                return null;
            }
            RaidChallengeDataRow raidChallengeDataRow = raidChallengeDtbl[num];
            int num2 = commanderDtbl.FindIndex(raidChallengeDataRow.commanderId);
            if (num2 < 0)
            {
                return null;
            }
            return commanderDtbl[num2];
        }

        public int FindLevel(int aExp)
        {
            int level = 0;
            bool find = false;
            commanderLevelDtbl.ForEach(delegate (CommanderLevelDataRow row)
            {
                if (row.aexp > aExp && !find)
                {
                    find = true;
                    level = row.level - 1;
                }
            });
            return level;
        }

        public InAppProductDataRow GetInAppProduct(string idx)
        {
            return inAppProductDtbl.Find((InAppProductDataRow row) => row.googlePlayID == idx);
        }

        public List<CommanderScenarioDataRow> FindCommanderScenarioList(string cid)
        {
            return commanderScenarioDtbl.FindAll((CommanderScenarioDataRow row) => row.cid == cid);
        }

        public List<string> FindScenarioQuarterList(string csid)
        {
            List<string> list = null;
            for (int i = 0; i < scenarioQuarterDtbl.length; i++)
            {
                if (scenarioQuarterDtbl[i].csid == csid)
                {
                    list.Add(scenarioQuarterDtbl[i].quarter);
                }
            }
            return list;
        }

        public CommanderScenarioDataRow FindCommanderScenario(int csid)
        {
            return commanderScenarioDtbl.Find((CommanderScenarioDataRow row) => row.csid == csid);
        }

        public CommanderScenarioDataRow FindCommanderScenario(string cid, int heart)
        {
            return commanderScenarioDtbl.Find((CommanderScenarioDataRow row) => row.cid == cid && row.heart == heart);
        }

        public string CombineStringCidAndOrder(int csid)
        {
            for (int i = 0; i < commanderScenarioDtbl.length; i++)
            {
                if (commanderScenarioDtbl[i].csid == csid)
                {
                    return commanderScenarioDtbl[i].cid + "-" + commanderScenarioDtbl[i].order;
                }
            }
            return null;
        }

        public int GetCompleteScenarioQuarterCount(string csid)
        {
            return scenarioQuarterDtbl.FindAll((ScenarioQuarterDataRow row) => row.csid == csid).Count;
        }

        public List<ScenarioBattleUnitDataRow> FindScenarioBattleUnitInfo(string battleIdx, int uType)
        {
            List<ScenarioBattleUnitDataRow> list = new List<ScenarioBattleUnitDataRow>();
            for (int i = 0; i < scenarioBattleUnitDtbl.length; i++)
            {
                if (scenarioBattleUnitDtbl[i].battleIdx == battleIdx && scenarioBattleUnitDtbl[i].uType == uType)
                {
                    list.Add(scenarioBattleUnitDtbl[i]);
                }
            }
            return list;
        }

        public string FindScenarioBattleInfo(string battleIdx)
        {
            for (int i = 0; i < scenarioBattleDtbl.length; i++)
            {
                if (scenarioBattleDtbl[i].battleIdx == battleIdx)
                {
                    return scenarioBattleDtbl[i].quarter;
                }
            }
            return string.Empty;
        }

        public CommanderScenarioDataRow FindScenarioInfo(int csid)
        {
            return commanderScenarioDtbl.Find((CommanderScenarioDataRow row) => row.csid == csid);
        }

        public RewardDataRow FindScenarioCompleteReward(int cid, int csid)
        {
            return rewardDtbl.Find((RewardDataRow row) => row.type == cid && row.typeIndex == csid);
        }

        public WaveBattleDataRow FindWaveBattleData(int battleIdx)
        {
            return waveBattleDtbl.Find((WaveBattleDataRow row) => row.idx == battleIdx.ToString());
        }

        public List<EnemyUnitDataRow> FindNextWaveBattleEnemy(string enemyId, int nextWave)
        {
            return enemyUnitDtbl.FindAll((EnemyUnitDataRow row) => row.id == enemyId && row.wave == nextWave);
        }

        public EnemyUnitDataRow FindNextWaveBattleEnemy(string enemyId)
        {
            return enemyUnitDtbl.Find((EnemyUnitDataRow row) => row.unitId == enemyId);
        }

        public List<UnitDataRow> TextEnemyList(int nextStageIdx)
        {
            List<UnitDataRow> list = new List<UnitDataRow>();
            for (int i = nextStageIdx; i < nextStageIdx + 5; i++)
            {
                list.Add(unitDtbl[i]);
            }
            return list;
        }

        public ECarnivalType FindCarnivalType(string idx)
        {
            return carnivalTypeDtbl.Find((CarnivalTypeDataRow row) => row.idx == idx).Type;
        }

        public List<GroupInfoDataRow> FindGroupInfoList()
        {
            return groupInfoDtbl.FindAll((GroupInfoDataRow row) => true);
        }

        public GroupInfoDataRow FindGroupInfo(string idx)
        {
            return groupInfoDtbl.Find((GroupInfoDataRow row) => row.tabidx == idx);
        }

        public GroupInfoDataRow FindGroupInfoWhereGroupIdx(string idx)
        {
            return groupInfoDtbl.Find((GroupInfoDataRow row) => row.groupIdx == idx);
        }

        public List<GroupMemberDataRow> FindGroupMemberList(string idx)
        {
            return groupMemberDtbl.FindAll((GroupMemberDataRow row) => row.gidx == idx);
        }

        public EquipItemUpgradeDataRow FindUpgradeItemInfo(EItemStatType type, int level)
        {
            return equipItemUpgradeDtbl.Find((EquipItemUpgradeDataRow row) => row.upgradeType == type && row.level == level);
        }

        public EquipItemDisassembleDataRow FindDisassembleItemInfo(EItemStatType type, int level)
        {
            return equipItemDisassembleDtbl.Find((EquipItemDisassembleDataRow row) => row.disassembleType == type && row.level == level);
        }

        public List<EventBattleFieldDataRow> FindEventBattleList(int idx)
        {
            return eventBattleFieldDtbl.FindAll((EventBattleFieldDataRow row) => row.eventIdx == idx);
        }

        public EventBattleFieldDataRow FindEventBattle(int idx, int level)
        {
            return eventBattleFieldDtbl.Find((EventBattleFieldDataRow row) => row.eventIdx == idx && row.idx == level);
        }

        public List<EventBattleScenarioDataRow> FindEventScenarioList(string eidx)
        {
            return eventBattleScenarioDtbl.FindAll((EventBattleScenarioDataRow row) => row.eventIdx == eidx);
        }

        public NPCMercenaryDataRow FindNpcMercenary(string id)
        {
            return npcMercenaryDtbl.Find((NPCMercenaryDataRow row) => row.id == id);
        }

        public TranscendenceSlotDataRow FindTranscendenceSlot(int slot)
        {
            return transcendenceSlotDtbl.Find((TranscendenceSlotDataRow row) => row.slot == slot);
        }

        public TranscendenceStepUpgradeDataRow FindTranscendenceStepUpgrade(int step)
        {
            return transcendenceStepUpgradeDtbl.Find((TranscendenceStepUpgradeDataRow row) => row.step == step);
        }

        public List<TranscendenceStepUpgradeDataRow> FindTranscendenceStepUpgradeListPoint(int stepPoint)
        {
            return transcendenceStepUpgradeDtbl.FindAll((TranscendenceStepUpgradeDataRow row) => row.stepPoint <= stepPoint);
        }

        public static EWeaponSkill ParseWeaponSkillType(int skillIdx)
        {
            return (EWeaponSkill)(skillIdx + 1);
        }

        public static int ParseWeaponSkillIndex(WeaponDataRow weapon)
        {
            return weapon.slotType switch
            {
                1 => 4,
                2 => 1,
                3 => 0,
                4 => 2,
                5 => 3,
                _ => -1,
            };
        }
    }

}