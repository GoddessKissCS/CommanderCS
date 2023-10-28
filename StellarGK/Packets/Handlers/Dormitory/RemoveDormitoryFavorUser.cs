namespace StellarGK.Packets.Handlers.Dormitory
{
    public class RemoveDormitoryFavorUser
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8662", true, true)]
	public void RemoveDormitoryFavorUser(string tuno)
	{
	}

	// Token: 0x060061D8 RID: 25048 RVA: 0x001B21C0 File Offset: 0x001B03C0
	private IEnumerator RemoveDormitoryFavorUserResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "tuno");
		if (SingletonMonoBehaviour<DormitoryData>.Instance.user.uno == text)
		{
			SingletonMonoBehaviour<DormitoryData>.Instance.favorState = false;
			Message.Send("User.Update.FavorState");
		}
		Message.Send<string>("Favor.Remove", text);
		yield break;
	}*/