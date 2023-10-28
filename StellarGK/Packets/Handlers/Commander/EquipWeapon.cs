namespace StellarGK.Packets.Handlers.Commander
{
    public class EquipWeapon
    {
    }
}

/*	// Token: 0x06006172 RID: 24946 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8506", true, true)]
	public void EquipWeapon(int cid, int wno)
	{
	}

	// Token: 0x06006173 RID: 24947 RVA: 0x001B1A84 File Offset: 0x001AFC84
	private IEnumerator EquipWeaponResult(JsonRpcClient.Request request, string result, Dictionary<string, Protocols.WeaponData> weapon)
	{
		foreach (KeyValuePair<string, Protocols.WeaponData> keyValuePair in weapon)
		{
			RoWeapon roWeapon = this.localUser.FindWeapon(keyValuePair.Key);
			RoCommander roCommander;
			if (roWeapon.currEquipCommanderId != 0)
			{
				roCommander = this.localUser.FindCommander(roWeapon.currEquipCommanderId.ToString());
				roCommander.RemoveWeaponItem(roWeapon.data.slotType);
			}
			roCommander = this.localUser.FindCommander(keyValuePair.Value.cid.ToString());
			if (roCommander != null)
			{
				roCommander.EquipWeaponItem(roWeapon);
				if (roCommander.EnableWeaponSet())
				{
					NetworkAnimation.Instance.CreateFloatingText(Localization.Get("70093"));
				}
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006174 RID: 24948 RVA: 0x001B1AA8 File Offset: 0x001AFCA8
	private IEnumerator EquipWeaponError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/