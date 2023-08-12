using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.GetBadWordList)]
    public class GetBadWordList : BaseCommandHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {
            ResponsePacket response = new();

            // TODO
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

            response.id = BasePacket.Id;
            response.result = badWord;

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