using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.KeepAlives
{
    public class MissionReward
    {
        
    }
}
/*	// Token: 0x06005FA2 RID: 24482 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6233", true, true)]
	public void MissionReward(int dmid)
	{
	}

	// Token: 0x06005FA3 RID: 24483 RVA: 0x001AF420 File Offset: 0x001AD620
	private IEnumerator MissionRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "dmid");
		RoMission roMission = this.localUser.FindMission(text);
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_DailyMission_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.badgeMissionCount--;
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		roMission.received = true;
		this.localUser.missionCompleteCount++;
		UIManager.instance.world.warHome.Set(EReward.DailyMission);
		this._CheckReceiveTestData("MissionRewardResult");
		yield break;
	}

	// Token: 0x06005FA4 RID: 24484 RVA: 0x001AF44C File Offset: 0x001AD64C
	private IEnumerator MissionRewardError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 13001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7044"));
		}
		yield break;
	}*/