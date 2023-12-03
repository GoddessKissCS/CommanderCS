using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Database.Schemes;
using CommanderCS.Host;


namespace CommanderCS.Packets.Handlers.Guild
{
	[Packet(Id = Method.SearchGuild)]
    public class SearchGuild : BaseMethodHandler<SearchGuildRequest>
    {
        public override object Handle(SearchGuildRequest @params)
        {
			var session = GetSession();

            ResponsePacket response = new()
			{
				Id = BasePacket.Id,
			};	

			var guild = DatabaseManager.Guild.FindByName(@params.gnm);

			if (guild != null)
			{
				var roguild = Guild2RoGuild(guild, session);
				response.Result = roguild;
			}
			else
			{
				Ro.RoGuild Roguild = new() { };

				response.Result = Roguild;
            }

			return response;

        }

        public static Ro.RoGuild Guild2RoGuild(GuildScheme guild, string session)
        {
            string isApplyingForGuild = DatabaseManager.GuildApplication.RetrieveGuildApplication(session, guild.GuildId);

            Ro.RoGuild Roguild = new()
            {
                apnt = guild.aPoint,
                cnt = guild.Count,
                emb = guild.Emblem,
                gidx = guild.GuildId,
                gnm = guild.Name,
                gtyp = guild.GuildType,
                lev = guild.Level,
                list = isApplyingForGuild,
				mxCnt = guild.MaxCount,
				ntc = guild.Notice,
				world = guild.World,
            };

            return Roguild;
        }
    }

	public class SearchGuildRequest
	{
		[JsonProperty("gnm")]
		public string gnm { get; set;}
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