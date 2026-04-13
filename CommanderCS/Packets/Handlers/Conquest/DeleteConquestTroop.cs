using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.DeleteConquestTroop)]
    public class DeleteConquestTroop : BaseMethodHandler<DeleteConquestTroopRequest>
    {
        public override object Handle(DeleteConquestTroopRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "True",
            };

            var guild = GetUserGuild();

            if (guild is null)
            {
                return response;
            }

            DatabaseManager.Conquest.DeleteTroop(guild.GuildId, request.slot);

            return response;
        }
    }

    public class DeleteConquestTroopRequest
    {
        public int slot { get; set; }
    }
}

/*	// Token: 0x06006063 RID: 24675 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7505", true, true)]
	public void DeleteConquestTroop(int slot)
	{
	}

	// Token: 0x06006064 RID: 24676 RVA: 0x001B0414 File Offset: 0x001AE614
	private IEnumerator DeleteConquestTroopResult(JsonRpcClient.Request request, string result)
	{
		if (result.Equals("True"))
		{
			int num = int.Parse(this._FindRequestProperty(request, "slot"));
			for (int i = 0; i < this.localUser.commanderList.Count; i++)
			{
				RoCommander roCommander = this.localUser.commanderList[i];
				if (roCommander.conquestDeckId = num)
				{
					roCommander.conquestDeckId = 0;
				}
			}
			this.localUser.conquestDeck[num] = null;
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006065 RID: 24677 RVA: 0x001B0440 File Offset: 0x001AE640
	private IEnumerator DeleteConquestTroopError(JsonRpcClient.Request request, string result, int code)
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
		else if (code = 71503)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/
