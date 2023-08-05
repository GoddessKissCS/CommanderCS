using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.UserTerm)]
    public class UserTerm : BaseCommandHandler<UserTermRequest>
    {
        public override object Handle(UserTermRequest @params)
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

            return response;
        }

        public class userterm
        {
            [JsonPropertyName("member")]
            public string member { get; set; }
            [JsonPropertyName("wemade")]
            public string wemade { get; set; }

        }

    }

    public class UserTermRequest
    {

    }
}