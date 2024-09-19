using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.ResourceRecharge)]
    public class ResourceRecharge : BaseMethodHandler<ResourceRechargeRequest>
    {
        public override object Handle(ResourceRechargeRequest @params)
        {

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "{}",
            };

            switch (@params.vidx)
            {
                case 106:

                    //BUY PRICE STARTS AT 15 diamonds and then + 100% everytime you buy a new ticket
                    var raidKeys = User.VipRechargeData.Find(x => x.idx == @params.vidx);

                    var ticketPrice = CalculateRaidTicketBuyPrice(User.DailyBuyables.RaidKeys, User, Regulation);

                    var count = raidKeys.count++;
                    User.DailyBuyables.RaidKeys--;

                    DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, ticketPrice, false);
                    DatabaseManager.GameProfile.UpdateVipRechargeCount(SessionId, @params.vidx, count);
                    DatabaseManager.GameProfile.UpdateDailyBuyableRaidKeys(SessionId, User.DailyBuyables.RaidKeys);

                    var userInfo = GetDatabaseUserInformationResponse(User);

                    response.Result = JObject.FromObject(userInfo);
                    return response;
            }

            return response;
        }

#warning not finished

        public int CalculateRaidTicketBuyPrice(int ticketsLeft, GameProfileScheme user, Regulation rg)
        {
            const int startingPrice = 15; // Starting price in diamonds
            const int maxTickets = 5; // Maximum number of tickets
            const double increasePercentage = 1.0; // Percentage increase for each ticket (100%)

            var vipData = rg.VipBenefitsDtbl.Find(x => x.vipLevel == user.UserResources.vipLevel);

            if (user.DailyBuyables.RaidKeys > vipData.dailyRaidTicketRefill)
            {
                throw new ArgumentException();
            }
            else if (ticketsLeft > maxTickets)
            {
                throw new ArgumentException("Number of tickets left exceeds maximum limit.");
            }

            // Calculate the current buy price based on the remaining tickets
            double totalPrice = startingPrice * Math.Pow(2, maxTickets - ticketsLeft) - startingPrice;

            return (int)totalPrice;
        }
    }

    public class ResourceRechargeRequest
    {
        [JsonProperty("vidx")]
        public int vidx { get; set; }

        [JsonProperty("mid")]
        public int mid { get; set; }

        [JsonProperty("vcnt")]
        public int vcnt { get; set; }
    }
}

/*	// Token: 0x06005FE0 RID: 24544 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1503", true, true)]
	public void ResourceRecharge(int vidx, int mid, int vcnt)
	{
	}

	// Token: 0x06005FE1 RID: 24545 RVA: 0x001AF8DC File Offset: 0x001ADADC
	private IEnumerator ResourceRechargeResult(JsonRpcClient.Request request, object result, object rsoc)
	{
		string text = this._FindRequestProperty(request, "vidx");
		int num = 0;
		VipRechargeDataRow vipRechargeDataRow = this.regulation.vipRechargeDtbl[text];
		if (vipRechargeDataRow.type = 1 || vipRechargeDataRow.type = 4)
		{
			if (this.localUser.resourceRechargeList.ContainsKey(text))
			{
				num = this.localUser.resourceRechargeList[text];
			}
			else
			{
				this.localUser.resourceRechargeList.Add(text, num);
			}
			num++;
			this.localUser.resourceRechargeList[text] = num;
			Protocols.UserInformationResponse userInformationResponse = this._ConvertJObject<Protocols.UserInformationResponse>(result);
			this.localUser.RefreshGoodsFromNetwork(userInformationResponse.goodsInfo);
			if (text = 109.ToString())
			{
				this.localUser.changeSkillPoint = true;
				this.RequestBulletCharge();
			}
			else if (text = 401.ToString())
			{
				UIBattleMain mainUI = UIManager.instance.battle.MainUI;
				UIBattleResult battleResult = UIManager.instance.battle.BattleResult;
				battleResult.duelResult.ResetLoseScore();
			}
		}
		else if (vipRechargeDataRow.type = 2)
		{
			string text2 = this._FindRequestProperty(request, "mid");
			if (this.localUser.stageRechargeList.ContainsKey(text2))
			{
				num = this.localUser.stageRechargeList[text2];
			}
			else
			{
				this.localUser.stageRechargeList.Add(text2, num);
			}
			num++;
			this.localUser.stageRechargeList[text2] = num;
			RoWorldMap.Stage stage = this.localUser.FindWorldMapStage(text2);
			stage.clearCount = 0;
			Protocols.UserInformationResponse.Resource resource = this._ConvertJObject<Protocols.UserInformationResponse.Resource>(rsoc);
			this.localUser.RefreshGoodsFromNetwork(resource);
		}
		else if (vipRechargeDataRow.type = 3)
		{
			if (this.localUser.resourceRechargeList.ContainsKey(text))
			{
				num = this.localUser.resourceRechargeList[text];
			}
			else
			{
				this.localUser.resourceRechargeList.Add(text, num);
			}
			num++;
			this.localUser.resourceRechargeList[text] = num;
			Protocols.RecruitCommanderListResponse recruitCommanderListResponse = this._ConvertJObject<Protocols.RecruitCommanderListResponse>(result);
			this._RefreshRecruitList(recruitCommanderListResponse);
			this.localUser.RefreshGoodsFromNetwork(recruitCommanderListResponse.resource);
		}
		if (UIManager.instance.world is not null && UIManager.instance.world.existCarnival && UIManager.instance.world.carnival.isActive)
		{
			this.RequestGetCarnivalList(UIManager.instance.world.carnival.categoryType, 0);
		}
		else
		{
			if ((vipRechargeDataRow.type = 1 || vipRechargeDataRow.type = 4) && text = 109.ToString())
			{
				yield break;
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06005FE2 RID: 24546 RVA: 0x001AF90C File Offset: 0x001ADB0C
	private IEnumerator ResourceRechargeError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 53010)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		yield break;
	}*/