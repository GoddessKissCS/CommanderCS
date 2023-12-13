using CommanderCS.Enum.Packet;
using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Annihilation
{
    [Packet(Id = Method.GetAnnihilationMapInfo)]
    public class GetAnnihilationMapInfo : BaseMethodHandler<GetAnnihilationMapInfoRequest>
    {
        public override object Handle(GetAnnihilationMapInfoRequest @params)
        {
            return "{}";
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
		if (result.dieCommanderList != null)
		{
			for (int i = 0; i < result.dieCommanderList.Count; i++)
			{
				RoCommander roCommander = this.localUser.FindCommander(result.dieCommanderList[i]);
				if (roCommander != null)
				{
					roCommander.Die();
				}
			}
		}
		if (result.commanderStatusList != null)
		{
			for (int j = 0; j < result.commanderStatusList.Count; j++)
			{
				Protocols.AnnihilationMapInfo.StatusData statusData = result.commanderStatusList[j];
				RoCommander roCommander2 = this.localUser.FindCommander(statusData.id);
				if (roCommander2 != null)
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