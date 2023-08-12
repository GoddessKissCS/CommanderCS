namespace StellarGK.Packets.Handlers.KeepAlives
{
    public class GetReward
    {

    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6102", true, true)]
	public void GetReward(int idx, int type)
	{
	}

	// Token: 0x06005F70 RID: 24432 RVA: 0x001AEFF4 File Offset: 0x001AD1F4
	private IEnumerator GetRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "idx");
		RoReward roReward = this.localUser.FindReward(text);
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.rewardList.Remove(roReward);
		this.localUser.newMailCount--;
		this.localUser.badgeNewMailCount--;
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.world.mail.Set(EReward.Mail);
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("GetRewardResult");
		yield break;
	}*/