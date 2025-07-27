using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation.DataRows;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using static CommanderCS.Library.Protocols.UserInformationResponse;

namespace CommanderCS.Library.Regulation
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

        public static readonly JsonSerializerSettings SerializerSettings = new()
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

        public List<CashShopData> cashShopDtbl;

        protected Dictionary<string, PropertyInfo> properties;

        public static Dictionary<string, string> RegulationFile = [];
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
                if (_skillDamagePattern is null)
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
                if (_dormitoryHeadCostumeMap is null)
                {
                    _dormitoryHeadCostumeMap = [];
                    for (int i = 0; i < dormitoryHeadCostumeDtbl.length; i++)
                    {
                        string cid = dormitoryHeadCostumeDtbl[i].cid;
                        if (!_dormitoryHeadCostumeMap.ContainsKey(cid))
                        {
                            _dormitoryHeadCostumeMap.Add(cid, []);
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
                if (_dormitoryThemeMap is null)
                {
                    _dormitoryThemeMap = [];
                    for (int i = 0; i < dormitoryThemeDtbl.length; i++)
                    {
                        DormitoryThemeDataRow dormitoryThemeDataRow = dormitoryThemeDtbl[i];
                        if (!_dormitoryThemeMap.ContainsKey(dormitoryThemeDataRow.id))
                        {
                            _dormitoryThemeMap.Add(dormitoryThemeDataRow.id, []);
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
                if (_cooperateBattleStepDtbl is null)
                {
                    _cooperateBattleStepDtbl = [];
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
        public DataTable<AchievementDataRow> achievementDtbl { get; private set; }
        public DataTable<BattleTimeDataRow> battletimeDtbl { get; private set; }
        public DataTable<CommanderRoleDataRow> commanderRoleDtbl { get; private set; }
        public DataTable<MissionDataRow> missionDtbl { get; private set; }
        public DataTable<CommanderClassUpDataRow> commanderClassUpDtbl { get; private set; }
        public DataTable<VipBenefitsDataRow> VipBenefitsDtbl { get; private set; }

        private Regulation()
        {
        }

        public static Regulation Create()
        {
            Regulation regulation = new();
            regulation.Init();
            return regulation;
        }

        public static DataTable<T> LoadTable<T>(string filename) where T : DataRow
        {

            string basePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Resources",
                "ExcelOutputAsset"
            );

            DataTable<T> table = null;

            try
            {
                string filePath = Path.Combine(basePath, filename);
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    table = JsonConvert.DeserializeObject<DataTable<T>>(json, SerializerSettings);

                    return table;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {filename}: {ex.Message}");
                throw ex;
            }

            return table;
        }
        public void Init()
        {
            // Load all tables using the static LoadTable method
            rewardDtbl = LoadTable<RewardDataRow>("RewardDataTable.json");
            userLevelDtbl = LoadTable<UserLevelDataRow>("UserLevelDataTable.json");
            partDtbl = LoadTable<PartDataRow>("PartDataTable.json");
            interactionDtbl = LoadTable<InteractionDataRow>("InteractionDataTable.json");
            goodsDtbl = LoadTable<GoodsDataRow>("GoodsDataTable.json");
            buildingLevelDtbl = LoadTable<BuildingLevelDataRow>("BuildingLevelDataTable.json");
            commanderDtbl = LoadTable<CommanderDataRow>("CommanderDataTable.json");
            commanderLevelDtbl = LoadTable<CommanderLevelDataRow>("CommanderLevelDataTable.json");
            commanderRankDtbl = LoadTable<CommanderRankDataRow>("CommanderRankDataTable.json");
            commanderTrainingTicketDtbl = LoadTable<CommanderTrainingTicketDataRow>("CommanderTrainingTicketDataTable.json");
            commanderClassDtbl = LoadTable<CommanderClassDataRow>("CommanderClassDataTable.json");
            commanderCostumeDtbl = LoadTable<CommanderCostumeDataRow>("CommanderCostumeDataTable.json");
            commanderGiftDtbl = LoadTable<CommanderGiftDataRow>("CommanderGiftDataTable.json");
            favorDtbl = LoadTable<FavorDataRow>("FavorDataTable.json");
            worldMapDtbl = LoadTable<WorldMapDataRow>("WorldMapDataTable.json");
            worldMapStageDtbl = LoadTable<WorldMapStageDataRow>("WorldMapStageDataTable.json");
            worldMapStageTypeDtbl = LoadTable<WorldMapStageTypeDataRow>("WorldMapStageTypeDataTable.json");
            enemyCommanderDtbl = LoadTable<EnemyCommanderDataRow>("EnemyCommanderDataTable.json");
            enemyUnitDtbl = LoadTable<EnemyUnitDataRow>("EnemyUnitDataTable.json");
            unitDtbl = LoadTable<UnitDataRow>("UnitDataTable.json");
            skillDtbl = LoadTable<SkillDataRow>("SkillDataTable.json");
            skillCostDtbl = LoadTable<SkillCostDataRow>("SkillCostDataTable.json");
            skillUpgradeDtbl = LoadTable<SkillUpgradeDataRow>("SkillUpgradeDataTable.json");
            projectileDtbl = LoadTable<ProjectileDataRow>("ProjectileDataTable.json");
            statusEffectDtbl = LoadTable<StatusEffectDataRow>("StatusEffectDataTable.json");
            unitMotionDtbl = LoadTable<UnitMotionDataRow>("UnitMotionDataTable.json");
            projectileMotionPhaseDtbl = LoadTable<ProjectileMotionPhaseDataRow>("ProjectileMotionPhaseDataTable.json");
            dailyBonusDtbl = LoadTable<DailyBonusDataRow>("DailyBonusDataTable.json");
            gachaDtbl = LoadTable<GachaDataRow>("GachaDataTable.json");
            gachaRewardDtbl = LoadTable<GachaRewardDataRow>("GachaRewardDataTable.json");
            gachaCostDtbl = LoadTable<GachaCostDataRow>("GachaCostDataTable.json");
            sweepDtbl = LoadTable<SweepDataRow>("SweepDataTable.json");
            raidDtbl = LoadTable<RaidDataRow>("RaidDataTable.json");
            levelPatternDtbl = LoadTable<LevelPatternDataRow>("LevelPatternDataTable.json");
            classPatternDtbl = LoadTable<ClassPatternDataRow>("ClassPatternDataTable.json");
            dropGoldPatternDtbl = LoadTable<DropGoldPatternDataRow>("DropGoldPatternDataTable.json");
            metroBankLuckDtbl = LoadTable<MetroBankLuckDataRow>("MetroBankLuckDataTable.json");
            vipRechargeDtbl = LoadTable<VipRechargeDataRow>("VipRechargeDataTable.json");
            rankingRewardDtbl = LoadTable<RankingRewardDataRow>("RankingRewardDataTable.json");
            rankingDtbl = LoadTable<RankingDataRow>("RankingDataTable.json");
            guildSkillDtbl = LoadTable<GuildSkillDataRow>("GuildSkillDataTable.json");
            guildStruggleDtbl = LoadTable<GuildStruggleDataRow>("GuildStruggleDataTable.json");
            guildLevelInfoDtbl = LoadTable<GuildLevelInfoDataRow>("GuildLevelInfoDataTable.json");
            guildOccupyDtbl = LoadTable<GuildOccupyDataRow>("GuildOccupyDataTable.json");
            vipExpDtbl = LoadTable<VipExpDataRow>("VipExpDataTable.json");
            favorStepDtbl = LoadTable<FavorStepDataRow>("FavorStepDataTable.json");
            shopDtbl = LoadTable<ShopDataRow>("ShopDataTable.json");
            thumbnailDtbl = LoadTable<ThumbnailDataRow>("ThumbnailDataTable.json");
            itemExchangeDtbl = LoadTable<ItemExchangeDataRow>("ItemExchangeDataTable.json");
            dailyEventDtbl = LoadTable<DailyEventDataRow>("DailyEventDataTable.json");
            fireActionDtbl = LoadTable<FireActionDataRow>("FireActionDataTable.json");
            annihilateBattleDtbl = LoadTable<AnnihilateBattleDataRow>("AnnihilateBattleDataTable.json");
            inAppProductDtbl = LoadTable<InAppProductDataRow>("InAppProductDataTable.json");
            carnivalDtbl = LoadTable<CarnivalDataRow>("CarnivalDataTable.json");
            carnivalTypeDtbl = LoadTable<CarnivalTypeDataRow>("CarnivalTypeDataTable.json");
            groupInfoDtbl = LoadTable<GroupInfoDataRow>("GroupInfoDataTable.json");
            groupMemberDtbl = LoadTable<GroupMemberDataRow>("GroupMemberDataTable.json");
            raidChallengeDtbl = LoadTable<RaidChallengeDataRow>("RaidChallengeDataTable.json");
            commanderScenarioDtbl = LoadTable<CommanderScenarioDataRow>("CommanderScenarioDataTable.json");
            scenarioQuarterDtbl = LoadTable<ScenarioQuarterDataRow>("ScenarioQuarterDataTable.json");
            scenarioBattleDtbl = LoadTable<ScenarioBattleDataRow>("ScenarioBattleDataTable.json");
            waveBattleDtbl = LoadTable<WaveBattleDataRow>("WaveBattleDataTable.json");
            equipItemDtbl = LoadTable<EquipItemDataRow>("EquipItemDataTable.json");
            equipItemUpgradeDtbl = LoadTable<EquipItemUpgradeDataRow>("EquipItemUpgradeDataTable.json");
            equipItemDisassembleDtbl = LoadTable<EquipItemDisassembleDataRow>("EquipItemDisassembleDataTable.json");
            explorationDtbl = LoadTable<ExplorationDataRow>("BattleFieldSearchDataTable.json");
            cooperateBattleDtbl = LoadTable<CooperateBattleDataRow>("CooperateBattleDataTable.json");
            eventBattleDtbl = LoadTable<EventBattleDataRow>("EventBattleDataTable.json");
            eventBattleFieldDtbl = LoadTable<EventBattleFieldDataRow>("EventBattleFieldDataTable.json");
            eventRaidDtbl = LoadTable<EventRaidDataRow>("EventRaidDataTable.json");
            eventBattleScenarioDtbl = LoadTable<EventBattleScenarioDataRow>("EventBattleScenarioDataTable.json");
            eventBattleGachaRewardDtbl = LoadTable<EventBattleGachaRewardDataRow>("EventBattleGachaRewardDataTable.json");
            randomBoxRewardDtbl = LoadTable<RandomBoxRewardDataRow>("RandomBoxRewardDataTable.json");
            skillDamagePatternDtbl = LoadTable<SkillDamagePatternDataRow>("SkillDamagePatternDataTable.json");
            eventRemaingTimeDtbl = LoadTable<EventRemaingTimeDataRow>("EventRemaingTimeDataTable.json");
            npcMercenaryDtbl = LoadTable<NPCMercenaryDataRow>("NPCMercenaryDataTable.json");
            transcendenceSlotDtbl = LoadTable<TranscendenceSlotDataRow>("TranscendenceSlotDataTable.json");
            transcendenceStepUpgradeDtbl = LoadTable<TranscendenceStepUpgradeDataRow>("TranscendenceStepUpgradeDataTable.json");
            weaponDtbl = LoadTable<WeaponDataRow>("WeaponDataTable.json");
            weaponUpgradeDtbl = LoadTable<WeaponUpgradeDataRow>("WeaponUpgradeDataTable.json");
            weaponSetDtbl = LoadTable<WeaponSetDataRow>("WeaponSetDataTable.json");
            goodsComposeDtbl = LoadTable<GoodsComposeDataRow>("GoodsComposeDataTable.json");
            missionDtbl = LoadTable<MissionDataRow>("MissionTable.json");
            achievementDtbl = LoadTable<AchievementDataRow>("AchievementTable.json");
            commanderRoleDtbl = LoadTable<CommanderRoleDataRow>("CommanderRoleDataTable.json");
            battletimeDtbl = LoadTable<BattleTimeDataRow>("BattleTimeDataTable.json");
            commanderClassUpDtbl = LoadTable<CommanderClassUpDataRow>("CommanderClassUpDataTable.json");
            VipBenefitsDtbl = LoadTable<VipBenefitsDataRow>("VipBenefitsDataTable.json");
        }

        public static void ExtendList<T>(ref List<T> list, int count)
        {
            if (list is null)
            {
                list = [];
            }
            for (int i = list.Count; i < count; i++)
            {
                list.Add(default);
            }
        }

        public static void FillList<T>(ref List<T> list, int count)
        {
            if (list is null)
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
                result = (EBranch)Enum.Parse(typeof(EBranch), str);
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
            List<CommanderDataRow> list = [];
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
            return commanderDtbl.Find(row => row.unitId == unitId);
        }

        public CommanderDataRow GetCommander(string commanderId)
        {
            return commanderDtbl.Find(row => row.id == commanderId);
        }

        public CommanderDataRow GetCommanderByResourceId(string resourceId)
        {
            return commanderDtbl.Find(row => row.resourceId == resourceId);
        }

        public List<CommanderTrainingTicketDataRow> GetTrainingTicketList()
        {
            return commanderTrainingTicketDtbl.FindAll(row => true);
        }

        public List<SkillDataRow> GetSkillList()
        {
            return skillDtbl.FindAll(row => true);
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
            return unitDtbl.FindAll(row => (branch == EBranch.Undefined || branch == row.branch) && (!row.isHidden || includeHidden && row.isHidden));
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
            return goodsDtbl.Find(row => row.type == id);
        }

        public List<SweepDataRow> FindSweepRow(int type)
        {
            return sweepDtbl.FindAll(row => row.type == type);
        }

        public SweepDataRow FindSweepRow(int type, int level)
        {
            return sweepDtbl.Find(row => row.type == type && row.level == level);
        }

        public List<GachaRewardDataRow> FindGachaRewardList(string gachaType)
        {
            return gachaRewardDtbl.FindAll(row => row.gachaType == gachaType);
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
            return goodsDtbl.Find(row => row.serverFieldName == fieldName);
        }

        public GoodsDataRow FindGoodsServerFieldName(int id)
        {
            return goodsDtbl.Find(row => row.type == id.ToString());
        }

        public GachaCostDataRow FindGachaCost(string gachaType, int count)
        {
            return gachaCostDtbl.Find(row => row.type == gachaType && row.count == count);
        }

        public CommanderTrainingTicketDataRow FindCommanderTrainingTicketData(ETrainingTicketType Type)
        {
            return commanderTrainingTicketDtbl.Find(row => row.type == Type);
        }

        public CommanderRankDataRow FindCommanderRankData(int rank)
        {
            return commanderRankDtbl.Find(row => row.rank == rank);
        }

        public List<BuildingLevelDataRow> GetOpenBuildingDataList()
        {
            return buildingLevelDtbl.FindAll(row => row.type != EBuilding.Headquarters);
        }

        public List<int> FindMetroBankLuckList()
        {
            List<int> list = [];
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
            List<int> list = [];
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
            return partDtbl.Find(row => row.type == partType);
        }

        public InteractionDataRow FindInteractionData(string id, InteractionType type, int count)
        {
            return interactionDtbl.Find(row => row.resourceId == id && row.type == type && row.count == count);
        }

        public List<InteractionDataRow> FindInteractionData(string id, InteractionType type)
        {
            return interactionDtbl.FindAll(row => row.resourceId == id && row.type == type);
        }

        public List<InteractionDataRow> FindVoiceInteractionData(string id)
        {
            return interactionDtbl.FindAll(row => row.resourceId == id && row.type < InteractionType.DATE_HEAD_FAVOR1);
        }

        public InteractionDataRow FindInteractionData(string id, int idx)
        {
            return interactionDtbl.Find(row => row.resourceId == id && row.favorup == idx);
        }

        public List<RankingDataRow> FindDuelRankingList(ERankingContentsType type)
        {
            return rankingDtbl.FindAll(row => row.type == type);
        }

        public List<RewardDataRow> FindDuelRankingRewardList(int type, int typeIdx)
        {
            return rewardDtbl.FindAll((row) => row.category == ERewardCategory.Ranking && row.type == type && row.typeIndex == typeIdx && row.rewardType != ERewardType.Costume);
        }

        public GuildSkillDataRow FindGuildSkillData(int idx, int level)
        {
            return guildSkillDtbl.Find(row => row.idx == idx && row.level == level);
        }

        public List<GuildSkillDataRow> FindGuildSkillDataLevel(int level)
        {
            return guildSkillDtbl.FindAll(row => row.level == level);
        }

        public GuildLevelInfoDataRow FindGuildLevelInfoData(int level)
        {
            return guildLevelInfoDtbl.Find(row => row.level == level);
        }

        public VipExpDataRow FindVipExpData(int idx)
        {
            return vipExpDtbl.Find(row => row.Idx == idx);
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

        public static int GetVipRechargeCount(List<VipRechargeData> vipRechargedata, int key)
        {
            VipRechargeData matchingItem = vipRechargedata.FirstOrDefault(item => item.idx == key);

            return matchingItem.count;
        }

        public static List<VipRechargeData> UpdateVipRechargeCount(List<VipRechargeData> vipRechargedata, int key, int count)
        {
            int index = vipRechargedata.FindIndex(item => item.idx == key);

            if (index != null)
            {
                vipRechargedata[index].count = count;
            }

            return vipRechargedata;
        }

        public FavorStepDataRow FindFavorStepData(int step)
        {
            return favorStepDtbl.Find(row => row.step == step);
        }

        public ItemExchangeDataRow FindExchangeItemData(EStorageType type, string idx)
        {
            return itemExchangeDtbl.Find(row => row.type == type && row.typeidx == idx);
        }

        public CommanderClassDataRow FindCommandClassData(int cidx, int cls)
        {
            return commanderClassDtbl.Find(row => row.index == cidx && row.cls == cls);
        }

        public List<CommanderCostumeDataRow> FindCommandCostumeData(string cid)
        {
            return commanderCostumeDtbl.FindAll(row => row.cid == int.Parse(cid));
        }

        public CommanderCostumeDataRow FindCostumeData(int ctid)
        {
            return commanderCostumeDtbl.Find(row => row.ctid == ctid);
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
            if (commanderCostumeDataRow is null)
            {
                return "1";
            }
            return commanderCostumeDataRow.skinName;
        }

        public string GetCostumeThumbnailName(int ctid)
        {
            CommanderCostumeDataRow commanderCostumeDataRow = FindCostumeData(ctid);
            if (commanderCostumeDataRow is not null)
            {
                CommanderDataRow commanderDataRow = commanderDtbl[commanderCostumeDataRow.cid.ToString()];
                return commanderDataRow.resourceId + "_" + commanderCostumeDataRow.skinName;
            }
            return " ";
        }

        public List<FavorDataRow> FindFavorData(int cid)
        {
            return favorDtbl.FindAll(row => row.cid == cid);
        }

        public CommanderGiftDataRow FindGiftData(int idx)
        {
            return commanderGiftDtbl.Find(row => row.idx == idx);
        }

        public List<CommanderGiftDataRow> GetCommanderAllGiftList()
        {
            return commanderGiftDtbl.FindAll((row) => true);
        }

        public List<CommanderGiftDataRow> GetCommanderGiftList()
        {
            return commanderGiftDtbl.FindAll(row => row.type == 1);
        }

        public CommanderGiftDataRow GetCommanderGift(string idx)
        {
            return commanderGiftDtbl.Find(row => row.idx == int.Parse(idx));
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
            return inAppProductDtbl.Find(row => row.googlePlayID == idx);
        }

        public List<CommanderScenarioDataRow> FindCommanderScenarioList(string cid)
        {
            return commanderScenarioDtbl.FindAll(row => row.cid == cid);
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
            return commanderScenarioDtbl.Find(row => row.csid == csid);
        }

        public CommanderScenarioDataRow FindCommanderScenario(string cid, int heart)
        {
            return commanderScenarioDtbl.Find(row => row.cid == cid && row.heart == heart);
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
            return scenarioQuarterDtbl.FindAll(row => row.csid == csid).Count;
        }

        public List<ScenarioBattleUnitDataRow> FindScenarioBattleUnitInfo(string battleIdx, int uType)
        {
            List<ScenarioBattleUnitDataRow> list = [];
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
            return commanderScenarioDtbl.Find(row => row.csid == csid);
        }

        public RewardDataRow FindScenarioCompleteReward(int cid, int csid)
        {
            return rewardDtbl.Find(row => row.type == cid && row.typeIndex == csid);
        }

        public WaveBattleDataRow FindWaveBattleData(int battleIdx)
        {
            return waveBattleDtbl.Find(row => row.idx == battleIdx.ToString());
        }

        public List<EnemyUnitDataRow> FindNextWaveBattleEnemy(string enemyId, int nextWave)
        {
            return enemyUnitDtbl.FindAll(row => row.id == enemyId && row.wave == nextWave);
        }

        public EnemyUnitDataRow FindNextWaveBattleEnemy(string enemyId)
        {
            return enemyUnitDtbl.Find(row => row.unitId == enemyId);
        }

        public List<UnitDataRow> TextEnemyList(int nextStageIdx)
        {
            List<UnitDataRow> list = [];
            for (int i = nextStageIdx; i < nextStageIdx + 5; i++)
            {
                list.Add(unitDtbl[i]);
            }
            return list;
        }

        public ECarnivalType FindCarnivalType(string idx)
        {
            return carnivalTypeDtbl.Find(row => row.idx == idx).Type;
        }

        public List<GroupInfoDataRow> FindGroupInfoList()
        {
            return groupInfoDtbl.FindAll(row => true);
        }

        public GroupInfoDataRow FindGroupInfo(string idx)
        {
            return groupInfoDtbl.Find(row => row.tabidx == idx);
        }

        public GroupInfoDataRow FindGroupInfoWhereGroupIdx(string idx)
        {
            return groupInfoDtbl.Find(row => row.groupIdx == idx);
        }

        public List<GroupMemberDataRow> FindGroupMemberList(string idx)
        {
            return groupMemberDtbl.FindAll(row => row.gidx == idx);
        }

        public EquipItemUpgradeDataRow FindUpgradeItemInfo(EItemStatType type, int level)
        {
            return equipItemUpgradeDtbl.Find(row => row.upgradeType == type && row.level == level);
        }

        public EquipItemDisassembleDataRow FindDisassembleItemInfo(EItemStatType type, int level)
        {
            return equipItemDisassembleDtbl.Find(row => row.disassembleType == type && row.level == level);
        }

        public List<EventBattleFieldDataRow> FindEventBattleList(int idx)
        {
            return eventBattleFieldDtbl.FindAll(row => row.eventIdx == idx);
        }

        public EventBattleFieldDataRow FindEventBattle(int idx, int level)
        {
            return eventBattleFieldDtbl.Find(row => row.eventIdx == idx && row.idx == level);
        }

        public List<EventBattleScenarioDataRow> FindEventScenarioList(string eidx)
        {
            return eventBattleScenarioDtbl.FindAll(row => row.eventIdx == eidx);
        }

        public NPCMercenaryDataRow FindNpcMercenary(string id)
        {
            return npcMercenaryDtbl.Find(row => row.id == id);
        }

        public TranscendenceSlotDataRow FindTranscendenceSlot(int slot)
        {
            return transcendenceSlotDtbl.Find(row => row.slot == slot);
        }

        public TranscendenceStepUpgradeDataRow FindTranscendenceStepUpgrade(int step)
        {
            return transcendenceStepUpgradeDtbl.Find(row => row.step == step);
        }

        public List<TranscendenceStepUpgradeDataRow> FindTranscendenceStepUpgradeListPoint(int stepPoint)
        {
            return transcendenceStepUpgradeDtbl.FindAll(row => row.stepPoint <= stepPoint);
        }

        public static EWeaponSkill ParseWeaponSkillType(int skillIdx)
        {
            return (EWeaponSkill)(skillIdx + 1);
        }

        public static int ParseWeaponSkillIndex(WeaponDataRow weapon)
        {
            switch (weapon.slotType)
            {
                case 1:
                    return 4;

                case 2:
                    return 1;

                case 3:
                    return 0;

                case 4:
                    return 2;

                case 5:
                    return 3;

                default:
                    return -1;
            }
        }

        public Dictionary<string, List<WorldMapInformationResponse>> GetAllWorldMapStages()
        {
            Dictionary<string, List<WorldMapInformationResponse>> stages = [];

            foreach (var stage in worldMapStageDtbl)
            {
                stages = worldMapStageDtbl
                .GroupBy(s => s.worldMapId)
                    .ToDictionary(
                g => g.Key.ToString(),
                g => g.Select(s => new WorldMapInformationResponse
                {
                    stageId = s.id,
                    clearCount = 0,
                    star = 0
                }).ToList());
            }
            return stages;
        }

        public Dictionary<string, Commander> AddSpecificCommander(Dictionary<string, Commander> commanderDict, int commanderID)
        {
            var item = commanderCostumeDtbl.FirstOrDefault(c => c.cid == commanderID);

            var role = commanderRoleDtbl.FirstOrDefault(x => x.Id == commanderID);

            Commander commanderData = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "0",
                __skv4 = "0",
                favorRewardStep = 0,
                favorStep = 0,
                currentCostume = item.ctid,
                equipItemInfo = [],
                equipWeaponInfo = [],
                eventCostume = [],
                favorPoint = new() { },
                favr = 0,
                fvrd = 0,
                haveCostume = [item.ctid],
                id = commanderID.ToString(),
                marry = 0,
                medl = 0,
                role = role.Role,
                transcendence = [0, 0, 0, 0],
                __cls = "1",
                __exp = "0",
                __level = "1",
                __rank = "1",
            };

            commanderDict.Add(commanderID.ToString(), commanderData);

            return commanderDict;
        }
    }
}