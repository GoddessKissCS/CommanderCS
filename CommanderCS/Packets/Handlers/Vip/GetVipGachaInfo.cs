using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Vip
{
    [Packet(Id = Method.GetVipGachaInfo)]
    public class GetVipGachaInfo : BaseMethodHandler<GetVipGachaInfoRequest>
    {
        public override object Handle(GetVipGachaInfoRequest @params)
        {
            VipGacha result = new();

#warning TODO: I FORGOT WHAT THIS IS EVEN FOR

            return "{}";
        }
    }

    public class GetVipGachaInfoRequest
    {
    }
}

/*	// Token: 0x060060B1 RID: 24753 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6314", true, true)]
	public void GetVipGachaInfo()
	{
	}

	// Token: 0x060060B2 RID: 24754 RVA: 0x001B0A7C File Offset: 0x001AEC7C
	private IEnumerator GetVipGachaInfoResult(JsonRpcClient.Request request, Protocols.VipGacha result)
	{
		this.localUser.gachaInfoList.Clear();
		foreach (KeyValuePair<string, Protocols.VipGacha.VipGachaInfo> keyValuePair in result.VipGachaInfoList)
		{
			this.localUser.gachaInfoList.Add(keyValuePair.Value);
		}
		this.localUser.vipGachaCount = result.gachaCount;
		this.localUser.vipGachaRefreshTime.SetByDuration((double)result.refreshTime);
		UIVipGachaContents vipGachaContents = UIManager.instance.world.vipGacha.vipGachaContents;
		if (vipGachaContents is not null)
		{
			vipGachaContents.Init(this.localUser.gachaInfoList);
			vipGachaContents.RegisterEndPopup();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/