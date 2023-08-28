using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Packet(Id = Method.UserTerm)]
    public class UserTerm : BaseMethodHandler<UserTermRequest>
    {
        public override object Handle(UserTermRequest @params)
        {
            ResponsePacket response = new();

            UserTermResponse userterm = new()
            {
                wemade = File.ReadAllText($"Resources\\Shared\\terms.txt"),
                member = File.ReadAllText($"Resources\\Shared\\privacy.txt")
            };

            response.Id = BasePacket.Id;
            response.Result = userterm;

            return response;
        }

        internal class UserTermResponse
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