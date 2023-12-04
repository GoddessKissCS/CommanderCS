using CommanderCS.Database;
using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.ChangeCommanderCostume)]
    public class ChangeCommanderCostume : BaseMethodHandler<ChangeCommanderCostumeRequest>
    {
        public override object Handle(ChangeCommanderCostumeRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();


            // maybe check if you own the costume first?

            user.CommanderData["" + @params.cid].currentCostume = @params.cos;

            DatabaseManager.GameProfile.UpdateCommanderData(session, user.CommanderData);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "{}"
            };

            return response;

        }

    }

    public class ChangeCommanderCostumeRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("tokn")]
        public int cos { get; set; }
    }

}

/*	// Token: 0x0600609A RID: 24730 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4305", true, true)]
	public void ChangeCommanderCostume(int cid, int cos)
	{
	}

	// Token: 0x0600609B RID: 24731 RVA: 0x001B08B4 File Offset: 0x001AEAB4
	private IEnumerator ChangeCommanderCostumeResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "cid");
		string text2 = this._FindRequestProperty(request, "cos");
		if (this.regulation.FindCostumeData(int.Parse(this.localUser.thumbnailId)).cid = int.Parse(text))
		{
			this.localUser.thumbnailId = text2;
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/