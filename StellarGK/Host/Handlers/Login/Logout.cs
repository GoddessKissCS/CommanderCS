using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.Login
{

    [Command(Id = CommandId.Logout)]
    public class Logout : BaseCommandHandler<LogoutRequest>
    {
        public override string Handle(LogoutRequest @params)
        {
            ResponsePacket response = new();

            logout logout = new() { success = true };
            response.id = BasePacket.Id;
            response.result = logout.success;

            return JsonConvert.SerializeObject(response);
        }

        private class logout
        {
            public bool success { get; set; }
        }
    }

    public class LogoutRequest
    {

    }
}