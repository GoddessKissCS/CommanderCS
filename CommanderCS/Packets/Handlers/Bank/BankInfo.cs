using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Bank
{
    [Packet(Id = Method.BankInfo)]
    public class BankInfo : BaseMethodHandler<BankInfoRequest>
    {
        public override object Handle(BankInfoRequest @params)
        {
            throw new NotImplementedException();
        }
    }

    public class BankInfoRequest
    {
    }
}

/*	// Token: 0x06005FC7 RID: 24519 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5302", true, true)]
	public void BankInfo()
	{
	}

	// Token: 0x06005FC8 RID: 24520 RVA: 0x001AF70C File Offset: 0x001AD90C
	private IEnumerator BankInfoResult(JsonRpcClient.Request request, Protocols.BankInfo result)
	{
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/