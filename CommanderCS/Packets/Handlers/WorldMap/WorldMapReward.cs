using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
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

#warning TODO: REVAMP THIS FUNCTION
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
            return world switch
            {
                0 => "5",
                1 => "26",
                2 => "14",
                3 => "19",
                4 => "15",
                5 => "12",
                6 => "27",
                7 => "10",
                8 => "20",
                9 => "30",
                10 => "616",
                11 => "47",
                12 => "50",
                13 => "51",
                14 => "48",
                15 => "62",
                16 => "75",
                17 => "85",
                18 => "92",
                _ => string.Empty,
            };
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