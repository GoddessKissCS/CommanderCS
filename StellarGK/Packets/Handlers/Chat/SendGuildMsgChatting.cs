namespace StellarGK.Packets.Handlers.Chat
{
    public class SendGuildMsgChatting
    {

    }
}
/*	// Token: 0x06005FB6 RID: 24502 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gkchat.flerogames.com/talk/server.php", "sendMsg", true, true)]
	public void SendGuildMsgChatting(int guild, int send, string snm, string msg, int ucash, int thmb, int lv)
	{
	}

	// Token: 0x06005FB7 RID: 24503 RVA: 0x001AF5C8 File Offset: 0x001AD7C8
	private IEnumerator SendGuildMsgChattingResult(JsonRpcClient.Request request, Protocols.SendChattingInfo result)
	{
		this.localUser.lastChatTimeTick = DateTime.Now.Ticks;
		string text = string.Empty;
		if (result.rewardList != null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			for (int i = 0; i < result.rewardList.Count; i++)
			{
				Protocols.RewardInfo.RewardData rewardData = result.rewardList[i];
				if (rewardData.rewardType == ERewardType.Commander)
				{
					text = rewardData.rewardId;
				}
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
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
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		this.RequestSendwaitGuildMsg();
		UIManager.instance.world.mainCommand.chat.TimeOutCount = 10;
		yield break;
	}

	// Token: 0x06005FB8 RID: 24504 RVA: 0x001AF5EC File Offset: 0x001AD7EC
	private IEnumerator SendGuildMsgChattingError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 99004)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		else if (code == 52003)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7903"));
		}
		else if (code == 52005)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7904"));
		}
		else if (code == 52007)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7902"));
		}
		else if (code == 52008)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7901"));
		}
		else if (code == 52010)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7905"));
		}
		yield break;
	}*/