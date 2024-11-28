using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Troop
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.GetTroopInformation)]
    public class GetTroopInformation : BaseMethodHandler<GetTroopInformationRequest>
    {
        public override object Handle(GetTroopInformationRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = new CommanderCSLibrary.Shared.Protocols.UserInformationResponse.Commander(),
            };

            return response;
        }
    }

    public class GetTroopInformationRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5119", true, true)]
	public void GetTroopInformation(int cid)
	{
	}

	// Token: 0x06005F4E RID: 24398 RVA: 0x001AED2C File Offset: 0x001ACF2C
	private IEnumerator GetTroopInformationResult(JsonRpcClient.Request request, Protocols.UserInformationResponse.Commander result)
	{
		this.localUser.AddOrRefreshCommanderFromNetwork(result);
		this._CheckReceiveTestData("GetTroopInfo");
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/