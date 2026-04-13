using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Vip
{
    [Packet(Id = Method.GetVipGachaInfo)]
    public class GetVipGachaInfo : BaseMethodHandler<GetVipGachaInfoRequest>
    {
        public override object Handle(GetVipGachaInfoRequest request)
        {
            //this is for the vipcruise

            var user = GetUserGameProfile();

            var stored = user.ShopData.VipCruiseGacha;

            // refreshTime is stored as absolute Unix epoch; regenerate if missing or expired
            if (stored == null || stored.VipGachaInfoList == null || (int)TimeManager.CurrentEpoch >= stored.refreshTime)
            {
                stored = GenerateNewVipGacha();
                user.ShopData.VipCruiseGacha = stored;
                DatabaseManager.GameProfile.UpdateVipCruiseGacha(SessionId, stored);
            }
#warning TODO Change this to a failsafe if we didnt update the VipCruise In 2 Weeks else move it to SetupGKCronScheduler since the refresh is a CronScheduling Time
            // Send remaining seconds to client, not the absolute epoch
            var result = new VipGacha
            {
                VipGachaInfoList = stored.VipGachaInfoList,
                gachaCount = stored.gachaCount,
                refreshTime = Math.Max(0, stored.refreshTime - (int)TimeManager.CurrentEpoch),
            };

            var response = new ResponsePacket
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(result),
            };

            return response;
        }

        // Commander IDs available to feature in the VIP cruise gacha rotation
        private static readonly int[] CommanderPool = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

        // Medal counts paired with point costs for slots 2-9
        private static readonly (int count, float point)[] MedalTiers =
        [
            (10,  5),//30
            (10,  9),//25
            (10, 10),//20
            (10, 15),//15
            (20, 15),//15
            (20, 20),//10
            (30, 25),//9
            (50, 30),//5
        ];

        public VipGacha GenerateNewVipGacha()
        {
            // Pick 9 unique random commanders: 1 for the Commander slot, 8 for the Medal slots
            var shuffled = CommanderPool.OrderBy(_ => RandomGenerator.Shared.Next()).Take(9).ToArray();

            var list = new Dictionary<string, VipGacha.VipGachaInfo>
            {
                ["1"] = new() { rewardType = ERewardType.Commander, rewardIdx = shuffled[0], rewardCount = 1, rewardRate = 1, rewardPoint = 1 },
            };

            for (int i = 0; i < 6; i++)
            {
                var (count, point) = MedalTiers[i];
                list[(i + 2).ToString()] = new() { rewardType = ERewardType.Medal, rewardIdx = shuffled[i + 1], rewardCount = count, rewardRate = 1, rewardPoint = point };
            }


            // 8 is 3 convertible medal
            //9 is 500 000 gold
            //10 is 240 bullets

            //probably should be put into a seperate class to have the hardcoded
            list["8"] = new() { rewardType = ERewardType.Goods, rewardIdx = 202, rewardCount = 3, rewardRate = 1, rewardPoint = 15 };
            list["9"] = new() { rewardType = ERewardType.Goods, rewardIdx = 3, rewardCount = 500000, rewardRate = 1, rewardPoint = 20 };
            list["10"] = new() { rewardType = ERewardType.Goods, rewardIdx = 5, rewardCount = 240, rewardRate = 1, rewardPoint = 30 };

            var result = new VipGacha
            {
                VipGachaInfoList = list,
                gachaCount = 0,
                // Store absolute Unix epoch of next refresh (14 days from now)
                refreshTime = (int)TimeManager.CurrentEpoch + 14 * 24 * 60 * 60,
            };

            return result;
        }
    }


    public class GetVipGachaInfoRequest
    {
    }
}

/*	// Token: 0x060060B1 RID: 24753 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6314", true, true)]
	public void GetVipGachaInfo()
	{
	}

	// Token: 0x060060B2 RID: 24754 RVA: 0x001B0A7C File Offset: 0x001AEC7C
	private IEnumerator GetVipGachaInfoResult(JsonRpcClient.Request request, Protocols.VipGacha result)
	{
		this.localUser.gachaInfoList.Clear();
		foreach (KeyValuePair<string, Protocols.VipGacha.VipGachaInfo> keyValuePair in result.VipGachaInfoList)
		{
			this.localUser.gachaInfoList.Add(keyValuePair.Value);
		}
		this.localUser.vipGachaCount = result.gachaCount;
		this.localUser.vipGachaRefreshTime.SetByDuration((double)result.refreshTime);
		UIVipGachaContents vipGachaContents = UIManager.instance.world.vipGacha.vipGachaContents;
		if (vipGachaContents !=null)
		{
			vipGachaContents.Init(this.localUser.gachaInfoList);
			vipGachaContents.RegisterEndPopup();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/
