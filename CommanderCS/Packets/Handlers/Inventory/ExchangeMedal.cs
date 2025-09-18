using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Inventory
{
    [Packet(Id = Method.ExchangeMedal)]
    public class ExchangeMedal : BaseMethodHandler<ExchangeMedalRequest>
    {
        public override object Handle(ExchangeMedalRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            string cid = @params.cid.ToString();
            int medalExchangeAmount = @params.amnt;

            // need to implement a check that fails if user doesnt have enough , aswell in the expshare gift things etc

            // IG this helps prevent exploits

            if (User.Inventory.itemData.ContainsKey("202") == false || User.Inventory.itemData["202"] < medalExchangeAmount)
            {
                return new ErrorPacket
                {
                    Id = BasePacket.Id,
                    Error = new ErrorMessageId
                    {
                        code = ErrorCode.NotEnoughResources
                    }
                };
            }

            //User.CommanderData[cid].medl += medalExchangeAmount;
            if (!User.Inventory.medalData.ContainsKey(cid))
            {
                User.Inventory.medalData.TryAdd(cid, medalExchangeAmount);
            } else
            {
                User.Inventory.medalData[cid] += medalExchangeAmount;
                User.Inventory.itemData[cid] += medalExchangeAmount;
            }

            User.Inventory.itemData["202"] -= medalExchangeAmount;

            DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.Inventory.medalData);
            DatabaseManager.GameProfile.UpdateItemData(SessionId, User.Inventory.itemData);

            var userInformationResponse = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse
            };

            return response;
        }
    }

    public class ExchangeMedalRequest
    {
        [JsonProperty("amnt")]
        public int amnt { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}

/*	// Token: 0x06006096 RID: 24726 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5221", true, true)]
	public void ExchangeMedal(int amnt, int cid)
	{
	}

	// Token: 0x06006097 RID: 24727 RVA: 0x001B0864 File Offset: 0x001AEA64
	private IEnumerator ExchangeMedalResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		UITranscendencePopup uitranscendencePopup = UnityEngine.Object.FindObjectOfType(typeof(UITranscendencePopup)) as UITranscendencePopup;
		if (uitranscendencePopup is not null)
		{
			uitranscendencePopup.Set(0);
		}
		yield break;
	}*/