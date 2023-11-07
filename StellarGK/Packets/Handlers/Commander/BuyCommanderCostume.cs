using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGK.Host;
using StellarGKLibrary.ExcelReader;
using StellarGKLibrary.Protocols;
using System.Net;

namespace StellarGK.Packets.Handlers.Commander
{
    [Packet(Id = Method.BuyCommanderCostume)]
    public class BuyCommanderCostume : BaseMethodHandler<BuyCommanderCostumeRequest>
    {
        public override object Handle(BuyCommanderCostumeRequest @params)
        {
			var user = GetUserGameProfile();
			var session = GetSession();

			var costumeData = CommanderCostumeData.GetInstance().FromCostumeId(@params.cos);

            // ig implement a check to check if you actually have enough cash ?
            // seems overrated but you never know ig?

            if(user.UserResources.cash > 1200)
            {
               //user.UserResources.cash = 0;
            }

			string cid = "" + @params.cid;

            if (user.CommanderData.ContainsKey(cid) && user.UserInventory.donHaveCommCostumeData.ContainsKey(cid))
            {
                user.CommanderData[cid].haveCostume.Add(@params.cos);
                user.UserInventory.donHaveCommCostumeData[cid].Add(@params.cos);
                user.UserResources.cash -= costumeData.sellPrice;
            }
            else if (!user.UserInventory.donHaveCommCostumeData.ContainsKey(cid))
            {
                user.UserInventory.donHaveCommCostumeData.Add(cid, [@params.cos]);
                user.UserResources.cash -= costumeData.sellPrice;
            }
            else
            {
                user.UserInventory.donHaveCommCostumeData[cid].Add(@params.cos);
                user.UserResources.cash -= costumeData.sellPrice;
            }


            DatabaseManager.GameProfile.UpdateProfile(session, user);

            var goods = DatabaseManager.GameProfile.UserResourcesFromSession(session);
            var battlestats = DatabaseManager.GameProfile.UserStatisticsFromSession(session);
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
                sweepClearData = user.SweepClearData,
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