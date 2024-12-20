using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.WorldDuel
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.WorldDuelBuffSetting)]
    public class WorldDuelBuffSetting : BaseMethodHandler<WorldDuelBuffSettingRequest>
    {
        public override object Handle(WorldDuelBuffSettingRequest @params)
        {
            //IDK THIS?

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "true",
            };

            return response;
        }
    }

    public class WorldDuelBuffSettingRequest
    {
        [JsonProperty("bbf")]
        public string Bbf { get; set; }
    }
}

/*	// Token: 0x06006154 RID: 24916 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3610", true, true)]
	public void WorldDuelBuffSetting(string bbf)
	{
	}

	// Token: 0x06006155 RID: 24917 RVA: 0x001B17D4 File Offset: 0x001AF9D4
	private IEnumerator WorldDuelBuffSettingResult(JsonRpcClient.Request request, string result)
	{
		if (result == "true" || result == "True")
		{
			string text = this._FindRequestProperty(request, "bbf");
			string text2 = text.Substring(0, 3);
			string text3 = text.Substring(3);
			EWorldDuelBuff eworldDuelBuff = (EWorldDuelBuff)Enum.Parse(typeof(EWorldDuelBuff), text2);
			EWorldDuelBuffEffect eworldDuelBuffEffect = (EWorldDuelBuffEffect)Enum.Parse(typeof(EWorldDuelBuffEffect), text3);
			this.localUser.activeBuff[eworldDuelBuff] = eworldDuelBuffEffect;
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006156 RID: 24918 RVA: 0x001B1800 File Offset: 0x001AFA00
	private IEnumerator WorldDuelBuffSettingError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/