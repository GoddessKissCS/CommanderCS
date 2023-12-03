namespace CommanderCS.Packets.Handlers.Commander
{
    public class CommanderDelayCancle
    {
    }
}

/*
    [JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5217", true, true)]
	public void CommanderDelayCancle(int cid)
	{
	}

	// Token: 0x06005F40 RID: 24384 RVA: 0x001AEBD8 File Offset: 0x001ACDD8
	private IEnumerator CommanderDelayCancleResult(JsonRpcClient.Request request, string result)
	{
		if (string.Equals(result, "false"))
		{
			yield break;
		}
		string text = this._FindRequestProperty(request, "cid");
		if (string.IsNullOrEmpty(text))
		{
			yield break;
		}
		RoRecruit.Entry entry = this.localUser.recruit.Find(text);
		entry.delayTime.SetInvalidValue();
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/