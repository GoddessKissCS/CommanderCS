using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.PreDeck
{
    [Packet(Id = Method.PreDeckSetting)]
    public class PreDeckSetting : BaseMethodHandler<PreDeckSettingRequest>
    {
        public override object Handle(PreDeckSettingRequest @params)
        {
            var preDeckList = @params.list.ToObject<List<UserInformationResponse.PreDeck>>();

            DatabaseManager.GameProfile.UpdatePreDeck(SessionId, preDeckList);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "{}"
            };

            return response;
        }
    }

    public class PreDeckSettingRequest
    {
        [JsonProperty("list")]
        public JArray list { get; set; }
    }
}