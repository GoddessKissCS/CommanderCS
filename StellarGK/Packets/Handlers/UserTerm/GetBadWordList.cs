using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetBadWordList)]
    public class GetBadWordList : BaseMethodHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {

            List<string> en =
            [
                "."
            ];

            // TODO:
            // Read from a badwordlist file and add them
            // doesnt need to be done until its done ig

            //var enList = JsonConvert.DeserializeObject<List<string>>($"Resources\\BadWordList\\En.json");

            BadWordListResponse badWord = new()
            {
                word = new() {
                    {"en", en }
                }
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = badWord
            };

            return response;
        }

        private class BadWordListResponse
        {
            [JsonProperty("word")]
            public Dictionary<string, List<string>> word { get; set; }
        }
    }

    public class GetBadWordListRequest
    {
    }
}