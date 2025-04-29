using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Packets.Structure;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapReward)]
    public class WorldMapReward : BaseMethodHandler<WorldMapRewardRequest>
    {
        public override object Handle(WorldMapRewardRequest @params)
        {
#warning TODO: REVAMP THIS FUNCTION

            string commanderId = "0";
            int medalsCommander = 0;

            switch (@params.world)
            {
                case 0:
                    commanderId = "5";
                    medalsCommander = 10;
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

            var worldmap = UserWorldReward(commanderId, User, SessionId);

            DatabaseManager.GameProfile.UpdateWorldMapReward(SessionId, @params.world, User.BattleData.WorldMapStageReward);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = worldmap
            };

            return response;
        }

        private static CommanderCS.Library.Protocols.WorldMapReward UserWorldReward(string commanderId, GameProfileScheme user, string session)
        {
            int medals = 20;

            CommanderCS.Library.Protocols.WorldMapReward WorldMapReward = new();

            user.CommanderData.TryGetValue(commanderId, out var commander);

            if (commander is null)
            {
                int cid = int.Parse(commanderId);

                var commanderdata = RemoteObjectManager.instance.regulation.AddSpecificCommander(user.CommanderData, cid);

                WorldMapReward.commanderData = commanderdata;
            }
            else
            {
                user.Inventory.medalData[commanderId] += medals;
                user.CommanderData[commanderId].medl += medals;

                WorldMapReward.commanderData = user.CommanderData;
            }

            WorldMapReward.medalData = user.Inventory.medalData;

            DatabaseManager.GameProfile.UpdateCommanderDataAndMedalData(session, WorldMapReward.commanderData, WorldMapReward.medalData);

            return WorldMapReward;
        }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2209", true, true)]
	public void WorldMapReward(int world)
	{
	}

	// Token: 0x06005F55 RID: 24405 RVA: 0x001AEDCC File Offset: 0x001ACFCC
	private IEnumerator WorldMapRewardResult(JsonRpcClient.Request request, Protocols.WorldMapReward result)
	{
		if (result.commanderData is not null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderData)
			{
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				CommanderCompleteType commanderCompleteType = ((roCommander.state == ECommanderState.Nomal) ? CommanderCompleteType.Transmission : CommanderCompleteType.WorldMapReward);
				roCommander.state = ECommanderState.Nomal;
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete.Init(commanderCompleteType, roCommander.id);
				if (keyValuePair.Value.haveCostume is not null && keyValuePair.Value.haveCostume.Count > 0)
				{
					roCommander.haveCostumeList = keyValuePair.Value.haveCostume;
				}
			}
			UIManager.instance.world.worldMap.currentWorldMap.rwd = true;
		}
		if (result.medalData is not null)
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