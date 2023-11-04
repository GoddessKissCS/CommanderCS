namespace StellarGK.Packets.Handlers.Payment
{
    public class MakeOrderId
    {
    }
}

/*	// Token: 0x06006009 RID: 24585 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7202", true, true)]
	public void MakeOrderId(string productId)
	{
	}

	// Token: 0x0600600A RID: 24586 RVA: 0x001AFC78 File Offset: 0x001ADE78
	private IEnumerator MakeOrderIdResult(JsonRpcClient.Request request, string result, string payload)
	{
		this.localUser.lastIOSPayload = payload;
		GameBillingManager.purchase(this.localUser.lastBuyPid, payload);
		yield break;
	}

	// Token: 0x0600600B RID: 24587 RVA: 0x001AFC9C File Offset: 0x001ADE9C
	private IEnumerator MakeOrderIdError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 10129)
		{
			NetworkAnimation.Instance.CreateFloatingText("Error Code:" + code);
		}
		else if (code = 10128)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("10000207"));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText("Error Code:" + code);
		}
		yield break;
	}*/