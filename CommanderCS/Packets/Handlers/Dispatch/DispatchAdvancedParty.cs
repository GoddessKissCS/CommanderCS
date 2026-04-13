namespace CommanderCS.Packets.Handlers.Dispatch
{
    public class DispatchAdvancedParty
    {
    }
}

/*	// Token: 0x060060A9 RID: 24745 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3236", true, true)]
	public void DispatchAdvancedParty(List<string> cids)
	{
	}

	// Token: 0x060060AA RID: 24746 RVA: 0x001B09EC File Offset: 0x001AEBEC
	private IEnumerator DispatchAdvancedPartyResult(JsonRpcClient.Request request, Protocols.AnnihilationMapInfo result)
	{
		this.localUser.lastClearAnnihilationStage = result.stage;
		List<string> list = JsonConvert.DeserializeObject<List<string>>(this._FindRequestProperty(request, "cids"));
		AnnihilateBattleDataRow annihilateBattleDataRow = this.RemoteObjectManager.instance.regulation.annihilateBattleDtbl[(this.localUser.lastClearAnnihilationStage - 1).ToString()];
		for (int i = 0; i < list.Count; i++)
		{
			RoCommander roCommander = this.localUser.FindCommander(list[i]);
			if (roCommander is not null)
			{
				roCommander.Die();
				roCommander.SetSp((float)annihilateBattleDataRow.sp);
			}
		}
		if (result.commanderStatusList is not null)
		{
			for (int j = 0; j < result.commanderStatusList.Count; j++)
			{
				Protocols.AnnihilationMapInfo.StatusData statusData = result.commanderStatusList[j];
				RoCommander roCommander2 = this.localUser.FindCommander(statusData.id);
				if (roCommander2 is not null)
				{
					roCommander2.sp = statusData.sp;
					roCommander2.dmgHp = statusData.dmghp;
				}
			}
		}
		if (result.advancePartyReward is not null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.advancePartyReward.resource);
			this.localUser.RefreshItemFromNetwork(result.advancePartyReward.eventResourceData);
			this.localUser.RefreshItemFromNetwork(result.advancePartyReward.itemData);
			this.localUser.RefreshMedalFromNetwork(result.advancePartyReward.medalData);
			this.localUser.RefreshPartFromNetwork(result.advancePartyReward.partData);
			UIManager.instance.RefreshOpenedUI();
			UIPopup.Create<UITimeMachinePopup>("TimeMachinePopup").Init(result.advancePartyReward.rewardList, ETimeMachineType.AdvanceParty);
		}
		UIAnnihilationMap annihilationMap = UIManager.instance.world.annihilationMap;
		annihilationMap.isPlay = true;
		annihilationMap.isPlayAdvanceParty = result.isPlayAdvanceParty != 0;
		annihilationMap.SetEnemy(result.enemyList);
		annihilationMap.ButtonControll();
		annihilationMap.StageOpenAnimation();
		yield break;
	}*/