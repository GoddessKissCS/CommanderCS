using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Carnival
{
    [Packet(Id = Method.CheckBadge)]
    public class CheckBadge : BaseMethodHandler<CheckBadgeRequest>
    {
        public override object Handle(CheckBadgeRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

            var badges = User.UserBadges;

            var rwd = User.MailDataList.Where(x => x.__receive == "0").Count();

            //TODO Check on thing if anything new exists.

            CheckBadgeMaster checkBadgeMaster = new()
            {
                id = BasePacket.Id,
                arena = badges.arena,
                dlms = badges.dlms,
                achv = badges.achv,
                rwd = rwd,
                shop = badges.shop,
                cnvl = badges.cnvl,
                ccnv = badges.ccnv,
                cnvl2 = badges.cnvl2,
                ccvn2 = badges.ccvn2,
                cnvl3 = badges.cnvl3,
                ccvn3 = badges.ccvn3,
                wb = badges.wb,
                gb = badges.gb,
                grp = badges.grp,
                ercnt = badges.ercnt,
                iftw = badges.iftw,
            };

            return checkBadgeMaster;
        }

        public class CheckBadgeMaster
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("arena")]
            public int arena { get; set; }

            [JsonProperty("dlms")]
            public int dlms { get; set; }

            [JsonProperty("achv")]
            public int achv { get; set; }

            [JsonProperty("rwd")]
            public int rwd { get; set; }

            [JsonProperty("shop")]
            public Dictionary<string, int> shop { get; set; }

            [JsonProperty("cnvl")]
            public List<string> cnvl { get; set; }

            [JsonProperty("ccnv")]
            public int ccnv { get; set; }

            [JsonProperty("cnvl2")]
            public List<string> cnvl2 { get; set; }

            [JsonProperty("ccvn2")]
            public int ccvn2 { get; set; }

            [JsonProperty("cnvl3")]
            public List<string> cnvl3 { get; set; }

            [JsonProperty("ccvn3")]
            public int ccvn3 { get; set; }

            [JsonProperty("wb")]
            public int wb { get; set; }

            [JsonProperty("gb")]
            public int gb { get; set; }

            [JsonProperty("grp")]
            public int grp { get; set; }

            [JsonProperty("ercnt")]
            public int ercnt { get; set; }

            [JsonProperty("iftw")]
            public int iftw { get; set; }
        }
    }

    public class CheckBadgeRequest
    {
    }
}

/*
	// Token: 0x06005FFD RID: 24573 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1504", true, true)]
	public void CheckBadge()
	{
	}

	// Token: 0x06005FFE RID: 24574 RVA: 0x001AFB18 File Offset: 0x001ADD18
	private IEnumerator CheckBadgeResult(JsonRpcClient.Request request, string result, int arena, int dlms, int achv, int rwd, Dictionary<string, int> shop, List<string> cnvl, int ccnv, List<string> cnvl2, int ccnv2, List<string> cnvl3, int ccnv3, int wb, int gb, int grp, int ercnt, int iftw)
	{
		this.localUser.badgeChallenge = arena > 0;
		this.localUser.badgeMissionCount = dlms;
		this.localUser.badgeAchievementCount = achv;
		this.localUser.badgeNewMailCount = rwd;
		this.localUser.badgeRaidShop = shop.ContainsKey("raid") && shop["raid"] > 0;
		this.localUser.badgeChallengeShop = shop.ContainsKey("arena") && shop["arena"] > 0;
		this.localUser.badgeWaveDuelShop = shop.ContainsKey("arena3") && shop["arena3"] > 0;
		this.localUser.badgeCarnivalTabList[1] = cnvl;
		this.localUser.badgeCarnivalComplete[1] = ccnv != 0;
		this.localUser.badgeCarnivalTabList[2] = cnvl2;
		this.localUser.badgeCarnivalComplete[2] = ccnv2 != 0;
		this.localUser.badgeCarnivalTabList[3] = cnvl3;
		this.localUser.badgeCarnivalComplete[3] = ccnv3 != 0;
		this.localUser.badgeWaveBattle = wb != 0;
		this.localUser.badgeGuild = gb != 0;
		this.localUser.badgeGroupCount = grp;
		this.localUser.badgeEventRaidReward = ercnt > 0;
		this.localUser.badgeInfinityBattleReward = iftw > 0;
		yield break;
	}*/