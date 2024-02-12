using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Vip
{
    [Packet(Id = Method.GetVipBuyCount)]
    public class GetVipBuyCount : BaseMethodHandler<GetVipBuyCountRequest>
    {
        public override object Handle(GetVipBuyCountRequest @params)
        {
			//gets send EVipRechargeType enum + ["rchg"]

#warning TODO: MIGHT NEED A BE CHECKED IF ITS CORRECT
			var user = GetUserGameProfile();

            GetVIPBuyCountResponse getVIPBuyCount = new()
            {
                rchg = user.VipRechargeData
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = getVIPBuyCount
            };

            return response;
        }

        public class GetVIPBuyCountResponse
        {
            [JsonProperty("rchg")]
            public List<UserInformationResponse.VipRechargeData> rchg { get; set; }
        }
    }

    public class GetVipBuyCountRequest
    {
        [JsonProperty("type")]
        public List<string> type { get; set; }

        [JsonProperty("renewType")]
        public int renewType { get; set; }
    }
}

/*
public void GetVipBuyCount(List<string> type, int renewType)
	{
	}

	// Token: 0x06005F23 RID: 24355 RVA: 0x001AE7DC File Offset: 0x001AC9DC
	private IEnumerator GetVipBuyCountResult(JsonRpcClient.Request request, string result, List<Protocols.UserInformationResponse.VipRechargeData> rchg)
	{
		if (rchg.Count = 0)
		{
			this.localUser.resourceRechargeList.Clear();
			this.localUser.stageRechargeList.Clear();
		}
		for (int i = 0; i < rchg.Count; i++)
		{
			VipRechargeDataRow vipRechargeDataRow = this.regulation.vipRechargeDtbl[rchg[i].idx.ToString()];
			if (vipRechargeDataRow.type != 2)
			{
				string text = rchg[i].idx.ToString();
				this.localUser.resourceRechargeList[text] = rchg[i].count;
			}
			else
			{
				string text2 = rchg[i].mid.ToString();
				this.localUser.stageRechargeList[text2] = rchg[i].count;
			}
		}
		int num = int.Parse(this._FindRequestProperty(request, "renewType"));
		if (num != 0)
		{
			UIManager.instance.world.mainCommand.OpenVipRechargePopUp((EVipRechargeType)num);
		}
		this._CheckReceiveTestData("GetUserInformation");
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/