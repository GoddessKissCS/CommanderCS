using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.WaveDuel
{
    public class WaveDuelDefenderSetting
    {

    }
    public class WaveDuelDefenderSettingRequest
    {
        [JsonPropertyName("decks")]
        public JObject Decks { get; set; }
    }
}

/*	// Token: 0x06005F99 RID: 24473 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3405", true, true)]
	public void WaveDuelDefenderSetting(JObject decks)
	{
	}

	// Token: 0x06005F9A RID: 24474 RVA: 0x001AF358 File Offset: 0x001AD558
	private IEnumerator WaveDuelDefenderSettingResult(JsonRpcClient.Request request, string result)
	{
		if (result.Equals("True"))
		{
			Dictionary<string, Dictionary<string, string>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(this._FindRequestProperty(request, "decks"));
			List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
			for (int i = 1; i <= ConstValue.waveDuelTroopCount; i++)
			{
				string text = i.ToString();
				if (dictionary.ContainsKey(text))
				{
					list.Add(dictionary[text]);
				}
				else
				{
					list.Add(new Dictionary<string, string>());
				}
			}
			this.localUser.RefreshDefenderTroop(list);
			UIManager.instance.world.readyBattle.CloseAnimation();
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/