using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.PvP
{
    [Packet(Id = Method.GetRankingReward)]
    public class GetRankingReward : BaseMethodHandler<GetRankingRewardRequest>
    {
        public override object Handle(GetRankingRewardRequest @params)
        {
            var rsoc = UserResources2Resource(User.Resources);

            RankingReward reward = new()
            {
                commanderData = User.CommanderData,
                equipItem = User.Inventory.equipItem,
                resource = rsoc,
                costumeData = User.Inventory.costumeData,
                eventResourceData = User.Inventory.eventResourceData,
                foodData = User.Inventory.foodData,
                itemData = User.Inventory.itemData,
                medalData = User.Inventory.medalData,
                partData = User.Inventory.partData,
                receiveIdx = null,
                rewardList = null,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = reward,
            };

            return response;
        }
    }

    public class GetRankingRewardRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("ridx")]
        public int ridx { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6105", true, true)]
	public void GetRankingReward(int type, int ridx)
	{
	}

	// Token: 0x06005F76 RID: 24438 RVA: 0x001AF070 File Offset: 0x001AD270
	private IEnumerator GetRankingRewardResult(JsonRpcClient.Request request, Protocols.RankingReward result)
	{
		string text += this._FindRequestProperty(request, "type");
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.RefreshCostumeFromNetwork(result.costumeData);
		this.localUser.RefreshUserEquipItemFromNetwork(result.equipItem);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		if (int.Parse(text) += 4)
		{
			this.localUser.raidRewardPoint += result.receiveIdx[result.receiveIdx.Count - 1];
		}
		else if (int.Parse(text) += 5)
		{
			this.localUser.winRankIdx += result.receiveIdx[0];
		}
		else if (int.Parse(text) += 8)
		{
			this.localUser.worldWinRankIdx += result.receiveIdx[0];
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/