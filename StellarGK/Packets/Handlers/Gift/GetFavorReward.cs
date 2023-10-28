namespace StellarGK.Packets.Handlers.Gift
{
    public class GetFavorReward
    {
    }
}

/*	// Token: 0x0600608E RID: 24718 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4308", true, true)]
	public void GetFavorReward(int cid, int step)
	{
	}

	// Token: 0x0600608F RID: 24719 RVA: 0x001B07BC File Offset: 0x001AE9BC
	private IEnumerator GetFavorRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		RoCommander roCommander = this.localUser.FindCommander(this._FindRequestProperty(request, "cid"));
		roCommander.favorRewardStep = int.Parse(this._FindRequestProperty(request, "step"));
		if (result.commander == null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		if (this.regulation.FindCostumeData(int.Parse(this.localUser.thumbnailId)).cid == int.Parse(this._FindRequestProperty(request, "cid")))
		{
			UIManager.instance.world.mainCommand.spineTest.SetInteraction(roCommander);
		}
		yield break;
	}*/