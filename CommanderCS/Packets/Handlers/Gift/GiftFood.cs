using CommanderCS.Host;
using CommanderCS.MongoDB;
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
            string cid = @params.cid.ToString();
            string cgid = @params.cgid.ToString();

            User.CommanderData.TryGetValue(cid, out var commander);

            int favorPoint = commander.favorPoint;

            for (var i = 1; i <= @params.amnt;)
            {
                if (User.UserInventory.foodData[cgid] > 0)
                {
                    User.UserInventory.foodData[cgid] -= 1;
                }

                TryAddingFavour(@params.cgid, ref favorPoint);

                i++;
            }

            commander.favr += favorPoint;
            commander.favorPoint = favorPoint;

            User.CommanderData[cid] = CheckCommanderFavour(commander, Regulation);

            DatabaseManager.GameProfile.UpdateUserData(SessionId, User);
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

            if (commander.favorStep == 0)
            {
                row = rg.favorStepDtbl.Find(x => x.step == 1);
            }
            else
            {
                row = rg.favorStepDtbl.Find(x => x.step == commander.favorStep + 1);
            }

            if (row == null)
            {
                row = rg.favorStepDtbl.Find(x => x.step == 15);
            }

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