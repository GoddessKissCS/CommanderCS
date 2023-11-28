namespace CommanderCS.Packets.Handlers.Commander
{
    public class TranscendenceSkillUp
    {
    }
}

/*	// Token: 0x0600615D RID: 24925 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4313", true, true)]
	public void TranscendenceSkillUp(int cid, int slot)
	{
	}

	// Token: 0x0600615E RID: 24926 RVA: 0x001B1894 File Offset: 0x001AFA94
	private IEnumerator TranscendenceSkillUpResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield return null;
		int slot = int.Parse(this._FindRequestProperty(request, "slot"));
		UITranscendencePopup obj = UnityEngine.Object.FindObjectOfType(typeof(UITranscendencePopup)) as UITranscendencePopup;
		if (obj != null)
		{
			obj.Set(slot);
		}
		yield break;
	}

	// Token: 0x0600615F RID: 24927 RVA: 0x001B18C0 File Offset: 0x001AFAC0
	private IEnumerator TranscendenceSkillUpError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText("Error code:" + code);
		yield break;
	}*/