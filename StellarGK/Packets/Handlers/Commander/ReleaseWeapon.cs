namespace StellarGK.Packets.Handlers.Commander
{
    public class ReleaseWeapon
    {
    }
}

/*	// Token: 0x06006175 RID: 24949 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8507", true, true)]
	public void ReleaseWeapon(int cid, int wno)
	{
	}

	// Token: 0x06006176 RID: 24950 RVA: 0x001B1ABC File Offset: 0x001AFCBC
	private IEnumerator ReleaseWeaponResult(JsonRpcClient.Request request, string result, Dictionary<string, Protocols.WeaponData> weapon)
	{
		foreach (KeyValuePair<string, Protocols.WeaponData> keyValuePair in weapon)
		{
			RoWeapon roWeapon = this.localUser.FindWeapon(keyValuePair.Key);
			RoCommander roCommander = this.localUser.FindCommander(roWeapon.currEquipCommanderId.ToString());
			bool flag = roCommander.EnableWeaponSet();
			roCommander.RemoveWeaponItem(roWeapon.data.slotType);
			if (flag && !roCommander.EnableWeaponSet())
			{
				NetworkAnimation.Instance.CreateFloatingText(Localization.Get("70094"));
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006177 RID: 24951 RVA: 0x001B1AE0 File Offset: 0x001AFCE0
	private IEnumerator ReleaseWeaponError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/