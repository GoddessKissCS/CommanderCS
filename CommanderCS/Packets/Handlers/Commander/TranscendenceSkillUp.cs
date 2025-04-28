using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.TranscendenceSkillUp)]
    public class TranscendenceSkillUp : BaseMethodHandler<TranscendenceSkillUpRequest>
    {
        public override object Handle(TranscendenceSkillUpRequest @params)
        {
            string cid = @params.cid.ToString();

            int transcendenceSlot = @params.slot - 1;

            User.CommanderData[cid].transcendence[transcendenceSlot] += 1;
            User.CommanderData[cid].medl -= 10;

            User.Inventory.medalData[cid] -= 10;

            DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.Inventory.medalData);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);

            var userInformationResponse = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class TranscendenceSkillUpRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("slot")]
        public int slot { get; set; }
    }
}

/*	// Token: 0x0600615D RID: 24925 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4313", true, true)]
	public void TranscendenceSkillUp(int cid, int slot)
	{
	}

	// Token: 0x0600615E RID: 24926 RVA: 0x001B1894 File Offset: 0x001AFA94
	private IEnumerator TranscendenceSkillUpResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield return null;
		int slot = int.Parse(this._FindRequestProperty(request, "slot"));
		UITranscendencePopup obj = UnityEngine.Object.FindObjectOfType(typeof(UITranscendencePopup)) as UITranscendencePopup;
		if (obj is not null)
		{
			obj.Set(slot);
		}
		yield break;
	}

	// Token: 0x0600615F RID: 24927 RVA: 0x001B18C0 File Offset: 0x001AFAC0
	private IEnumerator TranscendenceSkillUpError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText("Error code:" + code);
		yield break;
	}*/