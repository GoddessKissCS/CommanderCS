using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Host;
using StellarGKLibrary.Protocols;

namespace StellarGK.Packets.Handlers.Guild
{
	[Packet(Id = Method.GetGuildBoard)]
    public class GetGuildBoard : BaseMethodHandler<GetGuildBoardRequest>
    {
        public override object Handle(GetGuildBoardRequest @params)
        {

			var user = GetUserGameProfile();


			var list = DatabaseManager.Guild.GetGuildBoard(user.GuildId);


			ResponsePacket response = new ResponsePacket();
			GetGuildBoardResponse getGuildBoard = new()
			{
				list = list,
				page = 0,
				tPage = 0,
			};

			response.Id = BasePacket.Id;
			response.Result = getGuildBoard;

			return response;
        }
    }
	public class GetGuildBoardRequest
	{
		[JsonProperty("page")]
		public int page { get; set; }
	}

	public class GetGuildBoardResponse
	{
        public int tPage { get; set; }
        public int page { get; set; }
        public List<GuildBoardData> list { get; set; }
    }
}

/*	// Token: 0x06006051 RID: 24657 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7450", true, true)]
	public void GetGuildBoard(int page)
	{
	}

	// Token: 0x06006052 RID: 24658 RVA: 0x001B02B4 File Offset: 0x001AE4B4
	private IEnumerator GetGuildBoardResult(JsonRpcClient.Request request, string result, int tPage, int page, List<Protocols.GuildBoardData> list)
	{
		UIManager.instance.world.guild.OpenGuildBoard(page, tPage, list);
		yield break;
	}

	// Token: 0x06006053 RID: 24659 RVA: 0x001B02E0 File Offset: 0x001AE4E0
	private IEnumerator GetGuildBoardError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}*/