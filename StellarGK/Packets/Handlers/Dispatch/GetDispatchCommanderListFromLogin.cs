namespace StellarGK.Host.Handlers.Dispatch
{
    [Packet(MethodId.GetDispatchCommanderListFromLogin)]
    public class GetDispatchCommanderListFromLogin : BaseMethodHandler<GetDispatchCommanderListFromLoginRequest>
    {

        public override object Handle(GetDispatchCommanderListFromLoginRequest @params)
        {
            ResponsePacket responsePacket = new()
            {
                Id = BasePacket.Id,
                Result = GetUserGameProfile().DispatchedCommanders,
            };

            return responsePacket;
        }


    }
    public class GetDispatchCommanderListFromLoginRequest
    {

    }
}
/*	// Token: 0x060060FF RID: 24831 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7172", true, true)]
	public void GetDispatchCommanderListFromLogin()
	{
	}

	// Token: 0x06006100 RID: 24832 RVA: 0x001B10B4 File Offset: 0x001AF2B4
	private IEnumerator GetDispatchCommanderListFromLoginResult(JsonRpcClient.Request request, Dictionary<string, Protocols.DiapatchCommanderInfo> result)
	{
		if (result != null)
		{
			foreach (KeyValuePair<string, Protocols.DiapatchCommanderInfo> keyValuePair in result)
			{
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.cid.ToString());
				if (roCommander != null)
				{
					roCommander.isDispatch = true;
				}
			}
		}
		yield break;
	}

	// Token: 0x06006101 RID: 24833 RVA: 0x001B10D8 File Offset: 0x001AF2D8
	private IEnumerator GetDispatchCommanderListFromLoginError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/