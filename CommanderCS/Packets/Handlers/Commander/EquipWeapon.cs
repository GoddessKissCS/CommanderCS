using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.EquipWeapon)]
    public class EquipWeapon : BaseMethodHandler<EquipWeaponRequest>
    {
        public override object Handle(EquipWeaponRequest request)
        {
            var user = GetUserGameProfile();

            var cid = request.cid.ToString();
            var wno = request.wno.ToString();

            // Check if weapon exists in inventory
            if (!user.Inventory.weaponList.ContainsKey(wno))
            {
                return new ErrorPacket
                {
                    Id = BasePacket.Id,
                    Error = new ErrorMessageId
                    {
                        code = ErrorCode.Failure
                    }
                };
            }

            // Check if commander exists
            if (!user.CommanderData.ContainsKey(cid))
            {
                return new ErrorPacket
                {
                    Id = BasePacket.Id,
                    Error = new ErrorMessageId
                    {
                        code = ErrorCode.Failure
                    }
                };
            }

            var weapon = user.Inventory.weaponList[wno];
            var commander = user.CommanderData[cid];

            if (weapon.commander_id != 0)
            {
                var prevCid = weapon.commander_id.ToString();
                if (user.CommanderData.ContainsKey(prevCid))
                {
                    user.CommanderData[prevCid].equipWeaponInfo.Remove(wno);
                }
            }

            // Equip weapon on the new commander
            weapon.commander_id = request.cid;
            commander.equipWeaponInfo[wno] = weapon;


            user.CommanderData[cid].equipWeaponInfo[wno] = weapon;
            user.Inventory.weaponList[wno] = weapon;

            DatabaseManager.GameProfile.UpdateSpecificWeaponList(SessionId, weapon, wno);
            DatabaseManager.GameProfile.UpdateSpecificCommander(SessionId, user.CommanderData[cid]);

            Dictionary<string, WeaponData> weaponResult = new()
            {
                { wno, weapon }
            };

            WeaponResponse weaponResponse = new()
            {
                weapon = weaponResult
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = weaponResponse,
            };

            return response;
        }
    }

    public class WeaponResponse
    {
        public Dictionary<string, WeaponData> weapon { get; set; }
    }

    public class EquipWeaponRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("wno")]
        public int wno { get; set; }
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
			if (roCommander is not null)
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
