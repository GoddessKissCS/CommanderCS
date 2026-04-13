using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.GetConquestTroop)]
    public class GetConquestTroop : BaseMethodHandler<GetConquestTroopRequest>
    {
        public override object Handle(GetConquestTroopRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            var guild = GetUserGuild();

            ConquestTroopInfo troopInfo = guild is not null
                ? DatabaseManager.Conquest.GetTroopInfo(guild.GuildId)
                : new() { slot = [0, 1, 2], squard = [], eGuild = new() };

            return new ResponsePacket
            {
                Id = BasePacket.Id,
                Result = troopInfo,
            };
        }
    }

    public class GetConquestTroopRequest
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7504", true, true)]
	public void GetConquestTroop()
	{
	}

	// Token: 0x06006067 RID: 24679 RVA: 0x001B045C File Offset: 0x001AE65C
	private IEnumerator GetConquestTroopResult(JsonRpcClient.Request request, Protocols.ConquestTroopInfo result)
	{
		if (result is not null && UIManager.instance.world.guild.isActive)
		{
			this.localUser.ResetConquestSlot();
			UIManager.instance.world.conquestMap.InitAndOpenConquestMap();
			UIManager.instance.world.conquestMap._Set(result);
		}
		yield break;
	}

	// Token: 0x06006068 RID: 24680 RVA: 0x001B0480 File Offset: 0x001AE680
	private IEnumerator GetConquestTroopError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
		}
		else if (code = 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code = 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code = 71507)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/
