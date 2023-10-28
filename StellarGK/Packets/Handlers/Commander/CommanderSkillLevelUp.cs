namespace StellarGK.Packets.Handlers.Commander
{
    public class CommanderSkillLevelUp
    {
    }
}

/*public void CommanderSkillLevelUp(int cid, int sidx, int cnt)
	{
	}

	// Token: 0x06005F33 RID: 24371 RVA: 0x001AE97C File Offset: 0x001ACB7C
	private IEnumerator CommanderSkillLevelUpResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		string text2 = this._FindRequestProperty(request, "sidx");
		int num = int.Parse(this._FindRequestProperty(request, "cnt"));
		if (!string.IsNullOrEmpty(text))
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			roCommander.SkillLevelUp(this._ConvertStringToInt(text2), num);
		}
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/