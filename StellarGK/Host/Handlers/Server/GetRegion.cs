using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Server
{
    [Command(Id = CommandId.GetRegion)]
    public class GetRegion : BaseCommandHandler<GetRegionResult>
    {
        public override object Handle(GetRegionResult @params)
        {
            //1 is korea,
            //2 is Global Version 1
            //3 is Global Version 2
            //4 is Global Version 3


            var server = DatabaseManager.Server.Get(1);

            ServerInfo korea = new()
            {
                maxLv = server.maxLevel,
                maxSt = server.maxStage,
                openDt = server.openDateTime,
                svcnt = server.serverCount.ToString(),
                plcnt = server.playerCount.ToString(),
            };

            Dictionary<string, ServerInfo> infos = new()
            {
                { "1", korea }
            };


            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = infos
            };

            return response;
        }

        internal class ServerInfo
        {
            [JsonPropertyName("openDt")]
            public double openDt { get; set; }
            [JsonPropertyName("maxLv")]
            public int maxLv { get; set; }
            [JsonPropertyName("maxSt")]
            public string maxSt { get; set; }
            [JsonPropertyName("plcnt")]
            public string plcnt { get; set; }
            [JsonPropertyName("svcnt")]
            public string svcnt { get; set; }
        }


    }

    public class GetRegionResult
    {

    }
}