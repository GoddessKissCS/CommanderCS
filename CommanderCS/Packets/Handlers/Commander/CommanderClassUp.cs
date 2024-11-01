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
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = "2";
                    break;

                case "2":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = "3";
                    break;

                case "3":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "4";
                    break;

                case "4":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "5";
                    break;

                case "5":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = "6";
                    break;

                case "6":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "7";
                    break;

                case "7":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "8";
                    break;

                case "8":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "9";
                    break;

                case "9":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = "10";
                    break;

                case "10":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "11";
                    break;

                case "11":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "12";
                    break;

                case "12":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "13";
                    break;

                case "13":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "14";
                    break;

                case "14":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = "15";
                    break;

                case "15":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "16";
                    break;

                case "16":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "17";
                    break;

                case "17":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "18";
                    break;

                case "18":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "19";
                    break;

                case "19":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = "20";
                    break;

                case "20":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = "21";
                    break;

                case "21":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "22";
                    break;

                case "22":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = "23";
                    break;
            }

            User.Resources.gold -= commanderClassUpInfo.UPGRADE_COST;

            DatabaseManager.GameProfile.UpdatePartData(SessionId, User.Inventory.partData);
            DatabaseManager.GameProfile.UpdateGold(SessionId, commanderClassUpInfo.UPGRADE_COST, false);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);


            var userInformation = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformation,
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
		if (result.goodsInfo is not null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		}
		if (result.partData is not null)
		{
			this.localUser.RefreshPartFromNetwork(result.partData);
		}
		if (result.commanderInfo is not null)
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