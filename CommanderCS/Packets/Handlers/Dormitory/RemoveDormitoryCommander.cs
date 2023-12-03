namespace CommanderCS.Packets.Handlers.Dormitory
{
    public class RemoveDormitoryCommander
    {
    }
}

/*	// Token: 0x060061C1 RID: 25025 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8642", true, true)]
	public void RemoveDormitoryCommander(string cid)
	{
	}

	// Token: 0x060061C2 RID: 25026 RVA: 0x001B2034 File Offset: 0x001B0234
	private IEnumerator RemoveDormitoryCommanderResult(JsonRpcClient.Request request, string result, Dictionary<string, Protocols.Dormitory.CommanderInfo> dcom)
	{
		Dictionary<string, Protocols.Dormitory.CommanderInfo>.Enumerator enumerator = dcom.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Dictionary<string, RoCharacter> characters = SingletonMonoBehaviour<DormitoryData>.Instance.characters;
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair = enumerator.Current;
			RoCharacter roCharacter = characters[keyValuePair.Key];
			RoCharacter roCharacter2 = roCharacter;
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair2 = enumerator.Current;
			roCharacter2.fno = keyValuePair2.Value.fno;
			string text = "Chr.Update.Floor";
			KeyValuePair<string, Protocols.Dormitory.CommanderInfo> keyValuePair3 = enumerator.Current;
			Message.Send<string>(text, keyValuePair3.Key);
			if (SingletonMonoBehaviour<DormitoryData>.Instance.room.ContainsCharacter(roCharacter.id))
			{
				SingletonMonoBehaviour<DormitoryData>.Instance.room.RemoveCharacter(roCharacter.id);
				Message.Send<string>("Room.Remove.Character", roCharacter.id);
			}
		}
		yield break;
	}

	// Token: 0x060061C3 RID: 25027 RVA: 0x001B2050 File Offset: 0x001B0250
	private IEnumerator RemoveDormitoryCommanderError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 85144)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81031"));
		}
		yield break;
	}*/