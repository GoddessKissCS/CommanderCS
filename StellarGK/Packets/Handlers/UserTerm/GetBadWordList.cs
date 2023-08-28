using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetBadWordList)]
    public class GetBadWordList : BaseMethodHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {
            ResponsePacket response = new();

#warning TODO ADD AN ENTIRE BADWORDLIST WITH DIFFERENT LANGUAGES

            List<string> en = new()
            {
                "booooooobs",
            };

            BadWordListResponse badWord = new()
            {
                word = new() {
                {"en", en }}
            };

            response.Id = BasePacket.Id;
            response.Result = badWord;

            return response;
        }


        internal class BadWordListResponse
        {
            [JsonPropertyName("word")]
            public Dictionary<string, List<string>> word { get; set; }
        }
    }

    public class GetBadWordListRequest
    {

    }
}