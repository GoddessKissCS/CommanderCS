using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.VersionCheck
{
    [Packet(Id = Method.DBVersionCheck)]
    public class DatabaseVersionCheck : BaseMethodHandler<DatabaseVersionCheckRequest>
    {
        public override object Handle(DatabaseVersionCheckRequest @params)
        {
            var gametable = DatabaseManager.GameTableVersion.Get();

            DatabaseVersionCheckResponse res = new()
            {
                ver = gametable.Version,
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
            public double ver { get; set; }
        }
    }

    public class DatabaseVersionCheckRequest
    {
    }
}