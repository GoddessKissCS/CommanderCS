using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Database.Schemes;
using StellarGKLibrary.Protocols;

namespace StellarGK.Host.Handlers.Server
{
    [Packet(Id = Method.ServerStatus)]
    public class ServerStatus : BaseMethodHandler<ServerStatusRequest>
    {
        public override object Handle(ServerStatusRequest @params)
        {
#warning TODO
            // needs to be reworked

            // iterate through every server where you have a account
            // if not just use nullserver

            ResponsePacket response = new();

            ServerData serverData = new();

            var serverinfos = ProfilesRequest(@params.mIdx, GetSession());

            if(serverinfos.Count > 4)
            {
                //add more server channels etc

                ServerData.ServerInfo nullServer = new()
                {
                    idx = 0,
                    status = 0,
                    lastLoginTime = 0,
                    level = 0,
                    thumnail = 0,
                };
            }

            serverData.serverInfoList = serverinfos;
            serverData.recommandServer = 1;
            serverData.newServer = 1;

            response.Id = BasePacket.Id;
            response.Result = serverData;

            return response;
        }

        private static List<ServerData.ServerInfo> ProfilesRequest(string mIdx, string session)
        {
            List<ServerData.ServerInfo> serverInfo = [];

            var list = DatabaseManager.GameProfile.FindByMemberIdList(mIdx);

            int i = 0;
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
                    lastLoginTime = (int)profile.LastLoginTime,
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