using Amazon.Runtime.Internal.Transform;
using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation.DataRows;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.CommanderClassUp)]
    public class CommanderClassUp : BaseMethodHandler<CommanderClassUpRequest>
    {
        public override object Handle(CommanderClassUpRequest @params)
        {
            var User = GetUserGameProfile();
            var Account = GetUserAccount();

            string cid = @params.commanderId.ToString();

            User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander);

            CommanderClassUpDataRow commanderClassUpInfo = RemoteObjectManager.instance.regulation.commanderClassUpDtbl.Find(x => x.ROLE == commander.role && x.GRADE == commander.__cls);

            if (User.Inventory.partData.Count > 0 || Account.Clearance >= Clearance.Moderator )
            {
                User.Inventory.partData.Add("" + commanderClassUpInfo.CPU_ID, commanderClassUpInfo.CPU_AMOUNT);
                User.Inventory.partData.Add("" + commanderClassUpInfo.ATK_ID, commanderClassUpInfo.ATK_AMOUNT);
                User.Inventory.partData.Add("" + commanderClassUpInfo.DEF_ID, commanderClassUpInfo.DEF_AMOUNT);
                User.Inventory.partData.Add("" + commanderClassUpInfo.SUP_ID, commanderClassUpInfo.SUP_AMOUNT);
                if(commanderClassUpInfo.MOTORBLOCK_ID != "")
                {
                    User.Inventory.partData.Add("" + commanderClassUpInfo.MOTORBLOCK_ID, commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT);
                }
                if (commanderClassUpInfo.PLATE_ID != "")
                {
                    User.Inventory.partData.Add("" + commanderClassUpInfo.PLATE_ID, commanderClassUpInfo.PLATE_AMOUNT);
                }
            }

            //i just assume if we go through this method we have the parts and gold needed
            //to upgrade and dont spit out errors

            int grade = int.Parse(commanderClassUpInfo.GRADE) + 1;
            string gradeStr = grade.ToString();

            switch (commanderClassUpInfo.GRADE)
            {
                case "1":
                case "2":
                case "5":
                case "9":
                case "14":
                case "19":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.CommanderData[cid].__cls = gradeStr;
                    break;

                case "3":
                case "4":
                case "6":
                case "10":
                case "15":
                case "11":
                case "20":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.CommanderData[cid].__cls = gradeStr;
                    break;

                case "7":
                case "8":
                case "12":
                case "13":
                case "16":
                case "18":
                case "21":
                case "22":
                    User.Inventory.partData[commanderClassUpInfo.CPU_ID] -= commanderClassUpInfo.CPU_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.ATK_ID] -= commanderClassUpInfo.ATK_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.DEF_ID] -= commanderClassUpInfo.DEF_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.SUP_ID] -= commanderClassUpInfo.SUP_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.MOTORBLOCK_ID] -= commanderClassUpInfo.MOTORBLOCK_ID_AMOUNT;
                    User.Inventory.partData[commanderClassUpInfo.PLATE_ID] -= commanderClassUpInfo.PLATE_AMOUNT;
                    User.CommanderData[cid].__cls = gradeStr;
                    break;

            }

            User.Resources.gold -= commanderClassUpInfo.UPGRADE_COST;

            DatabaseManager.GameProfile.UpdatePartData(SessionId, User.Inventory.partData);
            DatabaseManager.GameProfile.UpdateGold(SessionId, commanderClassUpInfo.UPGRADE_COST, false);
            DatabaseManager.GameProfile.UpdateSpecificCommander(SessionId, User.CommanderData[cid]);

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