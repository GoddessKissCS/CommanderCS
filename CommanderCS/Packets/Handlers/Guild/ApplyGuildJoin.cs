using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.ApplyGuildJoin)]
    public class ApplyGuildJoin : BaseMethodHandler<ApplyGuildJoinRequest>
    {
        public override object Handle(ApplyGuildJoinRequest @params)
        {
            ErrorCode code = DatabaseManager.GuildApplication.CreateGuildApplication(SessionId, @params.gidx);

#warning TODO NEED TO ADD ALL ERRORCODES

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = code },
                    Id = BasePacket.Id,
                };

                return error;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "applied",
            };

            return response;
        }
    }

    public class ApplyGuildJoinRequest
    {
        [JsonProperty("gidx")]
        public int gidx { get; set; }
    }
}

/*	// Token: 0x06006027 RID: 24615 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7251", true, true)]
	public void ApplyGuildJoin(int gidx)
	{
	}

	// Token: 0x06006028 RID: 24616 RVA: 0x001AFEEC File Offset: 0x001AE0EC
	private IEnumerator ApplyGuildJoinResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "gidx"));
		UIManager.instance.world.guild.ChangeGuildItemState(num, "req");
		yield break;
	}

	// Token: 0x06006029 RID: 24617 RVA: 0x001AFF10 File Offset: 0x001AE110
	private IEnumerator ApplyGuildJoinError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71301)
		{
			Federation setting has been changed.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			int num = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.RomoveGuildList(num);
		}
		else if (code = 71302)
		{
			Federation setting has been changed.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			int num2 = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.ChangeGuildItemType(num2, 1);
		}
		else if (code = 71303)
		{
			You can join or send a request to join to only 1 Federation.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110219"));
		}
		else if (code = 71110)
		{
			You can request or be accepted in a different Federation up to 2 times in 7 days.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110265"));
		}
		else if (code = 71111)
		{
			You cannot send a request to join the same Federation again\nfor 48 hours after leaving a Federation
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110266"));
		}
		else if (code = 71112)
		{
			You cannot send a request to join another Federation for 1 hour after leaving a Federation.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110306"));
		}
		yield break;
	}*/