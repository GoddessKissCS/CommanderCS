using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Dispatch
{
    public class ExplorationCompleteAll
    {
        
    }
}
/*	// Token: 0x060060FD RID: 24829 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3551", true, true)]
	public void ExplorationCompleteAll(List<int> idxs)
	{
	}

	// Token: 0x060060FE RID: 24830 RVA: 0x001B1088 File Offset: 0x001AF288
	private IEnumerator ExplorationCompleteAllResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		List<int> idxs = JsonConvert.DeserializeObject<List<int>>(this._FindRequestProperty(request, "idxs"));
		if (idxs != null)
		{
			int i;
			for (i = 0; i < idxs.Count; i++)
			{
				ExplorationDataRow explorationDataRow = this.regulation.explorationDtbl[idxs[i].ToString()];
				string worldMap = explorationDataRow.worldMap;
				int num = 0;
				if (result.explorationExp != null)
				{
					int num2 = result.explorationExp.FindIndex((Protocols.RewardInfo.ExplorationExp x) => x.idx == idxs[i]);
					if (num2 >= 0)
					{
						num = result.explorationExp[num2].exp;
					}
				}
				int num3 = this.regulation.commanderLevelDtbl[(this.localUser.level + 1).ToString()].aexp - 1;
				RoExploration roExploration = this.localUser.explorationDtbl[worldMap];
				for (int j = 0; j < roExploration.commanders.Count; j++)
				{
					int num4 = roExploration.commanders[j].aExp + num;
					if (num4 > num3)
					{
						num4 = num3;
					}
					roExploration.commanders[j].aExp = num4;
				}
				roExploration.Set(null);
				UIExplorationPopup.UIRefresh(worldMap);
			}
		}
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/