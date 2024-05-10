using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.CommanderClassUp)]
    public class CommanderClassUp : BaseMethodHandler<CommanderClassUpRequest>
    {
        public override object Handle(CommanderClassUpRequest @params)
        {
            string cid = @params.commanderId.ToString();

            User.CommanderData.TryGetValue(cid, out var commander);

            var commanderClassUpInfo = Regulation.commanderClassUpDtbl.Find(x => x.ROLE == commander.role && x.GRADE == commander.__cls);

            switch (commanderClassUpInfo.GRADE)
            {
                case "1":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "2";
                    break;

                case "2":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "3";
                    break;

                case "3":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "4";
                    break;

                case "4":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "5";
                    break;

                case "5":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "6";
                    break;

                case "6":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "7";
                    break;

                case "7":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "8";
                    break;

                case "8":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "9";
                    break;

                case "9":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "10";
                    break;

                case "10":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "11";
                    break;

                case "11":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "12";
                    break;

                case "12":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "13";
                    break;

                case "13":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "14";
                    break;

                case "14":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "15";
                    break;

                case "15":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "16";
                    break;

                case "16":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "17";
                    break;

                case "17":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "18";
                    break;

                case "18":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "19";
                    break;

                case "19":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.CommanderData[cid].__cls = "20";
                    break;

                case "20":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.CommanderData[cid].__cls = "21";
                    break;

                case "21":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "22";
                    break;

                case "22":
                    user.UserInventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    user.UserInventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    user.CommanderData[cid].__cls = "23";
                    break;
            }

            User.UserResources.gold -= commanderClassUpInfo.UPGRADE_COST;

            DatabaseManager.GameProfile.UpdatePartData(Session, User.UserInventory.partData);
            DatabaseManager.GameProfile.UpdateGold(Session, commanderClassUpInfo.UPGRADE_COST, false);
            DatabaseManager.GameProfile.UpdateCommanderData(Session, User.CommanderData);


            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = GetUserInformationResponse(User),
            };

            return response;
        }
    }

    public class CommanderClassUpRequest
    {
        [JsonProperty("cid")]
        public int commanderId { get; set; }
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