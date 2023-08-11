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