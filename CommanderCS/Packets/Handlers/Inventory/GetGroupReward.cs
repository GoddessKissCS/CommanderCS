using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace CommanderCS.Packets.Handlers.Inventory
{
    [Packet(Id = Method.GetGroupReward)]
    public class GetGroupReward : BaseMethodHandler<GetGroupRewardRequest>
    {
        public override object Handle(GetGroupRewardRequest request)
        {
			var groupId = request.giIdx.ToString();

            var groupRewardData = RemoteObjectManager.instance.regulation.groupInfoDtbl[groupId];

			var rewardIdx = groupRewardData.rewardIdx.ToString();

            RewardInfo result = new()
			{
				reward =
				[
					new(){
						effect = 0,
						rewardCnt = groupRewardData.minCount,
						rewardId = rewardIdx,
						rewardType = groupRewardData.rewardType
					}
				],
			};

			DatabaseManager.GameProfile.AddCompleteRewardGroupIdx(SessionId, request.giIdx);

			var user = GetUserGameProfile();

			switch(groupRewardData.rewardType)
			{
				case ERewardType.Goods:
					switch (groupRewardData.rewardIdx)
					{
						case 2:
							user.Resources.cash += groupRewardData.minCount;
							DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, groupRewardData.minCount, true);
							result.resource = UserResources2Resource(user.Resources);
							break;
                        case 55:
                            if (!user.Inventory.foodData.TryAdd(rewardIdx, groupRewardData.minCount))
								user.Inventory.foodData[rewardIdx] += groupRewardData.minCount;
							DatabaseManager.GameProfile.UpdateFoodData(SessionId, user.Inventory.foodData);
							result.foodData = user.Inventory.foodData;
                            break;

                        default:
							if (!user.Inventory.itemData.TryAdd(rewardIdx, groupRewardData.minCount))
								user.Inventory.itemData[rewardIdx] += groupRewardData.minCount;
							DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
							result.itemData = user.Inventory.itemData;
							break;
                    }
					break;

                case ERewardType.UnitMaterial:
					if (!user.Inventory.partData.TryAdd(rewardIdx, groupRewardData.minCount))
						user.Inventory.partData[rewardIdx] += groupRewardData.minCount;
					DatabaseManager.GameProfile.UpdatePartData(SessionId, user.Inventory.partData);
					result.partData = user.Inventory.partData;
					break;

                case ERewardType.Box:
                    if (!user.Inventory.itemData.TryAdd(rewardIdx, groupRewardData.minCount))
						user.Inventory.itemData[rewardIdx] += groupRewardData.minCount;
					DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
					result.itemData = user.Inventory.itemData;
                    break;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(result),
            };

			return response;
        }
    }

    public class GetGroupRewardRequest
    {
        [JsonProperty("giIdx")]
        public int giIdx { get; set; }
    }
}

/*	// Token: 0x060060E8 RID: 24808 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3510", true, true)]
	public void GetGroupReward(int giIdx)
	{
	}

	// Token: 0x060060E9 RID: 24809 RVA: 0x001B0ED4 File Offset: 0x001AF0D4
	private IEnumerator GetGroupRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "giIdx");
		this.localUser.AddGroupCompleteData(int.Parse(text));
		if (result.commander !=null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commander)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(value.id);
				CommanderCompleteType commanderCompleteType = ((roCommander.state != ECommanderState.Nomal) ? CommanderCompleteType.Recruit : CommanderCompleteType.Transmission);
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete.Init(commanderCompleteType, value.id);
			}
		}
		else
		{
			string text2 = string.Empty;
			GroupInfoDataRow groupInfoDataRow = RemoteObjectManager.instance.RemoteObjectManager.instance.regulation.FindGroupInfoWhereGroupIdx(text);
			if (groupInfoDataRow !=null)
			{
				text2 = groupInfoDataRow.groupComment;
			}
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, text2);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		if (this.localUser.badgeGroupCount > 0)
		{
			this.localUser.badgeGroupCount--;
		}
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x060060EA RID: 24810 RVA: 0x001B0F00 File Offset: 0x001AF100
	private IEnumerator GetGroupRewardError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error code:" + code);
		yield break;
	}*/
