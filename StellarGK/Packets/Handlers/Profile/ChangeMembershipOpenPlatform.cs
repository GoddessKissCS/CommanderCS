using StellarGK.Host;
using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Profile
{
    [Packet(Id = Method.ChangeMembershipOpenPlatform)]
    public class ChangeMembershipOpenPlatform : BaseMethodHandler<ChangeMembershipOpenPlatformRequest>
    {
        public override object Handle(ChangeMembershipOpenPlatformRequest @params)
        {
            ResponsePacket response = new();

#warning TODO - changing the platform from like google -> dbros? idk

            //ErrorCode code = DatabaseManager.Account.ChangeMemberShip(@params.uid, @params.pwd, @params.plfm, @params.puid, @params.ch);

            /*

            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                response.error = new() { code = code };
                response.id = BasePacket.Id;

                return response;
            }

            */

            response.Id = BasePacket.Id;
            response.Result = "{}";
            return response;


        }
    }

    /*
     * 
    [JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1213", true, true)]
    public void ChangeMembershipOpenPlatform(string tokn, Platform plfm, string puid, int ch)
    {
    }

    private IEnumerator ChangeMembershipOpenPlatformResult(JsonRpcClient.Request request, string result)
    {
        string text = this._FindRequestProperty(request, "tokn");
        Platform platform = (Platform)int.Parse(this._FindRequestProperty(request, "plfm"));
        PlayerPrefs.SetString("MemberID", this.localUser.platformUserInfo);
        PlayerPrefs.SetString("MemberPW", null);
        PlayerPrefs.SetInt("MemberPlatform", (int)platform);
        LocalStorage.RemoveLoginData(PlayerPrefs.GetString("GuestID"));
        PlayerPrefs.SetString("GuestID", null);
        LocalStorage.SaveLoginData(this.localUser.platformUserInfo, null, (int)platform);
        if (platform == Platform.FaceBook)
        {
            this.RequestFBSignIn(text);
        }
        else if (platform == Platform.Google)
        {
            this.RequestGoogleSignIn(text);
        }
        yield break;
    }

    */


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
