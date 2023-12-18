using CommanderCS.Database;
using CommanderCS.Database.Schemes;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Host
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class PacketAttribute : Attribute
    {
        public Method Id { get; set; }
    }

    public class ParamsPacket : BasePacket
    {
        [JsonProperty("params")]
        public JToken Params { get; set; }
    }

    public class BasePacket
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("method")]
        public int Method { get; set; }

        [JsonProperty("sess")]
        public string Session { get; set; }
    }

    public abstract class BaseMethodHandler<TParams>
    {
        public BasePacket BasePacket { get; set; }

        public abstract object Handle(TParams @params);

        public string GetSession()
        {
            return BasePacket.Session;
        }

        public AccountScheme? GetUserAccount()
        {
            return DatabaseManager.Account.FindBySession(BasePacket.Session);
        }

        public GameProfileScheme? GetUserGameProfile()
        {
            return DatabaseManager.GameProfile.FindBySession(BasePacket.Session);
        }

        public DormitoryScheme? GetUserDormitory()
        {
            return DatabaseManager.Dormitory.FindBySession(BasePacket.Session);
        }

        public string GetUserDeviceCode()
        {
            return DatabaseManager.DeviceCode.RequestForChangeDeviceCode(GetUserAccount());
        }

        public GuildScheme GetUserGuild()
        {
            return DatabaseManager.Guild.FindBySession(BasePacket.Session);
        }
    }

   
}