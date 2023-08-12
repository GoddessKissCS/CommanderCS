using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Carnival
{
    [Command(Id = CommandId.CheckBadge)]
    public class CheckBadge : BaseCommandHandler<CheckBadgeRequest>
    {

        public override object Handle(CheckBadgeRequest @params)
        {

            var user = GetGameProfile().userBadges;

            // TODO ADJUST THIS SHIT
            CheckBadgeMaster checkBadgeMaster = new()
            {
                id = BasePacket.Id,
                arena = user.arena,
                dlms = user.dlms,
                achv = user.achv,
                rwd = user.rwd,
                shop = user.shop,
                cnvl = user.cnvl,
                ccnv = user.ccnv,
                cnvl2 = user.cnvl2,
                ccvn2 = user.ccvn2,
                cnvl3 = user.cnvl3,
                ccvn3 = user.ccvn3,
                wb = user.wb,
                gb = user.gb,
                grp = user.grp,
                ercnt = user.ercnt,
                iftw = user.iftw,
            };


            return checkBadgeMaster;
        }

        public class CheckBadgeMaster
        {
            [JsonPropertyName("id")]
            public string id { get; set; }
            [JsonPropertyName("arena")]
            public int arena { get; set; }
            [JsonPropertyName("dlms")]
            public int dlms { get; set; }
            [JsonPropertyName("achv")]
            public int achv { get; set; }
            [JsonPropertyName("rwd")]
            public int rwd { get; set; }
            [JsonPropertyName("shop")]
            public Dictionary<string, int> shop { get; set; }
            [JsonPropertyName("cnvl")]
            public List<string> cnvl { get; set; }
            [JsonPropertyName("ccnv")]
            public int ccnv { get; set; }
            [JsonPropertyName("cnvl2")]
            public List<string> cnvl2 { get; set; }
            [JsonPropertyName("ccvn2")]
            public int ccvn2 { get; set; }
            [JsonPropertyName("cnvl3")]
            public List<string> cnvl3 { get; set; }
            [JsonPropertyName("ccvn3")]
            public int ccvn3 { get; set; }
            [JsonPropertyName("wb")]
            public int wb { get; set; }
            [JsonPropertyName("gb")]
            public int gb { get; set; }
            [JsonPropertyName("grp")]
            public int grp { get; set; }
            [JsonPropertyName("ercnt")]
            public int ercnt { get; set; }
            [JsonPropertyName("iftw")]
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