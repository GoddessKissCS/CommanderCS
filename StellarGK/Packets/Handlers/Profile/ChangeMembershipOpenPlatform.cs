using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Host.Handlers.Profile;
using StellarGK.Host;
using StellarGK.Logic.Enums;

namespace StellarGK.Packets.Handlers.Profile
{
    [Command(Id = CommandId.ChangeMembershipOpenPlatform)]
    public class ChangeMembershipOpenPlatform : BaseCommandHandler<ChangeMembershipOpenPlatformRequest>
    {
        public override object Handle(ChangeMembershipOpenPlatformRequest @params)
        {
            ResponsePacket response = new();

            // TODO - changing the platform from like google -> dbros? idk

            //ErrorCode code = DatabaseManager.Account.ChangeMemberShip(@params.uid, @params.pwd, @params.plfm, @params.puid, @params.ch);

            /*

            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                response.error = new() { code = code };
                response.id = BasePacket.Id;

                return response;
            }

            */

            response.id = BasePacket.Id;
            response.result = "{}";
            return response;


        }
    }


    public class ChangeMembershipOpenPlatformRequest
    {
        [JsonPropertyName("tokn")]
        public string tokn { get; set; }

        [JsonPropertyName("plfm")]
        public Platform plfm { get; set; }

        [JsonPropertyName("puid")]
        public string puid { get; set; }

        [JsonPropertyName("ch")]
        public int ch { get; set; }
    }
}
