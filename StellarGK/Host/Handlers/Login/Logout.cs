namespace StellarGK.Host.Handlers.Login
{

    [Command(Id = CommandId.Logout)]
    public class Logout : BaseCommandHandler<LogoutRequest>
    {
        public override object Handle(LogoutRequest @params)
        {
            ResponsePacket response = new();

            logout logout = new() { success = true };
            response.id = BasePacket.Id;
            response.result = logout.success;

            return response;
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