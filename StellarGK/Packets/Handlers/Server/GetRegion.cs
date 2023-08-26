using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Server
{
    [Packet(Id = MethodId.GetRegion)]
    public class GetRegion : BaseMethodHandler<GetRegionResult>
    {
        public override object Handle(GetRegionResult @params)
        {
            //1 is korea,
            //2 is Global Version 1
            //3 is Global Version 2
            //4 is Global Version 3

#warning TODO needs a small adjust for servers and playercount

            var server = DatabaseManager.Server.Get(1);

            ServerInfo korea = new()
            {
                maxLv = server.MaxLevel,
                maxSt = server.MaxStage,
                openDt = server.OpenDate,
                svcnt = server.ServerCount.ToString(),
                plcnt = server.PlayerCount.ToString(),
            };

            Dictionary<string, ServerInfo> serverInfo = new()
            {
                { "1", korea },
                //{ "2", korea },
            };


            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = serverInfo
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