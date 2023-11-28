using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Database.Schemes;
using CommanderCS.Protocols;

namespace CommanderCS.Host.Handlers.Server
{
    [Packet(Id = Method.ServerStatus)]
    public class ServerStatus : BaseMethodHandler<ServerStatusRequest>
    {
        public override object Handle(ServerStatusRequest @params)
        {
            var serverinfos = ProfilesRequest(@params.mIdx);

            int nextIdx = 1;

            while (serverinfos.Count < 1)
            {

                if (serverinfos.Any(server => server.idx == nextIdx))
                {
                    nextIdx++;
                    continue;
                }

                ServerData.ServerInfo nullServer = new()
                {
                    idx = nextIdx,
                    status = 1,
                    lastLoginTime = 0,
                    level = 0,
                    thumnail = 0,
                };

                serverinfos.Add(nullServer);
                nextIdx++;
            }

            ServerData serverData = new()
            {
                serverInfoList = serverinfos,
                recommandServer = 1,
                newServer = 1
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = serverData
            };

            return response;
        }

        private static List<ServerData.ServerInfo> ProfilesRequest(string mIdx)
        {
            List<ServerData.ServerInfo> serverInfo = [];

            var list = DatabaseManager.GameProfile.FindByMemberIdList(mIdx);

            int i = 1;
            foreach (GameProfileScheme profile in list)
            {
                ServerData.ServerInfo SIFO = new()
                {
                    status = 1,
                    // 1 = Medium
                    // 2 = Busy
                    // 3 = Full
                    // 4 = Unable to join
                    idx = i,
                    lastLoginTime = profile.LastLoginTime,
                    level = profile.UserResources.level,
                    thumnail = profile.UserResources.thumbnailId                     
                };
                i++;

                serverInfo.Add(SIFO);
            }

            return serverInfo;
        }
    }

    public class ServerStatusRequest
    {
        [JsonProperty("mIdx")]
        public string mIdx { get; set; }

        [JsonProperty("tokn")]
        public string tokn { get; set; }

        [JsonProperty("srv")]
        public int srv { get; set; }
    }
}