namespace CommanderCS.Packets.Handlers.WorldDuel
{
    public class WorldDuelEnemyInfo
    {
    }

    public class WorldDuelEnemyInfoRequest
    {
    }
}

/*	// Token: 0x0600615A RID: 24922 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3606", true, true)]
	public void WorldDuelEnemyInfo()
	{
	}

	// Token: 0x0600615B RID: 24923 RVA: 0x001B185C File Offset: 0x001AFA5C
	private IEnumerator WorldDuelEnemyInfoResult(JsonRpcClient.Request request, Protocols.PvPDuelList.PvPDuelData result)
	{
		if (result != null)
		{
			this.localUser.worldDuelTarget = RoUser.CreateDuelListUser(EBattleType.WorldDuel, result);
			UIManager.instance.world.rankingBattle.OpenWorldDuelReadyBattle();
		}
		yield break;
	}

	// Token: 0x0600615C RID: 24924 RVA: 0x001B1880 File Offset: 0x001AFA80
	private IEnumerator WorldDuelEnemyInfoError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/