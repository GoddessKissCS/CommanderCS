using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Carnival
{
    [Packet(Id = Method.CarnivalBuyPackage)]
    public class CarnivalBuyPackage : BaseMethodHandler<CarnivalBuyPackageRequest>
    {
        public override object Handle(CarnivalBuyPackageRequest request)
        {
            GameProfileScheme user = GetUserGameProfile();

            var resource = UserResources2Resource(user.Resources);

            CarnivalList result = new()
            {
                carnivalList = [],
                carnivalProcessList = [],
                rewardList = [],
                resource = resource,
                commanderData = user.CommanderData,
                partData = user.Inventory.partData,
                medalData = user.Inventory.medalData,
                eventResourceData = user.Inventory.eventResourceData,
                itemData = user.Inventory.itemData,
                costumeData = [],
                foodData = user.Inventory.foodData,
                groupItemData = user.Inventory.groupItemData,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(result),
            };

            return response;
        }
    }

    public class CarnivalBuyPackageRequest
    {
        [JsonProperty("ctid")]
        public int ctid { get; set; }

        [JsonProperty("cidx")]
        public int cidx { get; set; }
    }
}

/*	// Token: 0x060060C3 RID: 24771 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6243", true, true)]
	public void CarnivalBuyPackage(int ctid, int cidx)
	{
	}

	// Token: 0x060060C4 RID: 24772 RVA: 0x001B0BF8 File Offset: 0x001AEDF8
	private IEnumerator CarnivalBuyPackageResult(JsonRpcClient.Request request, Protocols.CarnivalList result)
	{
		if (result is not null)
		{
			string text = this._FindRequestProperty(request, "ctid");
			ECarnivalCategory categoryType = this.RemoteObjectManager.instance.regulation.carnivalTypeDtbl[text].categoryType;
			if (result.rewardList is not null)
			{
				UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
				SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			}
			if (result.commanderData is not null)
			{
				string[] array = new string[result.commanderData.Count];
				result.commanderData.Keys.CopyTo(array, 0);
				RoCommander roCommander = this.localUser.FindCommander(array[0]);
				if (roCommander is not null)
				{
					UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
					if (uicommanderComplete is not null)
					{
						if (roCommander.state != ECommanderState.Nomal)
						{
							uicommanderComplete.Init(CommanderCompleteType.Recruit, roCommander.id);
						}
						else
						{
							uicommanderComplete.Init(CommanderCompleteType.Transmission, roCommander.id);
						}
					}
				}
			}
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.RefreshPartFromNetwork(result.partData);
			this.localUser.RefreshItemFromNetwork(result.eventResourceData);
			this.localUser.RefreshItemFromNetwork(result.itemData);
			this.localUser.RefreshMedalFromNetwork(result.medalData);
			this.localUser.AddCommanderFromNetwork(result.commanderData);
			this.localUser.RefreshCarnivalFromNetwork(result.carnivalProcessList);
			this.localUser.RefreshCostumeFromNetwork(result.costumeData);
			this.localUser.RefreshItemFromNetwork(result.foodData);
			this.localUser.RefreshUserEquipItemFromNetwork(result.equipItemData);
			this.localUser.RefreshItemFromNetwork(result.groupItemData);
			this.localUser.badgeCarnivalComplete[(int)categoryType] = this.localUser.badgeCarnival(categoryType);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/
