using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Event
{
    public class GetRotationBannerInfo
    {
        
    }
}
/*	// Token: 0x06006115 RID: 24853 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6401", true, true)]
	public void GetRotationBannerInfo()
	{
	}

	// Token: 0x06006116 RID: 24854 RVA: 0x001B1274 File Offset: 0x001AF474
	private IEnumerator GetRotationBannerInfoResult(JsonRpcClient.Request request, Protocols.RotationBanner result)
	{
		if (result == null)
		{
			if (UIManager.instance.world.mainCommand != null)
			{
				UISetter.SetActive(UIManager.instance.world.mainCommand.banner.gameObject, false);
			}
		}
		else if (result.bannerList != null && result.bannerList.Count > 0)
		{
			UIMainCommand mainCommand = UIManager.instance.world.mainCommand;
			if (mainCommand != null)
			{
				UISetter.SetActive(mainCommand.banner, true);
				mainCommand.banner.InitUrlList(result);
			}
		}
		else
		{
			UISetter.SetActive(UIManager.instance.world.mainCommand.banner.gameObject, false);
		}
		yield break;
	}*/