﻿namespace StellarGK.Packets.Handlers.Unit
{
    public class UnitLevelUpImmediate
    {
    }
}
/*
    [JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4302", true, true)]
	public void UnitLevelUpImmediate(int idx)
	{
	}

    private IEnumerator UnitLevelUpImmediateResult(JsonRpcClient.Request request, string result, int cash)
	{
		string text = this._FindRequestProperty(request, "idx");
		if (string.IsNullOrEmpty(text))
		{
			yield break;
		}
		RoUnit roUnit = this.localUser.FindUnit(text);
		roUnit.trainingTime.SetInvalidValue();
		this.localUser.cash = cash;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F46 RID: 24390 RVA: 0x001AEC78 File Offset: 0x001ACE78
	private IEnumerator UnitLevelUpImmediateError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}*/