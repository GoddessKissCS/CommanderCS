using CommanderCS.Database;
using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.AppointSubMaster)]
    public class AppointSubMaster : BaseMethodHandler<AppointSubMasterRequest>
    {
        public override object Handle(AppointSubMasterRequest @params)
        {
            var user = GetUserGameProfile();

            int submaster = DatabaseManager.Guild.GetTotalSubMasters(user.GuildId);

            if (submaster > 2)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = ErrorCode.YouCanOnlyAppointUpTo2SubMaster },
                    Id = BasePacket.Id,
                };

                return error;
            }

            bool succeed = DatabaseManager.Guild.AppointSubMaster(@params.tuno, user.GuildId);

            if (!succeed)
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
                Result = "appointed",
            };

            return response;
        }
    }

    public class AppointSubMasterRequest
    {
        [JsonProperty("tuno")]
        public int tuno { get; set; }
    }
}

/*	// Token: 0x06006046 RID: 24646 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7257", true, true)]
	public void AppointSubMaster(int tuno)
	{
	}

	// Token: 0x06006047 RID: 24647 RVA: 0x001B01B0 File Offset: 0x001AE3B0
	private IEnumerator AppointSubMasterResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "tuno"));
		UIManager.instance.world.guild.AppointSubMaster(true, num);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006048 RID: 24648 RVA: 0x001B01D4 File Offset: 0x001AE3D4
	private IEnumerator AppointSubMasterError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			int num = int.Parse(this._FindRequestProperty(request, "tuno"));
			UIManager.instance.world.guild.RemoveMemberList(num);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110228"));
		}
		else if (code = 71019)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Format("110114", new object[] { this.regulation.defineDtbl["GUILD_MAX_AIDE"].value }));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/