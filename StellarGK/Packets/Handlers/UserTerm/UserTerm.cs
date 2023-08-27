using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Packet(Id = Method.UserTerm)]
    public class UserTerm : BaseMethodHandler<UserTermRequest>
    {
        public override object Handle(UserTermRequest @params)
        {

#warning TODO UNSURE ABOUT THIS

            ResponsePacket response = new();

            userterm userterm = new()
            {
                wemade = File.ReadAllText($"Resources\\Shared\\terms.txt"),
                member = File.ReadAllText($"Resources\\Shared\\privacy.txt")
            };

            response.Id = BasePacket.Id;
            response.Result = userterm;

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