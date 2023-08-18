using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Profile
{
    public class GetUserInformation
    {
    }

    public class GetUserInformationRequest
    {
        [JsonPropertyName("type")]
        public List<string> Type { get; set; }
    }


}

/*
 
public void GetUserInformation(List<string> type)
{
}

private IEnumerator GetUserInformationResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
{
    this._CheckReceiveTestData("GetUserInformation");
    this.localUser.FromNetwork(result);
    UIManager.instance.RefreshOpenedUI();
    yield break;
}
*/