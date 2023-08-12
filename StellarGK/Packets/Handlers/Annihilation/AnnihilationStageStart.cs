namespace StellarGK.Packets.Handlers.Annihilation
{
    public class AnnihilationStageStart
    {

    }
}
/*	// Token: 0x060060AB RID: 24747 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3731", true, true)]
	public void AnnihilationStageStart(int type, JObject deck, JObject gdp, int ucash, int mst)
	{
	}

	// Token: 0x060060AC RID: 24748 RVA: 0x001B0A18 File Offset: 0x001AEC18
	private IEnumerator AnnihilationStageStartResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result != null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		}
		Loading.Load(Loading.Battle);
		yield break;
	}*/