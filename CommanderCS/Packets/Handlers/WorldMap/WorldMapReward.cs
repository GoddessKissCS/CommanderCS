using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCS.Host;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapReward)]
    public class WorldMapReward : BaseMethodHandler<WorldMapRewardRequest>
    {
        public override object Handle(WorldMapRewardRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();

            string commanderId = GetCommanderIdForWorld(@params.world);

            var worldmap = UserWorldReward(commanderId, user, session);

            DatabaseManager.GameProfile.UpdateWorldMapReward(session, @params.world, user.BattleData.WorldMapStageReward);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = worldmap
            };

            return response;
        }

        private static string GetCommanderIdForWorld(int world)
        {
            switch (world)
            {
                case 0:
                    return "5";
                case 1:
                    return "26";
                case 2:
                    return "14";
                case 3:
                    return "19";
                case 4:
                    return "15";
                case 5:
                    return "12";
                case 6:
                    return "27";
                case 7:
                    return "10";
                case 8:
                    return "20";
                case 9:
                    return "30";
                case 10:
                    return "616";
                case 11:
                    return "47";
                case 12:
                    return "50";
                case 13:
                    return "51";
                case 14:
                    return "48";
                case 15:
                    return "62";
                case 16:
                    return "75";
                case 17:
                    return "85";
                case 18:
                    return "92";
                default:
                    return string.Empty;
            }
        }
        private static CommanderCSLibrary.Shared.Protocols.WorldMapReward UserWorldReward(string commanderId, GameProfileScheme user, string session)
        {
            int medals = 20;

            CommanderCSLibrary.Shared.Protocols.WorldMapReward WorldMapReward = new();

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

                var commanderdata = Constants.regulation.AddSpecificCommander(user.CommanderData, cid);

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