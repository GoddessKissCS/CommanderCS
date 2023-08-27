using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.VersionCheck
{

    [Packet(Id = Method.DBVersionCheck)]
    public class DatabaseVersionCheck : BaseMethodHandler<DatabaseVersionCheckRequest>
    {
        public override object Handle(DatabaseVersionCheckRequest @params)
        {
            var gametable = DatabaseManager.GameTableVersion.Get();

            VersionInfo res = new()
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

        internal class VersionInfo
        {
            [JsonPropertyName("ver")]
            public double ver { get; set; }
        }

    }

    public class DatabaseVersionCheckRequest
    {

    }
}