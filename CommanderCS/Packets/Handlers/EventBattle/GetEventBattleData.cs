using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.EventBattle
{
    [Packet(Id = Method.GetEventBattleData)]
    public class GetEventBattleData : BaseMethodHandler<GetEventBattleDataRequest>
    {
        public override object Handle(GetEventBattleDataRequest request)
        {
            var eventBattle = RemoteObjectManager.instance.regulation.eventBattleDtbl.Find(x => x.eventIdx == request.eidx.ToString());

            if (eventBattle == null)
            {
                return new ResponsePacket
                {
                    Id = BasePacket.Id,
                    Result = JObject.FromObject(new object()),
                };
            }

            var stages = RemoteObjectManager.instance.regulation.eventBattleFieldDtbl.FindAll(x => x.eventIdx == request.eidx);

            Dictionary<int, int> clearList = [];
            foreach (var stage in stages)
            {
                clearList[stage.idx] = 0;
            }

            EventBattleData eventBattleData = new()
            {
                eventData = new()
                {
                    efid = eventBattle.eventIdx,
                    esid = "0",
                    remain = 0,
                    type = 0,
                },
                raidData = new()
                {
                    remain = 0,
                },
                bossCnt = 0,
                rewardCnt = 0,
                rewardCntAll = 0,
                clearList = clearList,
            };

            return new ResponsePacket
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(eventBattleData),
            };
        }
    }

    public class GetEventBattleDataRequest
    {
        [JsonProperty("eidx")]
        public int eidx { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }
    }
}

/*	// Token: 0x06006119 RID: 24857 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2302", true, true)]
	public void GetEventBattleData(int eidx, int level)
	{
	}

	// Token: 0x0600611A RID: 24858 RVA: 0x001B12AC File Offset: 0x001AF4AC
	private IEnumerator GetEventBattleDataResult(JsonRpcClient.Request request, Protocols.EventBattleData result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "eidx"));
		int num2 = int.Parse(this._FindRequestProperty(request, "level"));
		if (result !=null)
		{
			if (UIManager.instance.world !=null)
			{
				UIEventBattle uieventBattle;
				if (!UIManager.instance.world.existEventBattle)
				{
					uieventBattle = UIManager.instance.world.eventBattle;
					uieventBattle.Init();
				}
				else
				{
					uieventBattle = UIManager.instance.world.eventBattle;
					if (!UIManager.instance.world.eventBattle.isActive)
					{
						uieventBattle.Init();
					}
				}
				uieventBattle.SetEventBattle(num, result);
				if (num2 > 0)
				{
					uieventBattle.StartEventReadyBattle(num2);
				}
				else if (num2 = 0)
				{
					uieventBattle.CreateEventRaidListPopup(2);
				}
			}
			else
			{
				this.localUser.lastShowEventScenarioPlayTurn = int.Parse(result.eventData.esid);
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x0600611B RID: 24859 RVA: 0x001B12D8 File Offset: 0x001AF4D8
	private IEnumerator GetEventBattleDataError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70201 || code = 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6600"));
		}
		else if (code = 70204 || code = 70205)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		yield break;
	}*/
