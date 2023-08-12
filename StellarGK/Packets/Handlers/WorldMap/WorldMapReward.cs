using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.WorldMap
{
    public class WorldMapReward
    {
        
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