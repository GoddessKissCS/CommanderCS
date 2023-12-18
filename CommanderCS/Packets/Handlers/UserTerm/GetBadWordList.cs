using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetBadWordList)]
    public class GetBadWordList : BaseMethodHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {
            List<string> en = ["."];

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