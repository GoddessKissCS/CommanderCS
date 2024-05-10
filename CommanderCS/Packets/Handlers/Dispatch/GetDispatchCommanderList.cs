using CommanderCS.Host;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Packets.Handlers.Dispatch
{
    [Packet(Id = Method.GetDispatchCommanderList)]
    public class GetDispatchCommanderList : BaseMethodHandler<GetDispatchCommanderListRequest>
    {
        public override object Handle(GetDispatchCommanderListRequest @params)
        {
            if (Guild.LastEdit != null)
            {
                var difference = TimeManager.GetTimeDifference((double)Guild.LastEdit);

                if (difference < 30)
                {
                    ErrorPacket error = new()
                    {
                        Error = new() { code = ErrorCode.FederationSettingsChangedWhileGettingGuildBoard },
                        Id = BasePacket.Id,
                    };
                    return error;
                }
            }

            Dictionary<string, DiapatchCommanderInfo> dispatchedcommanders = [];

            if (User.DispatchedCommanders != null)
            {
                foreach (var item in User.DispatchedCommanders)
                {
                    int runtime = (int)TimeManager.GetTimeDifferenceInHours(item.Value.DispatchTime);
                    int dispatchTime = (int)TimeManager.GetTimeDifference(item.Value.DispatchTime);

                    int gold = 0;

                    int engageCount = item.Value.engageCnt;

                    string stringedItem = item.Value.cid.ToString();

                    User.CommanderData.TryGetValue(stringedItem, out var commander);

                    if (runtime >= 1)
                    {
                        gold = runtime * GetDispatchGold(commander.__level, commander.__cls, commander.__rank);
                    }

                    DiapatchCommanderInfo dispatchedCommanders = new()
                    {
                        cid = item.Value.cid,
                        engageCnt = engageCount,
                        runtime = dispatchTime,
                        getGold = gold
                    };

                    dispatchedcommanders.Add(item.Key, dispatchedCommanders);
                }
            }
            else
            {
                dispatchedcommanders = null;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = dispatchedcommanders,
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

    public class GetDispatchCommanderListRequest
    {
    }
}

/*	// Token: 0x060060B8 RID: 24760 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7170", true, true)]
	public void GetDispatchCommanderList()
	{
	}

	// Token: 0x060060B9 RID: 24761 RVA: 0x001B0B04 File Offset: 0x001AED04
	private IEnumerator GetDispatchCommanderListResult(JsonRpcClient.Request request, Dictionary<string, Protocols.DiapatchCommanderInfo> result)
	{
		if (result != null)
		{
			this.localUser.slotDispatchInfo.Clear();
			foreach (KeyValuePair<string, Protocols.DiapatchCommanderInfo> keyValuePair in result)
			{
				RoLocalUser.SlotDispatchInfo slotDispatchInfo = new RoLocalUser.SlotDispatchInfo();
				slotDispatchInfo.SlotNum = keyValuePair.Key;
				slotDispatchInfo.dispatchCommanderInfo = keyValuePair.Value;
				this.localUser.slotDispatchInfo.Add(slotDispatchInfo);
			}
			if (UIManager.instance.world.guild.dispatch != null)
			{
				UIManager.instance.world.guild.dispatch.SetDispatchList();
			}
		}
		yield break;
	}

	// Token: 0x060060BA RID: 24762 RVA: 0x001B0B28 File Offset: 0x001AED28
	private IEnumerator GetDispatchCommanderListError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.CloseDispatchPopup();
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}
*/