using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CommanderCS.Packets.Handlers.Replay
{
    [Packet(Id = Method.GetReplayInfo)]
    public class GetReplayInfo : BaseMethodHandler<GetReplayInfoRequest>
    {
        public override object Handle(GetReplayInfoRequest request)
        {
            if (!int.TryParse(request.rid, out int replayId))
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.Failure },
                };

                return error;
            }

            var replay = DatabaseManager.ReplayList.FindByReplayId(replayId);

            if (replay is null)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.Failure },
                };

                return error;
            }

            var recordUser = DatabaseManager.GameProfile.FindByUno(replay.Uno);

            // Decode the base64 client replay data back to JSON for the client to play
            object replayData = null;
            if (!string.IsNullOrEmpty(replay.ReplayClientData))
            {
                string jsonData = Encoding.UTF8.GetString(Convert.FromBase64String(replay.ReplayClientData));
                replayData = JToken.Parse(jsonData);
            }

            RecordInfo record = new()
            {
                id = replay.ReplayId.ToString(),
                uno = replay.Uno,
                data = replayData,
                _userName = recordUser?.Resources?.nickname ?? "Unknown",
                level = recordUser?.Resources?.level ?? 0,
                thumbnail = recordUser?.Resources?.thumbnailId.ToString() ?? "0",
                date = new DateTimeOffset(replay.Id.CreationTime).ToUnixTimeMilliseconds(),
                guildName = GetGuildName(recordUser),
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = record,
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

    public class GetReplayInfoRequest
    {
        [JsonProperty("rid")]
        public string rid { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }
    }
}

/*	// Token: 0x06005FE5 RID: 24549 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3133", true, true)]
	public void GetReplayInfo(string rid, ERePlayType type)
	{
	}

	// Token: 0x06005FE6 RID: 24550 RVA: 0x001AF954 File Offset: 0x001ADB54
	private IEnumerator GetReplayInfoResult(JsonRpcClient.Request request, Protocols.RecordInfo result)
	{
		if (result = null)
		{
			yield break;
		}
		if (result.data = null)
		{
			if (this.localUser.playingChatRecord !=null)
			{
				this.localUser.playingChatRecord.hasRecord = false;
				this.localUser.playingChatRecord = null;
			}
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("19079"));
			yield break;
		}
		this.localUser.playingChatRecord = null;
		JsonSerializerSettings serializerSettings = RemoteObjectManager.instance.regulation.SerializerSettings;
		Record record = (Record)JsonConvert.DeserializeObject<JToken>(result.data.ToString());
		BattleData battleData = BattleData.Get();
		battleData.isReplayMode = true;
		battleData.record = record;
		battleData.attacker.nickname = record.initState.dualData._playerName;
		battleData.attacker.level = record.initState.dualData._playerLevel;
		battleData.attacker.guildName = record.initState.dualData._playerGuildName;
		battleData.defender.nickname = record.initState.dualData._enemyName;
		battleData.defender.level = record.initState.dualData._enemyLevel;
		battleData.defender.duelRanking = record.initState.dualData._enemyRank;
		battleData.defender.guildName = record.initState.dualData._enemyGuildName;
		battleData.defender.uno = record.initState.dualData._enemyUno;
		BattleData.Set(battleData);
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06005FE7 RID: 24551 RVA: 0x001AF978 File Offset: 0x001ADB78
	private IEnumerator GetReplayInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (this.localUser.playingChatRecord !=null)
		{
			this.localUser.playingChatRecord.hasRecord = false;
			this.localUser.playingChatRecord = null;
		}
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("19079"));
		yield break;
	}*/
