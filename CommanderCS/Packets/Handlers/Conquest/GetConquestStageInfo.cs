using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.GetConquestStageInfo)]
    public class GetConquestStageInfo : BaseMethodHandler<GetConquestStageInfoRequest>
    {
        public override object Handle(GetConquestStageInfoRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = null,
            };

            ConquestStageInfo stageInfo = new()
            {
                enemyInfo = new ConquestStageInfo.EnemyInfo()
                {
                    name = "Enemy Guild",
                    emblem = "",
                    gidx = 0,
                },
                alieList = [new() {
					auth = 1,
					standby = 1, 
					level = 140,
					move = 0,
					name = "Zen",
					thumb = "1001",
					uno = "1001"
				}],
                enemyList = [new() {
                    auth = 1,
                    standby = 1,
                    level = 140,
                    move = 1,
                    name = "Zen1",
                    thumb = "1001",
                    uno = "1001"
                }],
            };

            response.Result = stageInfo;

            return response;
        }
    }

    public class GetConquestStageInfoRequest
    {
        public int point { get; set; }
    }
}

/*	// Token: 0x0600606C RID: 24684 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7510", true, true)]
	public void GetConquestStageInfo(int point)
	{
	}

	// Token: 0x0600606D RID: 24685 RVA: 0x001B04E8 File Offset: 0x001AE6E8
	private IEnumerator GetConquestStageInfoResult(JsonRpcClient.Request request, Protocols.ConquestStageInfo result)
	{
		if (result !=null)
		{
			UIConquestMap conquestMap = UIManager.instance.world.conquestMap;
			if (conquestMap.isActive)
			{
				conquestMap.CreateStageInfoPopup(result);
			}
		}
		yield break;
	}

	// Token: 0x0600606E RID: 24686 RVA: 0x001B0504 File Offset: 0x001AE704
	private IEnumerator GetConquestStageInfoError(JsonRpcClient.Request request, string result, int code)
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
		UIManager.instance.world.guild.Close();
		yield break;
	}*/