namespace StellarGK.Packets.Handlers.Conquest
{
    public class GetConquestRadar
    {
    }
}

/*	// Token: 0x0600607B RID: 24699 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7512", true, true)]
	public void GetConquestRadar()
	{
	}

	// Token: 0x0600607C RID: 24700 RVA: 0x001B0650 File Offset: 0x001AE850
	private IEnumerator GetConquestRadarResult(JsonRpcClient.Request request, Protocols.GetRadarData result)
	{
		if (result != null)
		{
			UIConquestMap conquestMap = UIManager.instance.world.conquestMap;
			if (conquestMap.isActive)
			{
				conquestMap.SetRadar();
				conquestMap.StartRadar(result.radar);
			}
		}
		yield break;
	}

	// Token: 0x0600607D RID: 24701 RVA: 0x001B066C File Offset: 0x001AE86C
	private IEnumerator GetConquestRadarError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
		}
		else if (code = 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code = 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/