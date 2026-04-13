using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Shop
{
    [Packet(Id = Method.RefreshSecretShopList)]
    public class RefreshSecretShopList : BaseMethodHandler<RefreshSecretShopListRequest>
    {
        public override object Handle(RefreshSecretShopListRequest request)
        {
            var user = GetUserGameProfile();

            var shopData = RemoteObjectManager.instance.regulation.shopDtbl.Find(x => x.type == request.styp);

            var userResource = UserResources2Resource(user.Resources);

            SecretShop shop = new()
            {
                refreshCount = 0,
                reset = 86400,
                shopList = [],
                resource = userResource,
                refreshTime = 86400,
            };

            switch (request.styp)
            {
                case EShopType.BasicShop:
                    break;

                case EShopType.ChallengeShop:
                    break;

                case EShopType.RaidShop:

                    shop.shopList.Add(new()
                    {
                        cost = 100,
                        sold = 0,
                        costType = EPriceType.RaidCoin,
                        count = 999,
                        id = 1,
                        idx = 1,
                        time = 100,
                        type = ERewardType.Commander
                    });

                    break;

                case EShopType.GuildShop:
                    break;

                case EShopType.VipShop:
                    break;

                case EShopType.AnnihilationShop:
                    break;

                case EShopType.WaveDuelShop:
                    break;

                case EShopType.WorldDuelShop:
                    break;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = shop,
            };

            return response;
        }
    }

    public class RefreshSecretShopListRequest
    {
        [JsonProperty("styp")]
        public EShopType styp { get; set; }
    }
}

/*	// Token: 0x06006005 RID: 24581 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8202", true, true)]
	public void RefreshSecretShopList(int styp)
	{
	}

	// Token: 0x06006006 RID: 24582 RVA: 0x001AFC30 File Offset: 0x001ADE30
	private IEnumerator RefreshSecretShopListResult(JsonRpcClient.Request request, Protocols.SecretShop result)
	{
		if (result != null && result.shopList.Count != 0)
		{
			this.localUser.shopList = result.shopList;
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.shopRefreshCount = result.refreshCount;
			this.localUser.shopRefreshFree = result.reset = 0;
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/
