using CommanderCS.Library;
using CommanderCS.Library.Battle;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation;
using CommanderCS.Library.Regulation.DataRows;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CommanderCS.Packets.Handlers.Battle
{
    [Packet(Id = Method.BattleOut)]
    public class BattleOut : BaseMethodHandler<BattleOutRequest>
    {
        public override object Handle(BattleOutRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            ErrorPacket error = new()
            {
                Id = BasePacket.Id,
                Error = new() { code = ErrorCode.Success }
            };

            string serializedJson = JsonConvert.SerializeObject(request.info, Formatting.Indented);

            Record record = (Record)request.info;
            Result result = (Result)request.result;
			EBattleType BattleType = request.BattleType;

            Simulator simulatedBattle = null;
            int commanderXP = 0;

            WorldMapStageDataRow worldstagetbl = null;
			InfinityFieldDataRow infinitytbl = null;

            var record1 = JsonConvert.SerializeObject(record, Formatting.Indented);
            var result1 = JsonConvert.SerializeObject(result, Formatting.Indented);
            switch (BattleType)
            {
                case EBattleType.Plunder:
                    simulatedBattle = Simulator.BattleReplay(RemoteObjectManager.instance.regulation, record);
                    worldstagetbl = RemoteObjectManager.instance.regulation.worldMapStageDtbl.Find(x => x.id == record.initState.stageID);
                    break;

                case EBattleType.Raid:
                    simulatedBattle = Simulator.BattleReplay(RemoteObjectManager.instance.regulation, record);

					var raidInfo = DatabaseManager.RaidBossSchedule.GetBossDataForUpcomingDays(1);
					//raidDataRow = RemoteObjectManager.instance.regulation.raidChallengeDtbl.Find(x => x.key == "1");

					//we need to check the raid igf or something dunno
                    break;

				case EBattleType.InfinityBattle:
                    simulatedBattle = Simulator.BattleReplay(RemoteObjectManager.instance.regulation, record);
                    infinitytbl = RemoteObjectManager.instance.regulation.infinityFieldDtbl.Find(x => x.infinityFieldIdx == record.initState.stageID);
                    break;

				case EBattleType.Annihilation:
                case EBattleType.Guerrilla:
				case EBattleType.MultiSingleDuel:
				case EBattleType.WorldDuel:
				case EBattleType.Conquest:
				case EBattleType.EventBattle:
				case EBattleType.EventRaid:
				case EBattleType.Duel:
				case EBattleType.GuildScramble:
				case EBattleType.ScenarioBattle:
				case EBattleType.SeaRobber:
				case EBattleType.CooperateBattle:
				case EBattleType.Attacker:
				case EBattleType.Defender:
				case EBattleType.WaveDuel:
				case EBattleType.WaveBattle:
				case EBattleType.WaveDuelDefender:
				case EBattleType.WorldDuelDefender:
                    simulatedBattle = Simulator.BattleReplay(RemoteObjectManager.instance.regulation, record);
                    break;
            }

            var simRec = JsonConvert.SerializeObject(simulatedBattle.record, Formatting.Indented);

			Result simulatedResult = simulatedBattle.result;

			bool isBattleDataQual = CompareBatteResult(result, simulatedResult);

			if (!isBattleDataQual)
			{
				ErrorPacket errorPacket = new()
				{
					Error = new()
					{
						code = (ErrorCode)70009
					},
					Id = BasePacket.Id
				};	
			}


			if (BattleType == EBattleType.WaveBattle)
			{

			}


            if (BattleType == EBattleType.Raid)
            {
                string client_replay = Convert.ToBase64String(Encoding.UTF8.GetBytes(record1));

                string server_replay = Convert.ToBase64String(Encoding.UTF8.GetBytes(simRec));

                DatabaseManager.ReplayList.Insert(User.Uno, User.MemberId, client_replay, server_replay, request.BattleType);

                DatabaseManager.RaidRankList.Insert(User, (int)simulatedBattle.result.totalAttackDamage, simulatedBattle.record.length);

                var rsocRaid = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

                UserInformationResponse.BattleResult battleResultRaid = new()
                {
                    save = false,
                    VipShopOpen = 0,
                    VipShopResetTime = 0,
                    commanderData = User.CommanderData,
                    commanderFavor = [],
                    eventResourceData = User.Inventory.eventResourceData,
                    foodData = User.Inventory.foodData,
                    groupItemData = User.Inventory.groupItemData,
                    infinityData = new(),
                    itemData = User.Inventory.itemData,
                    medalData = User.Inventory.medalData,
                    partData = User.Inventory.partData,
                    rewardList = [],
                    user = new(),
                    __resource = rsocRaid,
                };

                return new ResponsePacket
                {
                    Id = BasePacket.Id,
                    Result = JObject.FromObject(battleResultRaid),
                };
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            UserInformationResponse.BattleResult battleResult = new()
            {
                save = false,
                VipShopOpen = 0,
                VipShopResetTime = 0,
                commanderData = User.CommanderData,
                commanderFavor = [],
                eventResourceData = User.Inventory.eventResourceData,
                foodData = User.Inventory.foodData,
                groupItemData = User.Inventory.groupItemData,
                infinityData = new(),
                itemData = User.Inventory.itemData,
                medalData = User.Inventory.medalData,
                partData = User.Inventory.partData,
                rewardList = [],
                user = new()
                {
                    //curScore = (int)simulatedBattle.result.totalAttackDamage,
                    //rank = 1,
                    //rankPercent = 0.01f,
                    //prevScore = 1,
                    //getScore = (int)simulatedBattle.result.totalAttackDamage,
                },
                __resource = rsoc,
            };


			if(request.BattleType == EBattleType.InfinityBattle)
			{

				//InfinityTower
				//1 is story
				//11
				//13
				//14
				//24
				//26 
				//27
				//37
				//39 
				//40
				//50
				//52
				//53
				//63
				//65
				//66
				if(result.IsWin && simulatedBattle.result.IsWin)
				{

				}

				var x = User.BattleData.InfinityTowerData;

				//if we beat a stage before one of those we unlock that stage
				//example if we beat stage 10 we unlock 11 and if we beat stage 12 we unlock 12/13?
            }

            var res = JObject.FromObject(battleResult);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = res,
            };

            return response;
        }

        public static UserInformationResponse.Resource CheckIfLevelUp(int bullet, UserInformationResponse.Resource user, Regulation rg)
        {
            int user_xp = int.Parse(user.__exp);

            user_xp += bullet;

            user.__exp = user_xp.ToString();

            var row = rg.userLevelDtbl.Find(x => x.level == int.Parse(user.__level));

            int userXP = int.Parse(user.__exp);

            int userLevel = int.Parse(user.__level);

            if (userXP > row.exp)
            {
                user.__level = (userLevel + 1).ToString();
                user.__exp = (userXP -= row.exp).ToString();

                return CheckIfLevelUp(0, user, rg);
            }

            return user;
        }

        public static bool CompareBatteResult(Result clientResult, Result serverResult)
        {

            bool checksum = true;
            bool timeout = true;
            bool winside = true;
            bool gold = true;
            bool clearRank = true;
            bool totalAttackDamage = true;

            Dictionary<string, int> leftSideTroopsSkillSP_result = [];
            Dictionary<string, int> leftSideTroopsSkillSP_result1 = [];

            Dictionary<string, int> compareDic = [];

            foreach (var item in clientResult.leftSideTroops[0].slots)
            {
				if(item == null)
				{
					continue;
				}

                foreach (var skill in item.skills)
                {
                    leftSideTroopsSkillSP_result.Add(skill.id, skill.sp);
                }
            }

            foreach (var item in serverResult.leftSideTroops[0].slots)
            {
                if (item == null)
                {
                    continue;
                }

                foreach (var skill in item.skills)
                {
                    leftSideTroopsSkillSP_result1.Add(skill.id, skill.sp);
                }
            }

            bool skillsEqual = leftSideTroopsSkillSP_result.Count == leftSideTroopsSkillSP_result1.Count &&
                   !leftSideTroopsSkillSP_result.Except(leftSideTroopsSkillSP_result1).Any();


            if (clientResult.checksum != serverResult.checksum) checksum = false;
            if (clientResult.isTimeOut != serverResult.isTimeOut) timeout = false;
            if (clientResult.winSide != serverResult.winSide) winside = false;
            if (clientResult.gold != serverResult.gold) gold = false;
            if (clientResult.clearRank != serverResult.clearRank) clearRank = false;
            if (clientResult.totalAttackDamage != serverResult.totalAttackDamage) totalAttackDamage = false;

            int compare = 0;
            if (checksum) compare++;
            if (timeout) compare++;
            if (winside) compare++;
            if (gold) compare++;
            if (clearRank) compare++;
            if (totalAttackDamage) compare++;
            if (skillsEqual) compare++;

            int fixedInt = 7;

            if (compare != fixedInt)
            {
                if (compare < fixedInt - 2)
                {
					if(checksum == false && skillsEqual == false && totalAttackDamage == true)
					{
						return true;
					}
                }
				else
				{
					return false;
				}
            }
            return true;
        }


    }
    public class BattleOutRequest
    {
        [JsonProperty("type")]
        public EBattleType BattleType { get; set; }

        [JsonProperty("checkSum")]
        public string checkSum { get; set; }

        [JsonProperty("info")]
        public JArray info { get; set; }

        [JsonProperty("result")]
        public JArray result { get; set; }
    }
}

/*
	// Token: 0x06005FDB RID: 24539 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3232", true, true)]
	public void BattleOut(int type, string checkSum, JArray info, JArray result)
	{
	}

	// Token: 0x06005FDC RID: 24540 RVA: 0x001AF878 File Offset: 0x001ADA78
	private IEnumerator BattleOutResult(JsonRpcClient.Request request, object result)
	{
		BattleData battleData = BattleData.Get();
		BattleData.Set(battleData);
		Protocols.UserInformationResponse.BattleResult battleResult = null;
		UIManager.instance.battle.Main.SendMessage("OnBattleOutResult", SendMessageOptions.DontRequireReceiver);
		if (battleData is null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble && result is null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble)
		{
			battleResult = this._ConvertJObject<Protocols.UserInformationResponse.BattleResult>(result);
			if (!this.localUser.statistics.isBuyVipShop && battleResult.VipShopOpen == 1)
			{
				this.localUser.statistics.vipShop = battleResult.VipShopOpen;
				this.localUser.statistics.vipShopResetTime_Data.SetByDuration((double)battleResult.VipShopResetTime);
				this.localUser.statistics.vipShopisFloating = true;
				this.ScheduleLocalPush(ELocalPushType.LeaveVipShop, battleResult.VipShopResetTime);
			}
		}
		bool isWin = battleData.isWin;
		UIBattleMain mainUI = UIManager.instance.battle.MainUI;
		UIBattleResult battleResult2 = UIManager.instance.battle.BattleResult;
		if (battleData.type == EBattleType.Plunder)
		{
			if (isWin)
			{
				WorldMapStageDataRow worldMapStageDataRow = this.RemoteObjectManager.instance.regulation.worldMapStageDtbl[battleData.stageId];
				battleResult2.plunderResult.SetBattleTime((float)UIManager.instance.battle.Simulator.frame.time / 1000f);
				battleResult2.plunderResult.SetGetExp(worldMapStageDataRow.bullet);
				battleResult2.plunderResult.SetRewardDataAndOpen(battleResult.rewardList);
				if (this.localUser.lastClearStage < int.Parse(battleData.stageId))
				{
					this.localUser.lastClearStage = int.Parse(battleData.stageId);
				}
				if (GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED)
				{
					if (int.Parse(battleData.stageId) >= 23)
					{
						SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQBQ");
					}
					if (int.Parse(battleData.stageId) >= 43)
					{
						SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQBg");
					}
					if (int.Parse(battleData.stageId) >= 63)
					{
						SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQBw");
					}
					if (int.Parse(battleData.stageId) >= 83)
					{
						SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQCA");
					}
					if (int.Parse(battleData.stageId) >= 103)
					{
						SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQCQ");
					}
				}
				if (GameCenterManager.IsPlayerAuthenticated)
				{
					if (int.Parse(battleData.stageId) == 23)
					{
						GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQBQ");
					}
					else if (int.Parse(battleData.stageId) == 43)
					{
						GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQBg");
					}
					else if (int.Parse(battleData.stageId) == 63)
					{
						GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQBw");
					}
					else if (int.Parse(battleData.stageId) == 83)
					{
						GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQCA");
					}
					else if (int.Parse(battleData.stageId) == 103)
					{
						GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQCQ");
					}
				}
			}
			if (GooglePlayConnection.State == GPConnectionState.STATE_CONNECTED)
			{
				RemoteObjectManager.statistics.unitDestroyCount += battleData.unitKillCount;
				if (RemoteObjectManager.statistics.unitDestroyCount >= 200)
				{
					SA_Singleton<GooglePlayManager>.Instance.UnlockAchievementById("CgkIj7Xpxu4GEAIQDw");
				}
			}
			if (GameCenterManager.IsPlayerAuthenticated)
			{
				RemoteObjectManager.statistics.unitDestroyCount += battleData.unitKillCount;
				if (RemoteObjectManager.statistics.unitDestroyCount >= 200)
				{
					GameCenterManager.SubmitAchievement(100f, "CgkIj7Xpxu4GEAIQDw");
				}
			}
			UISetter.SetActive(battleResult2.plunderResult.btnWorldMap, true);
			UISetter.SetActive(battleResult2.plunderResult.btnCamp, true);
			UISetter.SetActive(battleResult2.plunderResult.btnSituation, false);
			UISetter.SetActive(battleResult2.plunderResult.btnAnnihilation, false);
			UISetter.SetActive(battleResult2.plunderResult.btnNextAnnihilation, false);
			UISetter.SetActive(battleResult2.plunderResult.btnWaveBattle, false);
			battleResult2.Set(battleData);
			if (battleData.isWin)
			{
				battleResult2.plunderResult.SetUpdataCommanderData(battleResult.commanderData);
			}
			this.localUser.useBullet = true;
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.Raid)
		{
			battleResult2.raidResult.SetBattleTime((float)UIManager.instance.battle.Simulator.frame.time / 1000f);
			battleResult2.raidResult.SetRank(battleResult.user.rank);
			battleResult2.raidResult.SetRankPersent(battleResult.user.rankPercent);
			battleResult2.raidResult.SetBaseScore(battleResult.user.prevScore);
			battleResult2.raidResult.SetScore(battleResult.user.prevScore, battleResult.user.curScore);
			battleResult2.Set(battleData);
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.Guerrilla || battleData.type == EBattleType.SeaRobber)
		{
			if (isWin)
			{
				battleResult2.plunderResult.SetBattleTime((float)UIManager.instance.battle.Simulator.frame.time / 1000f);
				battleResult2.plunderResult.SetRewardDataAndOpen(battleResult.rewardList);
				this.localUser.AddSweepClearState(battleData.sweepType, battleData.sweepLevel);
			}
			battleResult2.Set(battleData);
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.Annihilation)
		{
			if (isWin)
			{
				battleResult2.plunderResult.SetBattleTime((float)UIManager.instance.battle.Simulator.frame.time / 1000f);
				if (battleResult.resource is not null)
				{
					battleResult2.plunderResult.SetGetExp(0);
				}
				if (battleResult.rewardList is not null)
				{
					battleResult2.plunderResult.SetRewardDataAndOpen(battleResult.rewardList);
				}
			}
			int num = this.localUser.lastClearAnnihilationStage + 1;
			if (this.localUser.lastClearAnnihilationStage > 100 && this.localUser.lastClearAnnihilationStage < 200)
			{
				num -= 100;
			}
			else if (this.localUser.lastClearAnnihilationStage > 200)
			{
				num -= 200;
			}
			UISetter.SetActive(battleResult2.plunderResult.btnNextAnnihilation, isWin && num <= 21);
			battleResult2.Set(battleData);
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.WaveBattle)
		{
			battleResult2.plunderResult.SetRewardDataAndOpen(battleResult.rewardList);
			battleResult2.Set(battleData);
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.CooperateBattle)
		{
			battleResult2.Set(battleData);
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.EventBattle)
		{
			if (isWin)
			{
				battleResult2.plunderResult.SetBattleTime((float)UIManager.instance.battle.Simulator.frame.time / 1000f);
				battleResult2.plunderResult.SetGetExp(0);
				battleResult2.plunderResult.SetRewardDataAndOpen(battleResult.rewardList);
			}
			battleResult2.Set(battleData);
			if (battleData.isWin)
			{
				battleResult2.plunderResult.SetUpdataCommanderData(battleResult.commanderData);
			}
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.EventRaid)
		{
			battleResult2.eventRaidResult.SetRewardData(battleResult.rewardList);
			battleResult2.Set(battleData);
			UISetter.SetActive(mainUI.main, false);
		}
		else if (battleData.type == EBattleType.InfinityBattle)
		{
			battleResult2.Set(battleData);
			battleResult2.infinityBattleResult.data = battleResult.infinityData;
			UISetter.SetActive(mainUI.main, false);
		}
		if (!GameSetting.instance.repeatBattle)
		{
			battleResult2.Open();
		}
		if (battleResult is not null)
		{
			this.localUser.RefreshGoodsFromNetwork(battleResult.resource);
			this.localUser.RefreshPartFromNetwork(battleResult.partData);
			this.localUser.RefreshMedalFromNetwork(battleResult.medalData);
			this.localUser.RefreshFavorFromNetwork(battleResult.commanderFavor);
			this.localUser.RefreshItemFromNetwork(battleResult.eventResourceData);
			this.localUser.RefreshItemFromNetwork(battleResult.itemData);
			this.localUser.RefreshItemFromNetwork(battleResult.foodData);
			this.localUser.RefreshItemFromNetwork(battleResult.groupItemData);
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005FDD RID: 24541 RVA: 0x001AF89C File Offset: 0x001ADA9C
	private IEnumerator BattleOutError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70009)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("7044"), Localization.Get("1004"));
			if (uisimplePopup is not null)
			{
				uisimplePopup.onClose = delegate
				{
					BattleData battleData = BattleData.Get();
					battleData.move = EBattleResultMove.WorldMap;
					Loading.Load(Loading.WorldMap);
				};
			}
		}
		else
		{
			UISimplePopup uisimplePopup2 = UISimplePopup.CreateOK(false, Localization.Get("19013"), string.Empty, string.Concat(new object[]
			{
				Localization.Get("19014"),
				"\n(ErrorCode:",
				code,
				")"
			}), Localization.Get("5133"));
			if (uisimplePopup2 is not null)
			{
				uisimplePopup2.onClose = delegate
				{
					Application.Quit();
				};
			}
		}
		yield break;
	}*/