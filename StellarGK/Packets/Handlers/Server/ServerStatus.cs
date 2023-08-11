using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.Server
{
    [Command(Id = CommandId.ServerStatus)]
    public class ServerStatus : BaseCommandHandler<ServerStatusRequest>
    {
        public override object Handle(ServerStatusRequest @params)
        {

            // needs to be reworked


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

            response.id = BasePacket.Id;
            response.result = serverData;

            return response;
        }

        private static ServerData.ServerInfo ProfilesRequest(string mIdx, string session)
        {
            var account = DatabaseManager.Account.FindByUid(mIdx);
            //var resources = DatabaseManager.GameProfile.Fin(mIdx);

            var user = DatabaseManager.GameProfile.FindBySession(session);

            ServerData.ServerInfo SIFO = new()
            {
                idx = 1,
                lastLoginTime = 1643673600,
                level = 1,
                status = 1,
                thumnail = 0,
            };

            SIFO.level = user.userResources.level;
            SIFO.thumnail = user.userResources.thumbnailId;
            SIFO.lastLoginTime = account.lastLoginTime;

            return SIFO;

        }

    }
    public class ServerStatusRequest
    {
        [JsonPropertyName("mIdx")]
        public string mIdx { get; set; }

        [JsonPropertyName("tokn")]
        public string tokn { get; set; }

        [JsonPropertyName("srv")]
        public int srv { get; set; }
    }
}