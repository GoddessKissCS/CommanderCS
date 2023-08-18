using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Mail
{
    public class ReadMail
    {

    }
    public class ReadMailRequest
    {
        [JsonPropertyName("idx")]
        public int Idx { get; set; }
    }
}
/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6103", true, true)]
	public void ReadMail(int idx)
	{
	}

	// Token: 0x06005F72 RID: 24434 RVA: 0x001AF020 File Offset: 0x001AD220
	private IEnumerator ReadMailResult(JsonRpcClient.Request request, string result)
	{
		this.localUser.badgeNewMailCount--;
		string text = this._FindRequestProperty(request, "idx");
		RoReward roReward = this.localUser.FindReward(text);
		roReward.received = true;
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("ReadMailResult");
		yield break;
	}*/