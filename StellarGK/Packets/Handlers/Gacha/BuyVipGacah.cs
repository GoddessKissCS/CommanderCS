namespace StellarGK.Packets.Handlers.Gacha
{
    public class BuyVipGacah
    {

    }
}
/*	// Token: 0x060060B3 RID: 24755 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6313", true, true)]
	public void BuyVipGacah()
	{
	}

	// Token: 0x060060B4 RID: 24756 RVA: 0x001B0AA0 File Offset: 0x001AECA0
	private IEnumerator BuyVipGacahResult(JsonRpcClient.Request request, Protocols.VipGacha result)
	{
		List<Protocols.VipGacha.VipGachaResult> gacharesult = result.gacharesult;
		Protocols.RewardInfo.RewardData rewardData = new Protocols.RewardInfo.RewardData();
		List<Protocols.RewardInfo.RewardData> list = new List<Protocols.RewardInfo.RewardData>();
		ERewardType erewardType = ERewardType.Undefined;
		int num = -1;
		for (int i = 0; i < this.localUser.gachaInfoList.Count; i++)
		{
			if (this.localUser.gachaInfoList[i].rewardType == gacharesult[0].rewardType_result && this.localUser.gachaInfoList[i].rewardIdx == gacharesult[0].rewardIdx_result)
			{
				num = this.localUser.gachaInfoList[i].rewardIdx;
				this.localUser.gachaInfoList[i].rewardRate--;
				erewardType = (ERewardType)gacharesult[0].rewardType_result;
				rewardData.rewardType = (ERewardType)gacharesult[0].rewardType_result;
				rewardData.rewardCnt = gacharesult[0].rewardCount_result;
				rewardData.rewardId = gacharesult[0].rewardIdx_result.ToString();
				list.Add(rewardData);
			}
		}
		if (erewardType == ERewardType.Commander)
		{
			RoCommander roCommander = RemoteObjectManager.instance.localUser.FindCommander(num.ToString());
			if (roCommander != null)
			{
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				if (uicommanderComplete != null)
				{
					if (roCommander.state != ECommanderState.Nomal)
					{
						uicommanderComplete.Init(CommanderCompleteType.Recruit, roCommander.id);
					}
					else
					{
						uicommanderComplete.Init(CommanderCompleteType.Transmission, roCommander.id);
					}
				}
				UIVipGachaContents vipGachaContents = UIManager.instance.world.vipGacha.vipGachaContents;
				if (vipGachaContents != null)
				{
					vipGachaContents.UnRegisterEndPopup();
				}
				RemoteObjectManager.instance.RequestVipGachaInfo();
			}
		}
		else if (list != null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(list, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.AddCommanderFromNetwork(result.commanderData);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		this.localUser.vipGachaCount = result.gachaCount;
		this.localUser.gachaInfoList.Clear();
		foreach (KeyValuePair<string, Protocols.VipGacha.VipGachaInfo> keyValuePair in result.VipGachaInfoList)
		{
			this.localUser.gachaInfoList.Add(keyValuePair.Value);
		}
		this.localUser.vipGachaCount = result.gachaCount;
		UIVipGachaContents vipGachaContents2 = UIManager.instance.world.vipGacha.vipGachaContents;
		if (vipGachaContents2 != null)
		{
			UIManager.instance.world.vipGacha.vipGachaContents.Init(this.localUser.gachaInfoList);
		}
		if (result.commanderData != null)
		{
			foreach (Protocols.UserInformationResponse.Commander commander in result.commanderData.Values)
			{
				RoCommander roCommander2 = this.localUser.FindCommander(commander.id);
				if (commander.haveCostume != null && commander.haveCostume.Count > 0)
				{
					roCommander2.haveCostumeList = commander.haveCostume;
				}
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/