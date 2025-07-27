using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Server
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

            var server = DatabaseManager.Region.Get(1);

            var playerCount = DatabaseManager.GameProfile.GetGameProfileSchemeCount();

            //TODO: MAKE IT BETTER LOOKING

            ServerInfo korea = new()
            {
                maxLevel = server.MaxLevel,
                maxStage = server.MaxStage,
                openDateTime = server.OpenDate,
                server_count = "1",
                player_count = playerCount,
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

        private class ServerInfo
        {
            [JsonProperty("openDt")]
            public double openDateTime { get; set; }

            [JsonProperty("maxLv")]
            public int maxLevel { get; set; }

            [JsonProperty("maxSt")]
            public string maxStage { get; set; }

            [JsonProperty("plcnt")]
            public string player_count { get; set; }

            [JsonProperty("svcnt")]
            public string server_count { get; set; }
        }
    }

    public class GetRegionResult
    {
    }
}