using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.BuyCommanderCostume)]
    public class BuyCommanderCostume : BaseMethodHandler<BuyCommanderCostumeRequest>
    {
        public override object Handle(BuyCommanderCostumeRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();
            var rg = GetRegulation();

            // ig implement a check to check if you actually have enough cash ?
            // seems overrated but you never know ig?
            // client says no if you cant buy, but ig you could in theory send a request and buy it anyways

            string cid = @params.cid.ToString();

            var costumeData = rg.commanderCostumeDtbl.FirstOrDefault(x => x.ctid == @params.cos);

            if (user.CommanderData.ContainsKey(cid) && user.UserInventory.donHaveCommCostumeData.ContainsKey(cid))
            {
                user.CommanderData[cid].haveCostume.Add(@params.cos);
                user.UserInventory.donHaveCommCostumeData[cid].Add(@params.cos);
            }
            else if (!user.UserInventory.donHaveCommCostumeData.ContainsKey(cid))
            {
                user.UserInventory.donHaveCommCostumeData.Add(cid, [@params.cos]);
            }
            else
            {
                user.UserInventory.donHaveCommCostumeData[cid].Add(@params.cos);
            }
            user.UserResources.cash -= costumeData.sellPrice;

            DatabaseManager.GameProfile.UpdateCash(session, costumeData.sellPrice, false);
            DatabaseManager.GameProfile.UpdateCommanderData(session, user.CommanderData);
            DatabaseManager.GameProfile.UpdateDontHaveCommanderCostumeData(session, user.UserInventory.donHaveCommCostumeData);

            var goods = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
            var battlestats = DatabaseManager.GameProfile.UserStatistics2BattleStatistics(user.UserStatistics);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notifaction,

                foodData = user.UserInventory.foodData,
                eventResourceData = user.UserInventory.eventResourceData,
                groupItemData = user.UserInventory.groupItemData,
                itemData = user.UserInventory.itemData,
                medalData = user.UserInventory.medalData,
                partData = user.UserInventory.partData,

                resetRemain = user.ResetDateTime,

                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class BuyCommanderCostumeRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("cos")]
        public int cos { get; set; }
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