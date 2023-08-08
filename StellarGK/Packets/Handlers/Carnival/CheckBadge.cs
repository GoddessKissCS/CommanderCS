using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Carnival
{
    [Command(Id = CommandId.CheckBadge)]
    public class CheckBadge : BaseCommandHandler<CheckBadgeRequest>
    {

        public override object Handle(CheckBadgeRequest @params)
        {

            // TODO ADJUST THIS SHIT
            CheckBadgeMaster checkBadgeMaster = new()
            {
                id = BasePacket.Id,
                arena = 1,
                dlms = 1,
                achv = 1,
                rwd = 1,
                shop = new Dictionary<string, int>()
                {
                    { "raid", 0 },
                    { "arena3", 0 },
                    { "arena", 0 }
                },
                cnvl = new List<string>(),
                ccnv = 0,
                cnvl2 = new List<string>(),
                ccvn2 = 0,
                cnvl3 = new List<string>(),
                ccvn3 = 0,
                wb = 0,
                gb = 0,
                grp = 0,
                ercnt = 0,
                iftw = 0,
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