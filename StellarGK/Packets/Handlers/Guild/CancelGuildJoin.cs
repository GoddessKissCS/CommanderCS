namespace StellarGK.Packets.Handlers.Guild
{
    public class CancelGuildJoin
    {
    }
}

/*	// Token: 0x0600602A RID: 24618 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7252", true, true)]
	public void CancelGuildJoin(int gidx)
	{
	}

	// Token: 0x0600602B RID: 24619 RVA: 0x001AFF3C File Offset: 0x001AE13C
	private IEnumerator CancelGuildJoinResult(JsonRpcClient.Request request, bool result)
	{
		if (!result)
		{
			UIManager.instance.world.guild.Close();
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110222"));
		}
		else
		{
			int num = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.ChangeGuildItemState(num, "list");
		}
		yield break;
	}

	// Token: 0x0600602C RID: 24620 RVA: 0x001AFF68 File Offset: 0x001AE168
	private IEnumerator CancelGuildJoinError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71304)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110222"));
		}
		yield break;
	}*/