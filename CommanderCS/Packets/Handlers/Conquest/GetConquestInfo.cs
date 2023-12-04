using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.GetConquestInfo)]
    public class GetConquestInfo : BaseMethodHandler<GetConquestInfoRequest>
    {
        public override object Handle(GetConquestInfoRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = null,
            };

            return response;
        }
    }

    public class GetConquestInfoRequest
    {
    }
}

/*	// Token: 0x0600605D RID: 24669 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7502", true, true)]
	public void GetConquestInfo()
	{
	}

	// Token: 0x0600605E RID: 24670 RVA: 0x001B038C File Offset: 0x001AE58C
	private IEnumerator GetConquestInfoResult(JsonRpcClient.Request request, Protocols.ConquestInfo result)
	{
		if (!this.localUser.IsExistGuild())
		{
			yield break;
		}
		if (result != null)
		{
			UIManager.instance.world.guild.SetConquestState(result);
		}
		yield break;
	}

	// Token: 0x0600605F RID: 24671 RVA: 0x001B03B0 File Offset: 0x001AE5B0
	private IEnumerator GetConquestInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110365"));
			UIManager.instance.world.guild.SetConquestError();
		}
		yield break;
	}*/