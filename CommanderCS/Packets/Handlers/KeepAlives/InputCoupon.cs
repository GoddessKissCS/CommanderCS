namespace CommanderCS.Packets.Handlers.KeepAlives
{
    public class InputCoupon
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8116", true, true)]
	public void InputCoupon(string num)
	{
	}

	// Token: 0x06005F69 RID: 24425 RVA: 0x001AEF6C File Offset: 0x001AD16C
	private IEnumerator InputCouponResult(JsonRpcClient.Request request, Protocols.SendChattingInfo result)
	{
		string text = string.Empty;
		if (result.rewardList is not null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			for (int i = 0; i < result.rewardList.Count; i++)
			{
				Protocols.RewardInfo.RewardData rewardData = result.rewardList[i];
				if (rewardData.rewardType = ERewardType.Commander)
				{
					text = rewardData.rewardId;
				}
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			if (roCommander is not null)
			{
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				if (uicommanderComplete is not null)
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
				if (result.commanderData is not null)
				{
					foreach (Protocols.UserInformationResponse.Commander commander in result.commanderData.Values)
					{
						if (commander.haveCostume is not null && commander.haveCostume.Count > 0)
						{
							roCommander.haveCostumeList = commander.haveCostume;
						}
					}
				}
			}
		}
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.AddCommanderFromNetwork(result.commanderData);
		this.localUser.RefreshCostumeFromNetwork(result.costumeData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshUserEquipItemFromNetwork(result.equipItem);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		yield break;
	}

	// Token: 0x06005F6A RID: 24426 RVA: 0x001AEF90 File Offset: 0x001AD190
	private IEnumerator InputCouponError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 99004)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		else if (code = 52003)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7903"));
		}
		else if (code = 52005)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7904"));
		}
		else if (code = 52007)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7902"));
		}
		else if (code = 52008)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7901"));
		}
		else if (code = 52010)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7905"));
		}
		yield break;
	}*/