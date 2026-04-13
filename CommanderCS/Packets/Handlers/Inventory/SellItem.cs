using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Inventory
{
    [Packet(Id = Method.SellItem)]
    public class SellItem : BaseMethodHandler<SellItemRequest>
    {
        public override object Handle(SellItemRequest request)
        {
            var user = GetUserGameProfile();

            var type = request.ityp;
            var itemId = request.tidx.ToString();
            var amount = request.amnt;

            int itemPrice = 0;


            itemPrice = RemoteObjectManager.instance.regulation.itemExchangeDtbl.Find(x => x.type == type && x.typeidx == itemId).price;

            switch (type)
            {
                case EStorageType.Medal:
                    if (!user.Inventory.medalData.ContainsKey(itemId) || user.Inventory.medalData[itemId] < amount)
                        return new ErrorPacket { Id = BasePacket.Id, Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources } };
                    user.Inventory.medalData[itemId] = Math.Max(0, user.Inventory.medalData[itemId] - amount);
                    DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
                    break;

                case EStorageType.Food:
                    if (!user.Inventory.foodData.ContainsKey(itemId) || user.Inventory.foodData[itemId] < amount)
                        return new ErrorPacket { Id = BasePacket.Id, Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources } };
                    user.Inventory.foodData[itemId] = Math.Max(0, user.Inventory.foodData[itemId] - amount);
                    DatabaseManager.GameProfile.UpdateFoodData(SessionId, user.Inventory.foodData);
                    break;

                case EStorageType.Goods:
                    if (!user.Inventory.itemData.ContainsKey(itemId) || user.Inventory.itemData[itemId] < amount)
                        return new ErrorPacket { Id = BasePacket.Id, Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources } };
                    user.Inventory.itemData[itemId] = Math.Max(0, user.Inventory.itemData[itemId] - amount);
                    DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
                    break;

                case EStorageType.Part:
                    if (!user.Inventory.partData.ContainsKey(itemId) || user.Inventory.partData[itemId] < amount)
                        return new ErrorPacket { Id = BasePacket.Id, Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources } };
                    user.Inventory.partData[itemId] = Math.Max(0, user.Inventory.partData[itemId] - amount);
                    DatabaseManager.GameProfile.UpdatePartData(SessionId, user.Inventory.partData);
                    break;
            }
            
            int goldReward = amount * itemPrice;
            user.Resources.gold += goldReward;
            DatabaseManager.GameProfile.UpdateGold(SessionId, goldReward, true);

            user = GetUserGameProfile();

            SellItemData result = new()
            {
                resource = UserResources2Resource(user.Resources),
                partData = user.Inventory.partData,
                itemData = user.Inventory.itemData,
                foodData = user.Inventory.foodData,
                medalData = user.Inventory.medalData,
                eventResourceData = user.Inventory.eventResourceData,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = result,
            };

            return response;
        }
    }

    public class SellItemRequest
    {
        [JsonProperty("ityp")]
        public EStorageType ityp { get; set; }

        [JsonProperty("tidx")]
        public int tidx { get; set; }

        [JsonProperty("amnt")]
        public int amnt { get; set; }
    }
}

/*	// Token: 0x06006090 RID: 24720 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7401", true, true)]
	public void SellItem(int ityp, int tidx, int amnt)
	{
	}

	// Token: 0x06006091 RID: 24721 RVA: 0x001B07E8 File Offset: 0x001AE9E8
	private IEnumerator SellItemResult(JsonRpcClient.Request request, Protocols.SellItemData result)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		int num = int.Parse(this._FindRequestProperty(request, "ityp"));
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		NetworkAnimation.Instance.CreateFloatingText(Localization.Get("1315"));
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/
