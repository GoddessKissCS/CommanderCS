using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.VersionCheck
{

    [Command(Id = CommandId.DBVersionCheck)]
    public class DatabaseVersionCheck : BaseCommandHandler<DatabaseVersionCheckRequest>
    {
        public override string Handle(DatabaseVersionCheckRequest @params)
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

            return JsonConvert.SerializeObject(response);
        }

        internal class VersionInfo
        {
            public double ver { get; set; }
        }

    }

    public class DatabaseVersionCheckRequest
    {

    }
}