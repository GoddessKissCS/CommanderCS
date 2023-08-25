using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Login
{

    [Packet(MethodId.Logout)]
    public class Logout : BaseMethodHandler<LogoutRequest>
    {
        public override object Handle(LogoutRequest @params)
        {
            ResponsePacket response = new();

            logout logout = new() { success = true };
            response.Id = BasePacket.Id;
            response.Result = logout.success;

            return response;
        }

        private class logout
        {
            [JsonPropertyName("success")]
            public bool success { get; set; }
        }
    }

    public class LogoutRequest
    {

    }
}