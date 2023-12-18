using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.GuildBoardWrite)]
    public class GuildBoardWrite : BaseMethodHandler<GuildBoardWriteRequest>
    {
        public override object Handle(GuildBoardWriteRequest @params)
        {
            var user = GetUserGameProfile();

            if (Misc.NameCheck(@params.msg))
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.InappropriateWordsInGuildBoardMessage }
                };
            }

            var boarddatalist = DatabaseManager.Guild.GetGuildBoard(user.GuildId, out ErrorCode code);

            int nextIdx = boarddatalist.Count != 0 ? boarddatalist.Max(item => item.idx) + 1 : 0;

            var newEntry = new GuildBoardData()
            {
                dauth = 0,
                idx = nextIdx,
                msg = @params.msg,
                regdt = TimeManager.CurrentEpochMilliseconds,
                thumb = user.UserResources.thumbnailId.ToString(),
                unm = user.UserResources.nickname,
                uno = user.Uno,
            };

            DatabaseManager.Guild.AddGuildBoardEntry(user.GuildId, newEntry);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "okay",
            };

            return response;
        }
    }

    public class GuildBoardWriteRequest
    {
        [JsonProperty("msg")]
        public string msg { get; set; }
    }
}

/*	// Token: 0x06006054 RID: 24660 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7451", true, true)]
	public void GuildBoardWrite(string msg)
	{
	}

	// Token: 0x06006055 RID: 24661 RVA: 0x001B02FC File Offset: 0x001AE4FC
	private IEnumerator GuildBoardWriteResult(JsonRpcClient.Request request, string result)
	{
		yield break;
	}

	// Token: 0x06006056 RID: 24662 RVA: 0x001B0310 File Offset: 0x001AE510
	private IEnumerator GuildBoardWriteError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71131)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		else if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}*/