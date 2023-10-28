namespace StellarGK.Packets.Handlers.Gacha
{
    public class GachaRatingInformationType
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6315", true, true)]
	public void GachaRatingInformationType()
	{
	}

	// Token: 0x06005F63 RID: 24419 RVA: 0x001AEF08 File Offset: 0x001AD108
	private IEnumerator GachaRatingInformationTypeResult(JsonRpcClient.Request request, object result)
	{
		if (result == null)
		{
			yield break;
		}
		Dictionary<string, object> dictionary = this._ConvertJObject<Dictionary<string, object>>(result);
		foreach (KeyValuePair<string, object> keyValuePair in dictionary)
		{
			string key = keyValuePair.Key;
			object value = keyValuePair.Value;
			Dictionary<ERewardType, Protocols.GachaRatingDataTypeA> dictionary2 = this._ConvertJObject<Dictionary<ERewardType, Protocols.GachaRatingDataTypeA>>(value);
			Dictionary<ERewardType, Protocols.GachaRatingDataTypeB> dictionary3 = this._ConvertJObject<Dictionary<ERewardType, Protocols.GachaRatingDataTypeB>>(value);
			if (dictionary2 != null)
			{
				this.localUser.RefreshGachaProbabilityTypeAFromNetwork(key, dictionary2);
			}
			if (dictionary3 != null)
			{
				this.localUser.RefreshGachaProbabilityTypeBFromNetwork(key, dictionary3);
			}
		}
		yield break;
	}*/