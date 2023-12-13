using CommanderCS.Database;
using CommanderCS.Database.Schemes;
using CommanderCS.ExcelReader;
using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapReward)]
    public class WorldMapReward : BaseMethodHandler<WorldMapRewardRequest>
    {
        public override object Handle(WorldMapRewardRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();

            string commanderId = string.Empty;

            switch (@params.world)
            {
                case 0:
                    commanderId = "5";
                    break;

                case 1:
                    commanderId = "26";
                    break;

                case 2:
                    commanderId = "14";
                    break;

                case 3:
                    commanderId = "19";
                    break;

                case 4:
                    commanderId = "15";
                    break;

                case 5:
                    commanderId = "12";
                    break;

                case 6:
                    commanderId = "27";
                    break;

                case 7:
                    commanderId = "10";
                    break;

                case 8:
                    commanderId = "20";
                    break;

                case 9:
                    commanderId = "30";
                    break;

                case 10:
                    commanderId = "616";
                    break;

                case 11:
                    commanderId = "47";
                    break;

                case 12:
                    commanderId = "50";
                    break;

                case 13:
                    commanderId = "51";
                    break;

                case 14:
                    commanderId = "48";
                    break;

                case 15:
                    commanderId = "62";
                    break;

                case 16:
                    commanderId = "75";
                    break;

                case 17:
                    commanderId = "85";
                    break;

                case 18:
                    commanderId = "92";
                    break;
            }

            var worldmap = UserWorldReward(commanderId, user, session);

            DatabaseManager.GameProfile.UpdateWorldMapReward(session, @params.world, user.BattleData.WorldMapStageReward);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = worldmap
            };

            return response;
        }

        public static Protocols.WorldMapReward UserWorldReward(string commanderId, GameProfileScheme user, string session)
        {
            int medals = 20;

            Protocols.WorldMapReward WorldMapReward = new();

            user.CommanderData.TryGetValue(commanderId, out var commander);

            if (commander != null)
            {
                user.UserInventory.medalData[commanderId] += medals;
                user.CommanderData[commanderId].medl += medals;

                WorldMapReward.commanderData = user.CommanderData;
            }
            else
            {
                int cid = int.Parse(commanderId);

                var commanderdata = CommanderCostumeData.GetInstance().AddSpecificCommander(user.CommanderData, cid);

                WorldMapReward.commanderData = commanderdata;
            }

            WorldMapReward.medalData = user.UserInventory.medalData;

            DatabaseManager.GameProfile.UpdateCommanderDataAndMedalData(session, WorldMapReward.commanderData, WorldMapReward.medalData);

            return WorldMapReward;
        }
    }

    public class WorldMapRewardRequest
    {
        [JsonProperty("world")]
        public int world { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2209", true, true)]
	public void WorldMapReward(int world)
	{
	}

	// Token: 0x06005F55 RID: 24405 RVA: 0x001AEDCC File Offset: 0x001ACFCC
	private IEnumerator WorldMapRewardResult(JsonRpcClient.Request request, Protocols.WorldMapReward result)
	{
		if (result.commanderData != null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderData)
			{
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				CommanderCompleteType commanderCompleteType = ((roCommander.state == ECommanderState.Nomal) ? CommanderCompleteType.Transmission : CommanderCompleteType.WorldMapReward);
				roCommander.state = ECommanderState.Nomal;
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete.Init(commanderCompleteType, roCommander.id);
				if (keyValuePair.Value.haveCostume != null && keyValuePair.Value.haveCostume.Count > 0)
				{
					roCommander.haveCostumeList = keyValuePair.Value.haveCostume;
				}
			}
			UIManager.instance.world.worldMap.currentWorldMap.rwd = true;
		}
		if (result.medalData != null)
		{
			foreach (KeyValuePair<string, int> keyValuePair2 in result.medalData)
			{
				RoCommander roCommander2 = this.localUser.FindCommander(keyValuePair2.Key);
				CommanderCompleteType commanderCompleteType2 = ((roCommander2.state == ECommanderState.Nomal) ? CommanderCompleteType.Transmission : CommanderCompleteType.WorldMapReward);
				roCommander2.state = ECommanderState.Nomal;
				roCommander2.aMedal = keyValuePair2.Value;
				UICommanderComplete uicommanderComplete2 = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete2.Init(commanderCompleteType2, roCommander2.id);
			}
			UIManager.instance.world.worldMap.currentWorldMap.rwd = true;
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/