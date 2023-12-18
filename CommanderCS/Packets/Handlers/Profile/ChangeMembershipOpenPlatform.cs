using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    [Packet(Id = Method.ChangeMembershipOpenPlatform)]
    public class ChangeMembershipOpenPlatform : BaseMethodHandler<ChangeMembershipOpenPlatformRequest>
    {
        public override object Handle(ChangeMembershipOpenPlatformRequest @params)
        {
            //TODO - changing the platform from like google -> dbros? idk

            // should be finished? idk it shouldnt affect anything but you never know

            DatabaseManager.Account.ChangeMemberShipOpenPlatform(@params.puid, (int)@params.plfm, @params.tokn, @params.ch);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "{}"
            };

            return response;
        }
    }

    public class ChangeMembershipOpenPlatformRequest
    {
        [JsonProperty("tokn")]
        public string tokn { get; set; }

        [JsonProperty("plfm")]
        public Platform plfm { get; set; }

        [JsonProperty("puid")]
        public string puid { get; set; }

        [JsonProperty("ch")]
        public int ch { get; set; }
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
        if (platform = Platform.FaceBook)
        {
            this.RequestFBSignIn(text);
        }
        else if (platform = Platform.Google)
        {
            this.RequestGoogleSignIn(text);
        }
        yield break;
    }

    */
}