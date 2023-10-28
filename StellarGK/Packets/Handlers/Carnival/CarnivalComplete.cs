namespace StellarGK.Packets.Handlers.Carnival
{
    public class CarnivalComplete
    {
    }
}

/*	// Token: 0x060060C0 RID: 24768 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6242", true, true)]
	public void CarnivalComplete(int ctid, int cidx, int eidx, int cnt)
	{
	}

	// Token: 0x060060C1 RID: 24769 RVA: 0x001B0BB0 File Offset: 0x001AEDB0
	private IEnumerator CarnivalCompleteResult(JsonRpcClient.Request request, Protocols.CarnivalList result)
	{
		if (result != null)
		{
			string text = this._FindRequestProperty(request, "ctid");
			ECarnivalCategory categoryType = this.regulation.carnivalTypeDtbl[text].categoryType;
			if (result.rewardList != null)
			{
				UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
				SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			}
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
			this.localUser.RefreshItemFromNetwork(result.eventResourceData);
			this.localUser.RefreshItemFromNetwork(result.itemData);
			this.localUser.RefreshMedalFromNetwork(result.medalData);
			this.localUser.AddCommanderFromNetwork(result.commanderData);
			this.localUser.RefreshCostumeFromNetwork(result.costumeData);
			this.localUser.RefreshItemFromNetwork(result.foodData);
			this.localUser.RefreshUserEquipItemFromNetwork(result.equipItemData);
			this.localUser.RefreshCarnivalFromNetwork(result.carnivalProcessList);
			this.localUser.badgeCarnivalComplete[(int)categoryType] = this.localUser.badgeCarnival(categoryType);
			this.localUser.RefreshItemFromNetwork(result.groupItemData);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x060060C2 RID: 24770 RVA: 0x001B0BDC File Offset: 0x001AEDDC
	private IEnumerator CarnivalCompleteError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 20001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5065"));
		}
		yield break;
	}*/