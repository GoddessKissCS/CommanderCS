using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.BuyConquestTroopSlot)]
    public class BuyConquestTroopSlot : BaseMethodHandler<BuyConquestTroopSlotRequest>
    {
        public override object Handle(BuyConquestTroopSlotRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            var user = GetUserGameProfile();
            var guild = GetUserGuild();

            // not sure how much to subtract and if they perma stay so this stays for now ig

            // -5 diamonds per deck ig

            if (guild is not null)
            {
                DatabaseManager.Conquest.AddSlot(guild.GuildId, request.slot);
            }

            JObject tutorialResponse = new()
            {
                ["id"] = BasePacket.Id,
                ["result"] = new JObject
                {
                    ["rsoc"] = JObject.FromObject(UserResources2Resource(user.Resources)),
                }
            };

            return tutorialResponse;
        }
    }

    public class BuyConquestTroopSlotRequest
    {
        public int slot { get; set; }
    }
}

/*	// Token: 0x06006069 RID: 24681 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7506", true, true)]
	public void BuyConquestTroopSlot(int slot)
	{
	}

	// Token: 0x0600606A RID: 24682 RVA: 0x001B049C File Offset: 0x001AE69C
	private IEnumerator BuyConquestTroopSlotResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc)
	{
		if (result is not null)
		{
			string text = this._FindRequestProperty(request, "slot");
			this.localUser.RefreshGoodsFromNetwork(rsoc);
			this.localUser.conquestDeckSlotState.Add(int.Parse(text));
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x0600606B RID: 24683 RVA: 0x001B04CC File Offset: 0x001AE6CC
	private IEnumerator BuyConquestTroopSlotError(JsonRpcClient.Request request, string result, int code)
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
		else if (code = 71505)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		else if (code = 20002)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/
