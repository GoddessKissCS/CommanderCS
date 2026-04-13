using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Server
{
    [Packet(Id = Method.ServerStatus)]
    public class ServerStatus : BaseMethodHandler<ServerStatusRequest>
    {
        public override object Handle(ServerStatusRequest request)
        {
            var serverinfos = ProfilesRequest(request.mIdx);

            if (serverinfos.Count < 1)
            {
                serverinfos.Add(new ServerData.ServerInfo()
                {
                    idx = 1,
                    status = (int)StatusEnum.Medium,
                    lastLoginTime = 0,
                    level = 0,
                    thumnail = 0,
                });
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

            foreach (GameProfileScheme profile in list)
            {
                ServerData.ServerInfo info = new()
                {
                    status = (int)StatusEnum.Medium,
                    idx = profile.Server,
                    lastLoginTime = profile.LastLoginTime,
                    level = profile.Resources.level,
                    thumnail = profile.Resources.thumbnailId
                };

                serverInfo.Add(info);
            }

            return serverInfo;
        }
    }

    public enum StatusEnum : int
    {
        Medium = 1,
        Busy,
        Full,
        UnableToJoin
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