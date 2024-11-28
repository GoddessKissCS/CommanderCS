using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Enum;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.BuyCommanderCostume)]
    public class BuyCommanderCostume : BaseMethodHandler<BuyCommanderCostumeRequest>
    {
        public override object Handle(BuyCommanderCostumeRequest @params)
        {
            // ig implement a check to check if you actually have enough cash ?
            // seems overrated but you never know ig?
            // client says no if you cant buy, but ig you could in theory send a request and buy it anyways

            string cid = @params.commanderId.ToString();

            var costumeData = Regulation.commanderCostumeDtbl.FirstOrDefault(x => x.ctid == @params.costumeId);

            // TODO MAYBECHECK WHEN WE CREATE A CHARACTER TO SEE IF WE OWN ANY COSTUMES
            // AND THEN TRANSFER THEM TO THE haveCostume and delete them from donHaveCommCostume

            //REWORK
            User.Resources.cash -= costumeData.sellPrice;

            DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, costumeData.sellPrice, false);
            var user = AddCostumeData(cid, @params.costumeId, User);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);
            DatabaseManager.GameProfile.UpdateDontHaveCommanderCostumeData(SessionId, user.Inventory.donHaveCommCostumeData);

            var userInformationResponse = GetUserInformationResponse(user);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }

        public GameProfileScheme AddCostumeData(string cid, int costumeId, GameProfileScheme user)
        {
            if (user.CommanderData.ContainsKey(cid))
            {
                user.CommanderData[cid].haveCostume.Add(costumeId);

                return user;
            }

            if (!user.Inventory.donHaveCommCostumeData.ContainsKey(cid))
            {
                user.Inventory.donHaveCommCostumeData.Add(cid, [costumeId]);
            }

            return user;
        }
    }

    public class BuyCommanderCostumeRequest
    {
        [JsonProperty("cid")]
        public int commanderId { get; set; }

        [JsonProperty("cos")]
        public int costumeId { get; set; }
    }
}

/*	// Token: 0x06006098 RID: 24728 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4306", true, true)]
	public void BuyCommanderCostume(int cid, int cos)
	{
	}

	// Token: 0x06006099 RID: 24729 RVA: 0x001B0888 File Offset: 0x001AEA88
	private IEnumerator BuyCommanderCostumeResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		int num = int.Parse(this._FindRequestProperty(request, "cos"));
		RoCommander roCommander = this.localUser.FindCommander(text);
		if (!roCommander.haveCostumeList.Contains(num))
		{
			roCommander.haveCostumeList.Add(num);
		}
		if (roCommander.state = ECommanderState.Undefined)
		{
			this.localUser.AddDonHaveCommCostume(text, num);
		}
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/