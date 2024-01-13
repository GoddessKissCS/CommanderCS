using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Battle;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Host.Handlers.Battle
{
    [Packet(Id = Method.BattleOut)]
    public class BattleOut : BaseMethodHandler<BattleOutRequest>
    {
        public override object Handle(BattleOutRequest @params)
        {
			var rg = GetRegulation();

            string serializedJson = JsonConvert.SerializeObject(@params.info, Formatting.Indented);

            Record record = (Record)@params.info;
            Result result = (Result)@params.result;

            var sim = Simulator.Simulation(rg, serializedJson, false);

            var record1 = JsonConvert.SerializeObject(record, Formatting.Indented);
            var result1 = JsonConvert.SerializeObject(result, Formatting.Indented);
            var simRec = JsonConvert.SerializeObject(sim, Formatting.Indented);
            var simRes = JsonConvert.SerializeObject(sim.result, Formatting.Indented);

            if (result.winSide == sim.result.winSide)
            {
                if (result.totalAttackDamage == sim.result.totalAttackDamage)
                {
                }
            }

            File.WriteAllText("record.json", record1);
            File.WriteAllText("result1.json", result1);
            File.WriteAllText("simRec.json", simRec);
            File.WriteAllText("simRes.json", simRes);

            return "{}";
        }
    }

    public class BattleOutRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

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
		if (battleData == null)
		{
			yield break;
		}
		if (battleData.type != EBattleType.GuildScramble && result == null)
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
				WorldMapStageDataRow worldMapStageDataRow = this.regulation.worldMapStageDtbl[battleData.stageId];
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
				if (battleResult.resource != null)
				{
					battleResult2.plunderResult.SetGetExp(0);
				}
				if (battleResult.rewardList != null)
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
		if (battleResult != null)
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
			if (uisimplePopup != null)
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
			if (uisimplePopup2 != null)
			{
				uisimplePopup2.onClose = delegate
				{
					Application.Quit();
				};
			}
		}
		yield break;
	}*/