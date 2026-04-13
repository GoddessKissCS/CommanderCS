using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.SetConquestMoveTroop)]
    public class SetConquestMoveTroop : BaseMethodHandler<SetConquestMoveTroopRequest>
    {
        public override object Handle(SetConquestMoveTroopRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            var guild = GetUserGuild();

            if (guild !=null)
            {
                DatabaseManager.Conquest.UpdateTroopPosition(
                    guild.GuildId,
                    request.slot,
                    request.dest,
                    [],
                    0,
                    request.ucash);
            }

            MoveConquestTroop moveData = new()
            {
                path = [],
                distance = 0,
                ucash = request.ucash,
                rsoc = null,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = moveData,
            };

            return response;
        }
    }

    public class SetConquestMoveTroopRequest
    {
        public int dest { get; set; }
        public int slot { get; set; }
        public int ucash { get; set; }
    }
}

/*	// Token: 0x06006072 RID: 24690 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7508", true, true)]
	public void SetConquestMoveTroop(int dest, int slot, int ucash)
	{
	}

	// Token: 0x06006073 RID: 24691 RVA: 0x001B0570 File Offset: 0x001AE770
	private IEnumerator SetConquestMoveTroopResult(JsonRpcClient.Request request, Protocols.MoveConquestTroop result)
	{
		if (result !=null)
		{
			string text = this._FindRequestProperty(request, "slot");
			Protocols.ConquestTroopInfo.Troop troop = this.localUser.conquestDeck[int.Parse(text)];
			troop.point = result.path[result.path.Count - 1];
			troop.path = result.path;
			troop.status = "M";
			troop.remain = result.distance;
			troop.ucash = result.ucash;
			troop.mvtm = result.distance;
			if (troop.remainData = null)
			{
				troop.remainData = new TimeData();
			}
			troop.remainData.SetByDuration((double)troop.remain);
			if (result.rsoc !=null)
			{
				this.localUser.RefreshGoodsFromNetwork(result.rsoc);
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006074 RID: 24692 RVA: 0x001B059C File Offset: 0x001AE79C
	private IEnumerator SetConquestMoveTroopError(JsonRpcClient.Request request, string result, int code)
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
		else if (code = 71506)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		else if (code = 71508)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		else if (code = 20002)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
			this.ReqeustRenewUserGameData();
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/
