namespace StellarGK.Packets.Handlers.Conquest
{
    public class SetConquestTroop
    {
    }
}

/*	// Token: 0x06006060 RID: 24672 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7503", true, true)]
	public void SetConquestTroop(int slot, JObject deck)
	{
	}

	// Token: 0x06006061 RID: 24673 RVA: 0x001B03CC File Offset: 0x001AE5CC
	private IEnumerator SetConquestTroopResult(JsonRpcClient.Request request, string result)
	{
		if (result.Equals("True"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(this._FindRequestProperty(request, "deck"));
			string text = this._FindRequestProperty(request, "slot");
			for (int i = 0; i < this.localUser.commanderList.Count; i++)
			{
				RoCommander roCommander = this.localUser.commanderList[i];
				if (roCommander.conquestDeckId == int.Parse(text))
				{
					roCommander.conquestDeckId = 0;
				}
			}
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				RoCommander roCommander2 = this.localUser.FindCommander(keyValuePair.Value);
				roCommander2.conquestDeckId = int.Parse(text);
			}
			this.localUser.RefreshConquestTroop(int.Parse(text), dictionary);
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110323"));
			UIManager.instance.world.readyBattle.CloseAnimation();
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006062 RID: 24674 RVA: 0x001B03F8 File Offset: 0x001AE5F8
	private IEnumerator SetConquestTroopError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.Close();
		}
		else if (code == 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71507)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71503)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		else if (code == 71504)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/