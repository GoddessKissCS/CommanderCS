using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Mail
{
    public class ReadMail
    {
        
    }
}
/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6103", true, true)]
	public void ReadMail(int idx)
	{
	}

	// Token: 0x06005F72 RID: 24434 RVA: 0x001AF020 File Offset: 0x001AD220
	private IEnumerator ReadMailResult(JsonRpcClient.Request request, string result)
	{
		this.localUser.badgeNewMailCount--;
		string text = this._FindRequestProperty(request, "idx");
		RoReward roReward = this.localUser.FindReward(text);
		roReward.received = true;
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("ReadMailResult");
		yield break;
	}*/