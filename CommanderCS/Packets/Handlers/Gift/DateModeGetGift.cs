using CommanderCS.Host;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Packets.Handlers.Gift
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.DateModeGetGift)]
    public class DateModeGetGift : BaseMethodHandler<DateModeGetGiftRequest>
    {
        public override object Handle(DateModeGetGiftRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = new RewardInfo()
            };

            return response;
        }
    }

    public class DateModeGetGiftRequest
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4402", true, true)]
	public void DateModeGetGift()
	{
	}

	// Token: 0x060060D6 RID: 24790 RVA: 0x001B0D70 File Offset: 0x001AEF70
	private IEnumerator DateModeGetGiftResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		if (result.reward != null && result.reward.Count > 0)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			this.localUser.RefreshRewardFromNetwork(result);
			UIManager.instance.RefreshOpenedUI();
		}
		else
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("300005"), Localization.Get("300006"), string.Empty, Localization.Get("1001"));
		}
		if (result.commander != null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commander)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				roCommander.favorStep = keyValuePair.Value.favorStep;
				roCommander.favorPoint = keyValuePair.Value.favorPoint;
			}
		}
		UIManager.instance.world.dateMode.GetDateGift(result.time);
		yield break;
	}

	// Token: 0x060060D7 RID: 24791 RVA: 0x001B0D94 File Offset: 0x001AEF94
	private IEnumerator DateModeGetGiftError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error code:" + code);
		UIManager.instance.world.dateMode.CloseGiftPopup();
		yield break;
	}*/