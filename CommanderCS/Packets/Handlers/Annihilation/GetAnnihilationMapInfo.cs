using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Annihilation
{
    [Packet(Id = Method.GetAnnihilationMapInfo)]
    public class GetAnnihilationMapInfo : BaseMethodHandler<GetAnnihilationMapInfoRequest>
    {
        public override object Handle(GetAnnihilationMapInfoRequest @params)
        {
            switch (@params.goReady)
            {
                case 0:
                    break;
            }

            // still needs work

            AnnihilationMode mode = AnnihilationMode.NONE;

            var annimap = new AnnihilationMapInfo()
            {
                stage = 0,
                remainTime = 0,
                commanderStatusList = [],
                dieCommanderList = [],
                clear = 0,
                enemyList = [],
                isPlayAdvanceParty = 0,
                mode = mode,
                __advancePartyReward = 0,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = annimap
            };

            return response;
        }
    }

    public class GetAnnihilationMapInfoRequest
    {
        [JsonProperty("goReady")]
        public int goReady { get; set; }
    }
}

/*	// Token: 0x060060A6 RID: 24742 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3135", true, true)]
	public void GetAnnihilationMapInfo(int goReady)
	{
	}

	// Token: 0x060060A7 RID: 24743 RVA: 0x001B09A4 File Offset: 0x001AEBA4
	private IEnumerator GetAnnihilationMapInfoResult(JsonRpcClient.Request request, Protocols.AnnihilationMapInfo result)
	{
		string text = this._FindRequestProperty(request, "goReady");
		this.localUser.lastClearAnnihilationStage = result.stage;
		this.localUser.CommanderStatusReset();
		if (result.dieCommanderList is not null)
		{
			for (int i = 0; i < result.dieCommanderList.Count; i++)
			{
				RoCommander roCommander = this.localUser.FindCommander(result.dieCommanderList[i]);
				if (roCommander is not null)
				{
					roCommander.Die();
				}
			}
		}
		if (result.commanderStatusList is not null)
		{
			for (int j = 0; j < result.commanderStatusList.Count; j++)
			{
				Protocols.AnnihilationMapInfo.StatusData statusData = result.commanderStatusList[j];
				RoCommander roCommander2 = this.localUser.FindCommander(statusData.id);
				if (roCommander2 is not null)
				{
					if (!roCommander2.isDie)
					{
						roCommander2.sp = statusData.sp;
						roCommander2.dmgHp = statusData.dmghp;
					}
				}
			}
		}
		UIAnnihilationMap annihilationMap = UIManager.instance.world.annihilationMap;
		annihilationMap.isPlay = result.dieCommanderList.Count > 0;
		annihilationMap.isPlayAdvanceParty = result.isPlayAdvanceParty != 0;
		annihilationMap.SetEnemy(result.enemyList);
		annihilationMap.SetTime(result.remainTime, result.clear);
		annihilationMap.SetMode(result.mode);
		annihilationMap.InitAndOpenAnnihilationMap(int.Parse(text) == 1);
		yield break;
	}

	// Token: 0x060060A8 RID: 24744 RVA: 0x001B09D0 File Offset: 0x001AEBD0
	private IEnumerator GetAnnihilationMapInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70107)
		{
			UIPopup.Create<UISelectAnnihilationModePopup>("ModeSelectPopup").InitAndOpen();
			yield break;
		}
		yield break;
	}*/