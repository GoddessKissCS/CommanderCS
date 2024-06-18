using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Gift
{
    [Packet(Id = Method.GiftFood)]
    public class GiftFood : BaseMethodHandler<GiftFoodRequest>
    {
        public override object Handle(GiftFoodRequest @params)
        {
            string commanderId = @params.cid.ToString();
            string favourGiftId = @params.cgid.ToString();
            int favourGiftAmount = @params.amnt;

            User.CommanderData.TryGetValue(commanderId, out var commander);

            int commanderfavorPoint = commander.favorPoint;
            
            //might need to add the thing to remove the entry upon reaching 0 of the gifted item

            for (var i = 1; i <= favourGiftAmount;)
            {
                if (User.UserInventory.foodData[favourGiftId] > 0)
                {
                    User.UserInventory.foodData[favourGiftId] -= 1;
                }

                TryAddingFavour(@params.cgid, ref commanderfavorPoint);

                i++;
            }

            // adding to favr might not be needed needs to be rechecked in the future
            commander.favr += commanderfavorPoint;
            commander.favorPoint = commanderfavorPoint;

            var commanderCID = CheckCommanderFavour(commander, Regulation);


            User.CommanderData[commanderId] = commanderCID;

            DatabaseManager.GameProfile.UpdateSpecificCommander(SessionId, commanderCID);
            UserInformationResponse informationResponse = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = informationResponse,
            };

            return response;
        }

        private static bool TryAddingFavour(int affectionId, ref int favour)
        {
            if (!AffectionList.TryGetValue(affectionId, out var addingFavour))
            {
                throw new Exception($"Grade {affectionId} Not Defined");
            }

            favour += addingFavour;

            return true;
        }

        private static Dictionary<int, int> AffectionList = new()
        {
            { 50, 10 },
            { 51, 30 },
            { 52, 50 },
            { 53, 150 },
            { 54, 300 },
            { 55, 500 },
            { 59, 1000 },
            { 60, 2000 },
            { 61, 3000 },
            { 62, 4000 },
            { 63, 6000 },
            { 64, 9000 }
        };



        private static UserInformationResponse.Commander CheckCommanderFavour(UserInformationResponse.Commander commander, Regulation rg)
        {
            FavorStepDataRow row = new();

            switch (commander.favorStep)
            {
                case 0:
                    row = rg.favorStepDtbl.Find(x => x.step == 1);
                    break;
                case 1:
                    row = rg.favorStepDtbl.Find(x => x.step == 2);
                    break;
                case 2:
                    row = rg.favorStepDtbl.Find(x => x.step == 3);
                    break;
                case 3:
                    row = rg.favorStepDtbl.Find(x => x.step == 4);
                    break;
                case 4:
                    row = rg.favorStepDtbl.Find(x => x.step == 5);
                    break;
                case 5:
                    row = rg.favorStepDtbl.Find(x => x.step == 6);
                    break;
                case 6:
                    row = rg.favorStepDtbl.Find(x => x.step == 7);
                    break;
                case 7:
                    row = rg.favorStepDtbl.Find(x => x.step == 8);
                    break;
                case 8:
                    row = rg.favorStepDtbl.Find(x => x.step == 9);
                    break;
                case 9:
                    row = rg.favorStepDtbl.Find(x => x.step == 10);
                    break;
                case 10:
                    row = rg.favorStepDtbl.Find(x => x.step == 11);
                    break;
                case 11:
                    row = rg.favorStepDtbl.Find(x => x.step == 12);
                    break;
                case 12:
                    row = rg.favorStepDtbl.Find(x => x.step == 13);
                    break;
                case 13:
                    row = rg.favorStepDtbl.Find(x => x.step == 14);
                    break;
                case 14:
                    row = rg.favorStepDtbl.Find(x => x.step == 15);
                    break;
            };


            if (commander.favorPoint > row.favor)
            {
                commander.favorStep += 1;
                commander.favorPoint -= row.favor;

                if (commander.favorStep == 15 && commander.favorPoint >= 1000000)
                {
                    commander.favorPoint = 1000000;
                }

                return CheckCommanderFavour(commander, rg);
            }

            return commander;
        }
    }

    public class GiftFoodRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("cgid")]
        public int cgid { get; set; }

        [JsonProperty("amnt")]
        public int amnt { get; set; }
    }
}

/*	// Token: 0x0600608C RID: 24716 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4307", true, true)]
	public void GiftFood(int cid, int cgid, int amnt)
	{
	}

	// Token: 0x0600608D RID: 24717 RVA: 0x001B0798 File Offset: 0x001AE998
	private IEnumerator GiftFoodResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result.commanderInfo != null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderInfo)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				roCommander.favorStep = keyValuePair.Value.favorStep;
				roCommander.favorPoint = keyValuePair.Value.favorPoint;
			}
		}
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		UIManager.instance.RefreshOpenedUI();
		this.localUser.sendingGift = false;
		yield break;
	}*/