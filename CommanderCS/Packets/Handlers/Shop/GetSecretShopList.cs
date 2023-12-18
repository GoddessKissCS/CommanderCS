using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;


namespace CommanderCS.Packets.Handlers.Shop
{
    [Packet(Id = Method.GetSecretShopList)]
    public class GetSecretShopList : BaseMethodHandler<GetSecretShopListRequest>
    {
        public override object Handle(GetSecretShopListRequest @params)
        {
            SecretShop shop = new()
            {
                refreshCount = 86400,
                reset = 86400,
                shopList = [],
                resource = null,
                refreshTime = 86400,
            };

            switch (@params.styp)
            {
                case 1: // normal shop
                    break;

                case 2: // ChallengeShop shop
                    break;

                case 3: // raid shop
                    break;

                case 7: //waveduel shop
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
        public int styp { get; set; }
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
		if (result != null && result.shopList.Count != 0)
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