using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Gacha
{
	[Packet(Id = Library.Enums.Method.GachaRatingInformationType)]
	public class GachaRatingInformationType : BaseMethodHandler<GachaRatingInformationTypeRequest>
    {
        public override object Handle(GachaRatingInformationTypeRequest @params)
        {

			Dictionary<ERewardType, GachaRatingDataTypeA> gameRatingDataA = new()
			{

			};

            Dictionary<ERewardType, GachaRatingDataTypeB> gameRatingDataB = new()
            {

            };

			gameRatingDataA.Add(ERewardType.Costume, new() { rating = 1 });

			ResponsePacket response = new()
			{
				Id = BasePacket.Id,
				Result = null
			};

			return response;

        }
    }

    public class GachaRatingInformationTypeRequest
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
		if (result = null)
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
			if (dictionary2 is not null)
			{
				this.localUser.RefreshGachaProbabilityTypeAFromNetwork(key, dictionary2);
			}
			if (dictionary3 is not null)
			{
				this.localUser.RefreshGachaProbabilityTypeBFromNetwork(key, dictionary3);
			}
		}
		yield break;
	}*/