using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.GetBadWordList)]
    public class GetBadWordList : BaseCommandHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {

            ResponsePacket response = new();

            badwords badWord = new();

            Dictionary<string, List<string>> MasterBadWordList = new();
            List<string> en = new()
            {
                "booooooobs",
            };


            MasterBadWordList.Add("en", en);

            badWord.word = MasterBadWordList;

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