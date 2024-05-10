using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Ro;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.SearchGuild)]
    public class SearchGuild : BaseMethodHandler<SearchGuildRequest>
    {
        public override object Handle(SearchGuildRequest @params)
        {
            ResponsePacket response = new() { Id = BasePacket.Id };

            var guild = DatabaseManager.Guild.FindByName(@params.gnm);
            var roGuild = guild != null ? DatabaseManager.GuildApplication.Guild2RoGuild(guild, Session) : new RoGuild();

            response.Result = roGuild;

            return response;
        }
    }

    public class SearchGuildRequest
    {
        [JsonProperty("gnm")]
        public string gnm { get; set; }
    }
}

/*	// Token: 0x06006022 RID: 24610 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7218", true, true)]
	public void SearchGuild(string gnm)
	{
	}

	// Token: 0x06006023 RID: 24611 RVA: 0x001AFE80 File Offset: 0x001AE080
	private IEnumerator SearchGuildResult(JsonRpcClient.Request request, RoGuild result)
	{
		if (!string.IsNullOrEmpty(result.gnm))
		{
			List<RoGuild> list = new List<RoGuild>();
			list.Add(result);
			UIManager.instance.world.guild.InitGuildList(list);
			UIManager.instance.world.guild.guildListView.scrollView.SetDragAmount(0f, 0f, false);
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110216"));
		}
		yield break;
	}*/