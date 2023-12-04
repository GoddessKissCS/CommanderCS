using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Annihilation
{
    [Packet(Id = Method.AnnihilationEnemyInformation)]
    public class AnnihilationEnemyInformation : BaseMethodHandler<AnnihilationEnemyInformationRequest>
    {
        public override object Handle(AnnihilationEnemyInformationRequest @params)
        {
            return "{}";
        }
    }

    public class AnnihilationEnemyInformationRequest
    {
        [JsonProperty("stage")]
        public int stage { get; set; }
    }
}

/*	// Token: 0x06006019 RID: 24601 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7306", true, true)]
	public void AnnihilationEnemyInformation(int stage)
	{
	}

	// Token: 0x0600601A RID: 24602 RVA: 0x001AFDD4 File Offset: 0x001ADFD4
	private IEnumerator AnnihilationEnemyInformationResult(JsonRpcClient.Request request, Protocols.ScrambleStageInfo result)
	{
		if (result == null)
		{
			yield break;
		}
		string text = this._FindRequestProperty(request, "stage");
		RoTroop roTroop = this.localUser.FindScrambleTroop();
		roTroop.UpdateScrambleTroop(result.myDeck);
		RoUser roUser = RoUser.CreateDummyUser(result.enemy.id, result.enemy.nickname, result.enemy.id);
		RoUser roUser2 = RemoteObjectManager.instance.localUser.CreateForBattle(roTroop.id);
		BattleData battleData = BattleData.Create(EBattleType.GuildScramble);
		battleData.defender = roUser;
		battleData.attacker = roUser2;
		battleData.stageId = text;
		UIManager.instance.world.readyBattle.InitAndOpenReadyBattle(battleData);
		if (result.user != null)
		{
			UIManager.instance.world.readyBattle.duel.SetProgressingBattle(result.user);
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/