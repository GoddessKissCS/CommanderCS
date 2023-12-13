using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCS.Utils;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.DeportGuildMember)]
    public class DeportGuildMember : BaseMethodHandler<DeportGuildMemberRequest>
    {
        public override object Handle(DeportGuildMemberRequest @params)
        {
            var user = GetUserGameProfile();
            var guild = GetUserGuild();

            var target = guild.MemberData.FirstOrDefault(member => member.uno == @params.tuno);

            var difference = TimeManager.GetTimeDifferenceInDays(target.joinDate);

            bool kicked5peopleToday = false;

            if (difference < 1 || kicked5peopleToday == true)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = ErrorCode.CanOnlyKickUpTo5MemberWithinADayAndNotOnTheJoinDay },
                    Id = BasePacket.Id,
                };

                return error;
            }

            bool isInGuild = DatabaseManager.Guild.IsUnoInMemberData(user.GuildId, user.Uno);

            bool isntRemoved = DatabaseManager.Guild.RemoveMemberDataByUno(user.GuildId, @params.tuno);

            if (!isInGuild || !isntRemoved)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = ErrorCode.YouAlreadyLeftTheFederation },
                    Id = BasePacket.Id,
                };

                return error;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "deported",
            };

            return response;
        }
    }

    public class DeportGuildMemberRequest
    {
        [JsonProperty("tuno")]
        public int tuno { get; set; }
    }
}

/*	// Token: 0x06006043 RID: 24643 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7216", true, true)]
	public void DeportGuildMember(int tuno)
	{
	}

	// Token: 0x06006044 RID: 24644 RVA: 0x001B0160 File Offset: 0x001AE360
	private IEnumerator DeportGuildMemberResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "tuno"));
		UIManager.instance.world.guild.RemoveMemberList(num);
		yield break;
	}

	// Token: 0x06006045 RID: 24645 RVA: 0x001B0184 File Offset: 0x001AE384
	private IEnumerator DeportGuildMemberError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			You have already left that Federation.
			int num = int.Parse(this._FindRequestProperty(request, "tuno"));
			UIManager.instance.world.guild.RemoveMemberList(num);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110228"));
		}
		else if (code = 71307)
		{
			You cannot kick out a member on the same day of joining, and you can only kick out up to 5 members in 1 day.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110118"));
		}
		yield break;
	}*/