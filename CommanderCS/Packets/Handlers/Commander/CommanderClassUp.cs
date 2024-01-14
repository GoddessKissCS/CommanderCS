using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Commander
{
	[Packet(Id = Method.CommanderClassUp)]
    public class CommanderClassUp : BaseMethodHandler<CommanderClassUpRequest>
    {
        public override object Handle(CommanderClassUpRequest @params)
        {
            var user = GetUserGameProfile();
            var rg = GetRegulation();
			var session = GetSession();

            string cid = @params.cid.ToString();

            user.CommanderData.TryGetValue(cid, out var commander);

            var classUpInfo = rg.classUpDtbl.Find(x => x.ROLE == commander.role && x.GRADE == commander.__cls);

            switch (classUpInfo.GRADE)
            {
                case "1":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "2";
                    break;
                case "2":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "3";
                    break;
                case "3":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "4";
                    break;
                case "4":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "5";
                    break;
                case "5":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "6";
                    break;
                case "6":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "7";
                    break;
                case "7":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "8";
                    break;
                case "8":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "9";
                    break;
                case "9":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "10";
                    break;
                case "10":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "11";
                    break;
                case "11":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "12";
                    break;
                case "12":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "13";
                    break;
                case "13":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "14";
                    break;
                case "14":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "15";
                    break;
                case "15":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "16";
                    break;
                case "16":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "17";
                    break;
                case "17":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "18";
                    break;
                case "18":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "19";
                    break;
                case "19":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "20";
                    break;
                case "20":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "21";
                    break;
                case "21":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "22";
                    break;
                case "22":
                    user.UserInventory.partData[classUpInfo.CPU_ID] -= classUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[classUpInfo.ATK_ID] -= classUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[classUpInfo.DEF_ID] -= classUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[classUpInfo.SUP_ID] -= classUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[classUpInfo.MOTORBLOCK_ID] -= classUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[classUpInfo.PLATE_ID] -= classUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "23";
                    break;
            }


            user.UserResources.gold -= classUpInfo.UPGRADE_COST;

            DatabaseManager.GameProfile.UpdatePartData(session, user.UserInventory.partData);
            DatabaseManager.GameProfile.UpdateGold(session, classUpInfo.UPGRADE_COST, false);
            DatabaseManager.GameProfile.UpdateCommanderData(session, user.CommanderData);


            var goods = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
            var battlestats = DatabaseManager.GameProfile.UserStatistics2BattleStatistics(user.UserStatistics);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);



            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notifaction,

                foodData = user.UserInventory.foodData,
                eventResourceData = user.UserInventory.eventResourceData,
                groupItemData = user.UserInventory.groupItemData,
                itemData = user.UserInventory.itemData,
                medalData = user.UserInventory.medalData,
                partData = user.UserInventory.partData,

                resetRemain = user.ResetDateTime, // should be set?
                /// pronabably set it globally?
                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse
            };

            return response;
        }


    }


    public class CommanderClassUpRequest
	{
		[JsonProperty("cid")]
		public int cid { get; set; }
	}
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4304", true, true)]
	public void CommanderClassUp(int cid)
	{
	}

	// Token: 0x06005F35 RID: 24373 RVA: 0x001AE9A8 File Offset: 0x001ACBA8
	private IEnumerator CommanderClassUpResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result.goodsInfo != null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		}
		if (result.partData != null)
		{
			this.localUser.RefreshPartFromNetwork(result.partData);
		}
		if (result.commanderInfo != null)
		{
			SoundManager.PlaySFX("SE_Upgrade_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderInfo)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				roCommander.cls = keyValuePair.Value.cls;
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete.Init(CommanderCompleteType.ClassUp, roCommander.id);
				RoUnit roUnit = this.localUser.FindUnit(roCommander.unitId);
				roUnit.cls = value.cls;
				roUnit.level = roCommander.level;
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/