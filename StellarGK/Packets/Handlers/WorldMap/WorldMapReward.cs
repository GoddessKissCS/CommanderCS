using StellarGK.Host;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.WorldMap
{
	[Packet(Id = Method.WorldMapReward)]
    public class WorldMapReward : BaseMethodHandler<WorldMapRewardRequest>
    {

        public override object Handle(WorldMapRewardRequest @params)
        {

			// Check all Pilots that exist
			int commanderId;

			switch (@params.world)
			{
				case 0:
					break;
				case 1:
                    break;
				case 2: 
					break;
				case 3: 
					break;
				case 4:
                    break;
				case 5:
                    break;
				case 6:
					break;
				case 7:
					break;
				case 8:
					break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
            }


			Logic.Protocols.WorldMapReward worldMap = new()
			{
				
			};

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
				Result = worldMap
            };


            return response;
        }

    }

    public class WorldMapRewardRequest
    {
        [JsonPropertyName("world")]
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