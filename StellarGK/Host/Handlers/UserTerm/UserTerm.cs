using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.UserTerm)]
    public class UserTerm : BaseCommandHandler<UserTermRequest>
    {
        public override string Handle(UserTermRequest @params)
        {

            // TODO UNSURE ABOUT THIS

            ResponsePacket response = new();

            userterm userterm = new()
            {
                wemade = File.ReadAllText($"Resources\\Shared\\terms.txt"),
                member = File.ReadAllText($"Resources\\Shared\\privacy.txt")
            };

            response.id = BasePacket.Id;
            response.result = userterm;

            return JsonConvert.SerializeObject(response);
        }

        public class userterm
        {
            public string member { get; set; }
            public string wemade { get; set; }

        }

    }

    public class UserTermRequest
    {

    }
}