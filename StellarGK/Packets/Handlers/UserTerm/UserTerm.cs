﻿using Newtonsoft.Json;

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
                wemade = File.ReadAllText($"Resources\\PrivacyPolicy\\TermsOfService.txt"),
                member = File.ReadAllText($"Resources\\PrivacyPolicy\\PrivacyPolicy.txt")
            };

            response.Id = BasePacket.Id;
            response.Result = userterm;

            return response;
        }

        internal class UserTermResponse
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