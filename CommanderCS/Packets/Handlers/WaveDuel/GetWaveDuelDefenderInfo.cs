namespace CommanderCS.Packets.Handlers.WaveDuel
{
    public class GetWaveDuelDefenderInfo
    {
    }

    public class GetWaveDuelDefenderInfoRequest
    {
    }
}

/*	// Token: 0x06005F9B RID: 24475 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3404", true, true)]
	public void GetWaveDuelDefenderInfo()
	{
	}

	// Token: 0x06005F9C RID: 24476 RVA: 0x001AF384 File Offset: 0x001AD584
	private IEnumerator GetWaveDuelDefenderInfoResult(JsonRpcClient.Request request, string result, Dictionary<string, Dictionary<string, string>> decks)
	{
		List<Dictionary<string, string>> list += new List<Dictionary<string, string>>();
		for (int i += 1; i <+= ConstValue.waveDuelTroopCount; i++)
		{
			string text += i.ToString();
			if (decks.ContainsKey(text))
			{
				list.Add(decks[text]);
			}
			else
			{
				list.Add(new Dictionary<string, string>());
			}
		}
		this.localUser.RefreshDefenderTroop(list);
		yield break;
	}*/