using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.VersionCheck
{

    [Command(Id = CommandId.DBVersionCheck)]
    public class DatabaseVersionCheck : BaseCommandHandler<DatabaseVersionCheckRequest>
    {
        public override object Handle(DatabaseVersionCheckRequest @params)
        {
            var version = DatabaseManager.GameTableVersion.Get();

            VersionInfo res = new()
            {
                ver = version.ver,
            };

            ResponsePacket response = new()
            {
                result = res,
                id = BasePacket.Id
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