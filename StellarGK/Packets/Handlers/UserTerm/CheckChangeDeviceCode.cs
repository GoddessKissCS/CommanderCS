namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.CheckChangeDeviceCode)]
    public class CheckChangeDeviceCode : BaseCommandHandler<CheckChangeDeviceCodeRequest>
    {

        public override object Handle(CheckChangeDeviceCodeRequest @params)
        {
            return "{}";
        }

    }
    public class CheckChangeDeviceCodeRequest { }

}
/*		// Token: 0x060060CC RID: 24780 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1231", true, true)]
	public void CheckChangeDeviceCode(string dac, int ch)
	{
	}

	// Token: 0x060060CD RID: 24781 RVA: 0x001B0CB4 File Offset: 0x001AEEB4
	private IEnumerator CheckChangeDeviceCodeResult(JsonRpcClient.Request request, string result, Platform plfm)
	{
		this.localUser.changeDeviceCode = this._FindRequestProperty(request, "dac");
		Protocols.OSCode oscode = Protocols.OSCode.Android;
		UIPopup.Create<UISelectPlatformPopup>("SelectPlatformPopup").InitAndOpen(oscode, plfm);
		yield break;
	}

	// Token: 0x060060CE RID: 24782 RVA: 0x001B0CE0 File Offset: 0x001AEEE0
	private IEnumerator CheckChangeDeviceCodeError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 10024)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("19525"));
		}
		yield break;
	}*/