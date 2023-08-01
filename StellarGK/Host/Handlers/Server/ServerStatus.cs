using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.Server
{
    [Command(Id = CommandId.ServerStatus)]
    public class ServerStatus : BaseCommandHandler<ServerStatusRequest>
    {
        public override string Handle(ServerStatusRequest @params)
        {

            ResponsePacket response = new();

            ServerData serverData = new();

            var SIFO = Req(@params.mIdx);

            List<ServerData.ServerInfo> serverInfo = new(
                new List<ServerData.ServerInfo>() {
                        { SIFO }
             });

            serverData.serverInfoList = serverInfo;
            serverData.recommandServer = 1;
            serverData.newServer = 1;

            response.id = BasePacket.Id;
            response.result = serverData;

            return JsonConvert.SerializeObject(response);
        }

        private static ServerData.ServerInfo Req(int mIdx)
        {

            var account = DatabaseManager.Account.FindByUid(mIdx);
            var resources = DatabaseManager.Resources.FindByUid(mIdx);

            ServerData.ServerInfo SIFO = new()
            {
                idx = 1,
                lastLoginTime = 1643673600,
                level = 1,
                status = 1,
                thumnail = 0,
            };

            SIFO.level = Convert.ToInt32(resources.level);
            SIFO.thumnail = Convert.ToInt32(resources.thumbnailId);
            SIFO.lastLoginTime = account.lastLoginTime;

            return SIFO;

        }

    }
    public class ServerStatusRequest
    {
        [JsonPropertyName("mIdx")]
        public int mIdx { get; set; }
    }
}