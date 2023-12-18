namespace CommanderCS.Packets.Handlers.Payment
{
    public class CheckPayment
    {
    }

    public class CheckPaymentRequest
    {
    }
}

/*	// Token: 0x0600600C RID: 24588 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7101", true, true)]
	public void CheckPayment(string packageName, string productId, double purchaseTime, int purchaseState, string developerPayload, string purchaseToken, string orderId)
	{
	}

	// Token: 0x0600600D RID: 24589 RVA: 0x001AFCB8 File Offset: 0x001ADEB8
	private IEnumerator CheckPaymentResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		base.StartCoroutine(this.CheckPaymentTotalResult(request, result));
		yield break;
	}*/