using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.UserTerm)]
    public class UserTerm : BaseMethodHandler<UserTermRequest>
    {
        public override object Handle(UserTermRequest @params)
        {
            string wemade = File.ReadAllText($"Resources\\PrivacyPolicy\\TermsOfService.txt");
            string member = File.ReadAllText($"Resources\\PrivacyPolicy\\PrivacyPolicy.txt");

            UserTermResponse userterm = new()
            {
                wemade = wemade,
                member = member
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