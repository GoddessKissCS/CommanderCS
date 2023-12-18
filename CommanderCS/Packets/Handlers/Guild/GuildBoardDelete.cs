using CommanderCS.Database;
using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.GuildBoardDelete)]
    public class GuildBoardDelete : BaseMethodHandler<GuildBoardDeleteRequest>
    {
        public override object Handle(GuildBoardDeleteRequest @params)
        {
            var user = GetUserGameProfile();

            DatabaseManager.Guild.DeleteGuildBoardEntry(user.GuildId, @params.idx);

#warning TODO ADD THE TIMECHECK FAIL

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = true,
            };

            return response;
        }
    }

    public class GuildBoardDeleteRequest
    {
        [JsonProperty("idx")]
        public int idx { get; set; }
    }
}

/*	// Token: 0x06006057 RID: 24663 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7452", true, true)]
	public void GuildBoardDelete(int idx)
	{
	}

	// Token: 0x06006058 RID: 24664 RVA: 0x001B032C File Offset: 0x001AE52C
	private IEnumerator GuildBoardDeleteResult(JsonRpcClient.Request request, string result)
	{
		yield break;
	}

	// Token: 0x06006059 RID: 24665 RVA: 0x001B0340 File Offset: 0x001AE540
	private IEnumerator GuildBoardDeleteError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001 || code = 71007 || code = 71018)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.Close();
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/