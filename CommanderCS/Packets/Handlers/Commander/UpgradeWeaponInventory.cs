using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.UpgradeWeaponInventory)]
    public class UpgradeWeaponInventory : BaseMethodHandler<UpgradeWeaponInventoryRequest>
    {
        public override object Handle(UpgradeWeaponInventoryRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            User.Resources.cash -= RemoteObjectManager.DefineDataTable.WEAPON_INVENTORY_ADDCASH;

            User.Statistics.WeaponInventoryCount += RemoteObjectManager.DefineDataTable.WEAPON_INVENTORY_ADD;

            DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, RemoteObjectManager.DefineDataTable.WEAPON_INVENTORY_ADDCASH, false);
            DatabaseManager.GameProfile.UpdateWeaponInventoryCount(SessionId, User.Statistics.WeaponInventoryCount);

            var rsoc = UserResources2Resource(User.Resources);
            var uifo = UserStatistics2BattleStatistics(User.Statistics);

            UpgradeWeaponInventoryResponse weaponInventoryResponse = new()
            {
                uifo = uifo,
                rsoc = rsoc,
            };

            ResponsePacket response = new() { Id = BasePacket.Id, Result = weaponInventoryResponse };

            return response;
        }

        public class UpgradeWeaponInventoryResponse
        {
            public UserInformationResponse.BattleStatistics uifo { get; set; }

            public UserInformationResponse.Resource rsoc { get; set; }
        }
    }

    public class UpgradeWeaponInventoryRequest
    {
    }
}

/*	// Token: 0x0600617E RID: 24958 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8513", true, true)]
	public void UpgradeWeaponInventory()
	{
	}

	// Token: 0x0600617F RID: 24959 RVA: 0x001B1B84 File Offset: 0x001AFD84
	private IEnumerator UpgradeWeaponInventoryResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.BattleStatistics uifo, Protocols.UserInformationResponse.Resource rsoc)
	{
		this.localUser.statistics.weaponInventoryCount = uifo.weaponInventoryCount;
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006180 RID: 24960 RVA: 0x001B1BB0 File Offset: 0x001AFDB0
	private IEnumerator UpgradeWeaponInventoryError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/