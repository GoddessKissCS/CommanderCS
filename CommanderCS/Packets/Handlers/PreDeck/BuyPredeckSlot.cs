using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCS.Protocols;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.PreDeck
{
	[Packet(Id = Method.BuyPredeckSlot)]
    public class BuyPredeckSlot : BaseMethodHandler<BuyPredeckSlotRequest>
    {
		private int openCost = 1200;
		private int addOpenCost = 200;
		private int basePredeckCount = 5;

        public override object Handle(BuyPredeckSlotRequest @params)
        {
            var session = GetSession();
			var user = GetUserGameProfile();

			int cashCost = openCost + addOpenCost * (user.UserStatistics.PredeckCount - basePredeckCount);

			DatabaseManager.GameProfile.UpdateCash(session, cashCost, false);

			DatabaseManager.GameProfile.AddEmptyPreDeckSlot(session, user.UserStatistics.PredeckCount);

            user = GetUserGameProfile();
            var goods = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
            var battlestats = DatabaseManager.GameProfile.UserStatistics2BattleStatistics(user.UserStatistics);
            var guild = DatabaseManager.Guild. (user.GuildId, user.Uno);

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

                resetRemain = user.ResetDateTime, // should be set?
                /// pronabably set it globally?

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

    public class BuyPredeckSlotRequest
    {
    }

}

/*	// Token: 0x0600614A RID: 24906 RVA: 0x001B1710 File Offset: 0x001AF910
	private IEnumerator GetEventRemaingTimeError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}

	// Token: 0x0600614B RID: 24907 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5222", true, true)]
	public void BuyPredeckSlot()
	{
	}

	// Token: 0x0600614C RID: 24908 RVA: 0x001B1724 File Offset: 0x001AF924
	private IEnumerator BuyPredeckSlotResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result != null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
			this.localUser.statistics.predeckCount = result.battleStatisticsInfo.predeckCount;
			this.localUser.RefreshPreDeckFromNetwork(result.preDeck);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x0600614D RID: 24909 RVA: 0x001B1748 File Offset: 0x001AF948
	private IEnumerator BuyPredeckSlotError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/