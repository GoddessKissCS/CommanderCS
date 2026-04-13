using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.GetConquestBattle)]
    public class GetConquestBattle : BaseMethodHandler<GetConquestBattleRequest>
    {
        public override object Handle(GetConquestBattleRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            Library.Protocols.GetConquestBattle battleData = new()
            {
                enemyWorld = 0,
                enemyName = "",
                eSide = "B",
                entry = new Library.Protocols.GetConquestBattle.Entry()
                {
                    red = [],
                    blue = [],
                },
                battle = [],
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = battleData,
            };

            return response;
        }
    }

    public class GetConquestBattleRequest
    {
        public int point { get; set; }
        public int skip { get; set; }
    }
}

/*	// Token: 0x06006081 RID: 24705 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7514", true, true)]
	public void GetConquestBattle(int point, int skip)
	{
	}

	// Token: 0x06006082 RID: 24706 RVA: 0x001B06C0 File Offset: 0x001AE8C0
	private IEnumerator GetConquestBattleResult(JsonRpcClient.Request request, Protocols.GetConquestBattle result)
	{
		if (result !=null && UIManager.instance.world.guild.historyPopup !=null)
		{
			int num = int.Parse(this._FindRequestProperty(request, "skip"));
			UIManager.instance.world.guild.historyPopup.CreateBattleResultPopup(result, num);
		}
		yield break;
	}

	// Token: 0x06006083 RID: 24707 RVA: 0x001B06EC File Offset: 0x001AE8EC
	private IEnumerator GetConquestBattleError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
		}
		else if (code = 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code = 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/
