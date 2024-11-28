using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.VersionCheck
{
    [Packet(Id = Method.DBVersionCheck)]
    public class DatabaseVersionCheck : BaseMethodHandler<DatabaseVersionCheckRequest>
    {
        public override object Handle(DatabaseVersionCheckRequest @params)
        {
            DatabaseVersionScheme gametable = DatabaseManager.GameTableVersion.Get();

            DatabaseVersionCheckResponse res = new()
            {
                version = gametable.Version,
            };

            ResponsePacket response = new()
            {
                Result = res,
                Id = BasePacket.Id
            };

            return response;
        }

        private class DatabaseVersionCheckResponse
        {
            [JsonProperty("ver")]
            public double version { get; set; }
        }
    }

    public class DatabaseVersionCheckRequest
    {
    }
}