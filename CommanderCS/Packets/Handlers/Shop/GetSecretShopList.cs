using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Shop
{
    [Packet(Id = Method.GetSecretShopList)]
    public class GetSecretShopList : BaseMethodHandler<GetSecretShopListRequest>
    {
        public override object Handle(GetSecretShopListRequest request)
        {
            var user = GetUserGameProfile();

            var shopData = RemoteObjectManager.instance.regulation.shopDtbl.Find(x => x.type == request.styp);

            var userResource = UserResources2Resource(user.Resources);

            SecretShop shop = new()
            {
                refreshCount = 86400,
                reset = 86400,
                shopList = [],
                resource = userResource,
                refreshTime = 86400,
            };

            //Needs to be edited to actually work and refresh and reset are different for each shop,
            //should also probably be saved per user

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

    public class GetSecretShopListRequest
    {
        [JsonProperty("styp")]
        public EShopType styp { get; set; }
    }
}

/*	// Token: 0x06006003 RID: 24579 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8200", true, true)]
	public void GetSecretShopList(int styp)
	{
	}

	// Token: 0x06006004 RID: 24580 RVA: 0x001AFC04 File Offset: 0x001ADE04
	private IEnumerator GetSecretShopListResult(JsonRpcClient.Request request, Protocols.SecretShop result)
	{
		if (result !=null && result.shopList.Count != 0)
		{
			string text = this._FindRequestProperty(request, "styp");
			if (text = 3.ToString())
			{
				this.localUser.badgeRaidShop = false;
			}
			else if (text = 2.ToString())
			{
				this.localUser.badgeChallengeShop = false;
			}
			else if (text = 7.ToString())
			{
				this.localUser.badgeWaveDuelShop = false;
			}
			this.localUser.shopList = result.shopList;
			this.localUser.shopRefreshTime.SetByDuration((double)result.refreshTime);
			this.localUser.shopRefreshCount = result.refreshCount;
			this.localUser.shopRefreshFree = result.reset = 0;
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/