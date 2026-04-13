using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Replay
{
    [Packet(Id = Method.GetRecordList)]
    public class GetRecordList : BaseMethodHandler<GetRecordListRequest>
    {
        public override object Handle(GetRecordListRequest request)
        {
            var User = GetUserGameProfile();

            var battleType = ReplayTypeToBattleType(request.type);

            var replays = battleType == EBattleType.Undefined
                ? DatabaseManager.ReplayList.FindByUno(User.Uno)
                : DatabaseManager.ReplayList.FindByUnoAndType(User.Uno, battleType);

            List<RecordInfo> recordList = [];

            foreach (var replay in replays)
            {
                var recordUser = DatabaseManager.GameProfile.FindByUno(replay.Uno);

                RecordInfo record = new()
                {
                    id = replay.ReplayId.ToString(),
                    uno = replay.Uno,
                    _userName = recordUser?.Resources?.nickname ?? "Unknown",
                    level = recordUser?.Resources?.level ?? 0,
                    thumbnail = recordUser?.Resources?.thumbnailId.ToString() ?? "0",
                    date = new DateTimeOffset(replay.Id.CreationTime).ToUnixTimeMilliseconds(),
                    guildName = GetGuildName(recordUser),
                };

                recordList.Add(record);
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = recordList,
            };

            return response;
        }

        private static string GetGuildName(GameProfileScheme user)
        {
            if (user?.GuildId is null) return null;

            var guild = DatabaseManager.Guild.FindByGuildId(user.GuildId);
            return guild?.Name;
        }

        internal static EBattleType ReplayTypeToBattleType(int replayType)
        {
            return replayType switch
            {
                (int)ERePlayType.WorldMap => EBattleType.Plunder,
                (int)ERePlayType.Raid => EBattleType.Raid,
                (int)ERePlayType.Challenge => EBattleType.Duel,
                (int)ERePlayType.WaveDuel => EBattleType.WaveDuel,
                (int)ERePlayType.WorldDuel => EBattleType.WorldDuel,
                _ => EBattleType.Undefined,
            };
        }
    }

    public class GetRecordListRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("ver")]
        public int ver { get; set; }
    }
}

/*	// Token: 0x06005FE8 RID: 24552 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3131", true, true)]
	public void GetRecordList(int type, int ver)
	{
	}

	// Token: 0x06005FE9 RID: 24553 RVA: 0x001AF994 File Offset: 0x001ADB94
	private IEnumerator GetRecordListResult(JsonRpcClient.Request request, List<Protocols.RecordInfo> result)
	{
		if (result = null)
		{
			yield break;
		}
		UIManager.World world = UIManager.instance.world;
		int num = this._ConvertStringToInt(this._FindRequestProperty(request, "type"));
		if (num = 6 || num = 17)
		{
			this.localUser.atkRecordList = result;
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/
