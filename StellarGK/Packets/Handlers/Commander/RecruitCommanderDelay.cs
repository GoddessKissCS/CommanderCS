namespace StellarGK.Packets.Handlers.Commander
{
    public class RecruitCommanderDelay
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5215", true, true)]
	public void RecruitCommanderDelay(int cid, int pos)
	{
	}

	// Token: 0x06005F3E RID: 24382 RVA: 0x001AEBAC File Offset: 0x001ACDAC
	private IEnumerator RecruitCommanderDelayResult(JsonRpcClient.Request request, Protocols.RecruitCommanderDelayResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		if (string.IsNullOrEmpty(text))
		{
			yield break;
		}
		RoRecruit.Entry entry = this.localUser.recruit.Find(text);
		entry.delayTime.SetByDuration((double)result.wait);
		this.localUser.gold = result.gold;
		this.localUser.cash = result.cash;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/