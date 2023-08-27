using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetBadWordList)]
    public class GetBadWordList : BaseMethodHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {
            ResponsePacket response = new();

#warning TODO
            // WILL BE A LIST OF BADWORDS LATER ON

            List<string> en = new()
            {
                "booooooobs",
            };

            badwords badWord = new()
            {
                word = new() {
                {"en", en }
            }
            };

            response.Id = BasePacket.Id;
            response.Result = badWord;

            return response;
        }


        private class badwords
        {
            [JsonPropertyName("word")]
            public Dictionary<string, List<string>> word { get; set; }
        }
    }

    public class GetBadWordListRequest
    {

    }
}