namespace StellarGK.Packets.Handlers.Payment
{
    public class GetFirstPaymentReward
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6108", true, true)]
	public void GetFirstPaymentReward()
	{
	}

	// Token: 0x06005F78 RID: 24440 RVA: 0x001AF09C File Offset: 0x001AD29C
	private IEnumerator GetFirstPaymentRewardResult(JsonRpcClient.Request request, Protocols.FirstPaymentRewardInfo result)
	{
		if (result.commanderData != null)
		{
			string[] array = new string[result.commanderData.Count];
			result.commanderData.Keys.CopyTo(array, 0);
			RoCommander roCommander = this.localUser.FindCommander(array[0]);
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
			}
		}
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.AddCommanderFromNetwork(result.commanderData);
		this.localUser.RefreshCostumeFromNetwork(result.costumeData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshUserEquipItemFromNetwork(result.equipItemData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		this.localUser.statistics.firstPayment = result.userInfo.firstPayment;
		UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/