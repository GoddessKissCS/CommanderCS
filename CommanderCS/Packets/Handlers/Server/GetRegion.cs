using Newtonsoft.Json;
using CommanderCS.Database;

namespace CommanderCS.Host.Handlers.Server
{
    [Packet(Id = Method.GetRegion)]
    public class GetRegion : BaseMethodHandler<GetRegionResult>
    {
        public override object Handle(GetRegionResult @params)
        {
            //1 is korea,
            //2 is Global Version 1
            //3 is Global Version 2
            //4 is Global Version 3

            // we dont really need more than 1 server and global tbh

            var server = DatabaseManager.Server.Get(1);

            var playerCount = DatabaseManager.GameProfile.GetGameProfileSchemeCount();

            ServerInfo korea = new()
            {
                maxLv = server.MaxLevel,
                maxSt = server.MaxStage,
                openDt = server.OpenDate,
                svcnt = "1",
                plcnt = playerCount,
            };

            Dictionary<string, ServerInfo> serverInfo = new()
            {
                { "1", korea },
                 // { "2", korea //global },
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
            [JsonProperty("openDt")]
            public double openDt { get; set; }

            [JsonProperty("maxLv")]
            public int maxLv { get; set; }

            [JsonProperty("maxSt")]
            public string maxSt { get; set; }

            [JsonProperty("plcnt")]
            public string plcnt { get; set; }

            [JsonProperty("svcnt")]
            public string svcnt { get; set; }
        }
    }

    public class GetRegionResult
    {
    }
}