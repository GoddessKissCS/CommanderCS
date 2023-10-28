using Newtonsoft.Json;
using StellarGK.Database;
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

            // iterate through every server where i have a account
            // if not just use nullserver

            ResponsePacket response = new();

            ServerData serverData = new();

            var SIFO = ProfilesRequest(@params.mIdx, GetSession());

            ServerData.ServerInfo nullServer = new()
            {
                idx = 0,
                status = 0,
                lastLoginTime = 0,
                level = 0,
                thumnail = 0,
            };

            List<ServerData.ServerInfo> serverInfo = new()
            {
                SIFO,
                nullServer
            };

            serverData.serverInfoList = serverInfo;
            serverData.recommandServer = 1;
            serverData.newServer = 1;

            response.Id = BasePacket.Id;
            response.Result = serverData;

            return response;
        }

        private static ServerData.ServerInfo ProfilesRequest(string mIdx, string session)
        {
            var account = DatabaseManager.Account.FindByUid(mIdx);

            var user = DatabaseManager.GameProfile.FindBySession(session);

            ServerData.ServerInfo SIFO = new()
            {
                idx = 1,
                lastLoginTime = 1643673600,
                level = 1,
                status = 1,
                thumnail = 0,
            };

            SIFO.level = user.UserResources.level;
            SIFO.thumnail = user.UserResources.thumbnailId;
            SIFO.lastLoginTime = account.LastLoginTime;

            return SIFO;
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