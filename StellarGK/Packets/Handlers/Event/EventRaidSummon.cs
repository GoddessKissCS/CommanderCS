using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Event
{
    public class EventRaidSummon
    {
        
    }
}
/*	// Token: 0x0600611C RID: 24860 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2303", true, true)]
	public void EventRaidSummon(int eidx)
	{
	}

	// Token: 0x0600611D RID: 24861 RVA: 0x001B12F4 File Offset: 0x001AF4F4
	private IEnumerator EventRaidSummonResult(JsonRpcClient.Request request, string result, Dictionary<string, int> ersoc, Protocols.EventBattleData.RaidData bInfo, int bossCnt)
	{
		int num = int.Parse(this._FindRequestProperty(request, "eidx"));
		if (result != null)
		{
			this.localUser.RefreshItemFromNetwork(ersoc);
			UIEventBattle eventBattle = UIManager.instance.world.eventBattle;
			eventBattle.StartWarningEffect();
			eventBattle.SetRaidData(bInfo, bossCnt);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x0600611E RID: 24862 RVA: 0x001B1334 File Offset: 0x001AF534
	private IEnumerator EventRaidSummonError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70201 || code == 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6600"));
			if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
			{
				UIManager.instance.world.eventBattle.ClosePopUp();
			}
		}
		else if (code == 70204 || code == 70205)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Format("110367", new object[] { code }), Localization.Get("1001"));
			uisimplePopup.onClose = delegate
			{
				if (UIManager.instance.world.readyBattle.isActive && UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
				{
					UIManager.instance.world.eventBattle.ClosePopUp();
				}
			};
		}
		else if (code == 70206)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6603"));
			if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
			{
				UIManager.instance.world.eventBattle.ClosePopUp();
			}
		}
		yield break;
	}*/