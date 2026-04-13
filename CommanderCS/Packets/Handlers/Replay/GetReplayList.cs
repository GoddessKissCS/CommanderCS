using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Replay
{
    [Packet(Id = Method.GetReplayList)]
    public class GetReplayList : BaseMethodHandler<GetReplayListRequest>
    {
        public override object Handle(GetReplayListRequest request)
        {
            var User = GetUserGameProfile();

            var battleType = GetRecordList.ReplayTypeToBattleType(request.type);

            // For attack subtype, return the user's own replays
            // For defense subtype, return replays where others fought the user
            // Currently only attack replays are stored, so both return the user's replays
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
                    simulationVer = request.ver,
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
    }

    public class GetReplayListRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("stype")]
        public int stype { get; set; }

        [JsonProperty("ver")]
        public int ver { get; set; }
    }
}

/*	// Token: 0x06005FE3 RID: 24547 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3132", true, true)]
	public void GetReplayList(ERePlayType type, ERePlaySubType stype, int ver)
	{
	}

	// Token: 0x06005FE4 RID: 24548 RVA: 0x001AF928 File Offset: 0x001ADB28
	private IEnumerator GetReplayListResult(JsonRpcClient.Request request, List<Protocols.RecordInfo> result)
	{
		if (result = null)
		{
			yield break;
		}
		UIManager.World world = UIManager.instance.world;
		ERePlayType erePlayType = (ERePlayType)this._ConvertStringToInt(this._FindRequestProperty(request, "type"));
		if (erePlayType = ERePlayType.Challenge || erePlayType = ERePlayType.WaveDuel)
		{
			ERePlaySubType erePlaySubType = (ERePlaySubType)this._ConvertStringToInt(this._FindRequestProperty(request, "stype"));
			if (erePlaySubType = ERePlaySubType.Attack)
			{
				this.localUser.atkRecordList = result;
			}
			else
			{
				this.localUser.defRecordList = result;
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/
