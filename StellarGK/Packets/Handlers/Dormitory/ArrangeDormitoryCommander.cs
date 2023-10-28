namespace StellarGK.Packets.Handlers.Dormitory
{
    public class ArrangeDormitoryCommander
    {
    }
}

/*	// Token: 0x060061BF RID: 25023 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8641", true, true)]
	public void ArrangeDormitoryCommander(string fno, string cid)
	{
	}

	// Token: 0x060061C0 RID: 25024 RVA: 0x001B2010 File Offset: 0x001B0210
	private IEnumerator ArrangeDormitoryCommanderResult(JsonRpcClient.Request request, string result, Dictionary<string, Protocols.Dormitory.CommanderInfo> dcom, Dictionary<string, Protocols.Dormitory.FloorCharacterInfo> fcm)
	{
		Dictionary<string, Protocols.Dormitory.CommanderInfo>.Enumerator enumerator = dcom.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Dictionary<string, RoCharacter> characters = SingletonMonoBehaviour<DormitoryData>.Instance.characters;
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair = enumerator.Current;
			RoCharacter roCharacter = characters[keyValuePair.Key];
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair2 = enumerator.Current;
			roCharacter.fno = keyValuePair2.Value.fno;
			string text = "Chr.Update.Floor";
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair3 = enumerator.Current;
			Message.Send<string>(text, keyValuePair3.Key);
		}
		Dictionary<string, Protocols.Dormitory.FloorCharacterInfo>.Enumerator enumerator2 = fcm.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Dictionary<string, RoCharacter> characters2 = SingletonMonoBehaviour<DormitoryData>.Instance.characters;
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair4 = enumerator.Current;
			RoCharacter roCharacter2 = characters2[keyValuePair4.Key];
			RoCharacter roCharacter3 = roCharacter2;
			KeyValuePair<string, Protocols.Dormitory.FloorCharacterInfo> keyValuePair5 = enumerator2.Current;
			roCharacter3.Set(keyValuePair5.Value);
			SingletonMonoBehaviour<DormitoryData>.Instance.room.AddCharacter(roCharacter2);
			Message.Send<RoCharacter>("Room.Add.Character", roCharacter2);
		}
		yield break;
	}
*/