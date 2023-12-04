using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.UserTerm)]
    public class UserTerm : BaseMethodHandler<UserTermRequest>
    {
        public override object Handle(UserTermRequest @params)
        {
            UserTermResponse userterm = new()
            {
                wemade = File.ReadAllText($"Resources\\PrivacyPolicy\\TermsOfService.txt"),
                member = File.ReadAllText($"Resources\\PrivacyPolicy\\PrivacyPolicy.txt")
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userterm
            };

            return response;
        }

        private class UserTermResponse
        {
            [JsonProperty("member")]
            public string member { get; set; }

            [JsonProperty("wemade")]
            public string wemade { get; set; }
        }
    }

    public class UserTermRequest
    {
    }
}