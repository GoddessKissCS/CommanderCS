using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Dispatch
{
    [Packet(Id = Method.RecallDispatch)]
    public class RecallDispatch : BaseMethodHandler<RecallDispatchRequest>
    {
        public override object Handle(RecallDispatchRequest @params)
        {
            // TODO: add errorhandling

            var RecallCommander = new RecallCommander();

            if (User.DispatchedCommanders is not null)
            {
                string slot = @params.slot.ToString();

                User.DispatchedCommanders.TryGetValue(slot, out var dispatchedCommanderInfo);

                int runtime = (int)TimeManager.GetTimeDifferenceInHours(dispatchedCommanderInfo.DispatchTime);
                int dispatchTime = (int)TimeManager.GetTimeDifference(dispatchedCommanderInfo.DispatchTime);

                int runetimeGold = 0;
                int engageGold = 0;
                int engageCount = dispatchedCommanderInfo.engageCnt;

                User.CommanderData.TryGetValue(dispatchedCommanderInfo.cid.ToString(), out var commander);

                if (runtime >= 1)
                {
                    runetimeGold = runtime * GetDispatchGold(commander.__level, commander.__cls, commander.__rank);

                    if (engageCount >= 1)
                    {
                        engageGold = engageCount * (int)(GetdispatchFloatGold(commander.__level, commander.__cls, commander.__rank) * 10f);
                    }
                }

                RecallCommander.runtime = dispatchTime;
                RecallCommander.getGold_engage = engageGold;
                RecallCommander.getGold_time = runetimeGold;

                int updateGold = engageGold + runetimeGold;

                DatabaseManager.GameProfile.UpdateGold(SessionId, updateGold, true);

                User.DispatchedCommanders.Remove(slot);

                DatabaseManager.GameProfile.UpdateDispatchedCommander(SessionId, User.DispatchedCommanders);
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            RecallCommander.resource = rsoc;

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = RecallCommander,
            };

            return response;
        }

        public int GetDispatchGold(string level, string cls, string rank) => GetDispatchGold(int.Parse(level), int.Parse(cls), int.Parse(rank));

        public int GetDispatchGold(int level, int cls, int rank)
        {
            return (int)((level + cls) * rank / 11f * 60f);
        }

        public float GetdispatchFloatGold(string level, string cls, string rank) => GetDispatchGold(int.Parse(level), int.Parse(cls), int.Parse(rank));

        public float GetdispatchFloatGold(int level, int cls, int rank)
        {
            return (level + cls) * rank / 11f * 60f;
        }
    }

    public class RecallDispatchRequest
    {
        [JsonProperty("slot")]
        public int slot { get; set; }
    }
}

/*	// Token: 0x060060BB RID: 24763 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7173", true, true)]
	public void RecallDispatch(int slot)
	{
	}

	// Token: 0x060060BC RID: 24764 RVA: 0x001B0B44 File Offset: 0x001AED44
	private IEnumerator RecallDispatchResult(JsonRpcClient.Request request, Protocols.RecallCommander result)
	{
		if (result is not null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.ResetDispatchPossible();
			DispatchRecallResultPopup dispatchRecallResultPopup = UIPopup.Create<DispatchRecallResultPopup>("resultPopup");
			if (UIManager.instance.world.guild.dispatch is not null)
			{
				dispatchRecallResultPopup.SetPopup(result.runtime, result.getGold_time, result.getGold_engage);
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x060060BD RID: 24765 RVA: 0x001B0B68 File Offset: 0x001AED68
	private IEnumerator RecallDispatchError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71203)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110010"));
		}
		else if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.CloseDispatchPopup();
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}*/