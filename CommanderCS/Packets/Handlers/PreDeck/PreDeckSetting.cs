using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.PreDeck
{
    [Packet(Id = Method.PreDeckSetting)]
    public class PreDeckSetting : BaseMethodHandler<PreDeckSettingRequest>
    {
        public override object Handle(PreDeckSettingRequest @params)
        {
            var session = GetSession();

            var preDeckList = @params.list.ToObject<List<UserInformationResponse.PreDeck>>();

            DatabaseManager.GameProfile.UpdatePreDeck(session, preDeckList);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "changed"
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