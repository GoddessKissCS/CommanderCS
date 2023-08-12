using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.KeepAlives
{
    public class UseTimeMachineSweep
    {
        
    }
}
/*	// Token: 0x06005FFB RID: 24571 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3201", true, true)]
	public void UseTimeMachineSweep(int stype, int lv, int cnt)
	{
	}

	// Token: 0x06005FFC RID: 24572 RVA: 0x001AFAF4 File Offset: 0x001ADCF4
	private IEnumerator UseTimeMachineSweepResult(JsonRpcClient.Request request, Protocols.PlunderTimeMachine result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		if (!this.localUser.statistics.isBuyVipShop && result.VipShopOpen == 1)
		{
			this.localUser.statistics.vipShopResetTime_Data.SetByDuration((double)result.VipShopRemainTime);
			this.localUser.statistics.vipShop = result.VipShopOpen;
			this.localUser.statistics.vipShopisFloating = true;
			this.ScheduleLocalPush(ELocalPushType.LeaveVipShop, result.VipShopRemainTime);
		}
		UIManager.instance.RefreshOpenedUI();
		UIPopup.Create<UITimeMachinePopup>("TimeMachinePopup").Init(result.reward, ETimeMachineType.Sweep);
		yield break;
	}*/