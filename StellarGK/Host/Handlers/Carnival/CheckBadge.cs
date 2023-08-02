namespace StellarGK.Host.Handlers.Carnival
{
    [Command(Id = CommandId.CheckBadge)]
    public class CheckBadge : BaseCommandHandler<CheckBadgeRequest>
    {

        public override object Handle(CheckBadgeRequest @params)
        {
            ResponsePacket response = new()
            {
                id = BasePacket.Id,
            };

            CheckBadgeMaster checkBadgeMaster = new()
            {
                arena = 1,
                dlms = 1,
                achv = 1,
                rwd = 1,
                shop = new Dictionary<string, int>() {
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

            response.result = checkBadgeMaster;

            return response;
        }

        public class CheckBadgeMaster
        {

            public int arena { get; set; }

            public int dlms { get; set; }

            public int achv { get; set; }

            public int rwd { get; set; }

            public Dictionary<string, int> shop { get; set; }

            public List<string> cnvl { get; set; }
            public int ccnv { get; set; }

            public List<string> cnvl2 { get; set; }

            public int ccvn2 { get; set; }

            public List<string> cnvl3 { get; set; }

            public int ccvn3 { get; set; }
            public int wb { get; set; }
            public int gb { get; set; }
            public int grp { get; set; }
            public int ercnt { get; set; }
            public int iftw { get; set; }
        }
    }

    public class CheckBadgeRequest
    {

    }

}