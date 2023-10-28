namespace StellarGK.Packets.Handlers.Dormitory
{
    public class ChangeDormitoryWallpaper
    {
    }
}

/*	// Token: 0x060061B4 RID: 25012 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8621", true, true)]
	public void ChangeDormitoryWallpaper(string fno, string idx)
	{
	}

	// Token: 0x060061B5 RID: 25013 RVA: 0x001B1F68 File Offset: 0x001B0168
	private IEnumerator ChangeDormitoryWallpaperResult(JsonRpcClient.Request request, Protocols.Dormitory.ChangeWallpaperResponse result)
	{
		SingletonMonoBehaviour<DormitoryData>.Instance.room.wallpaper = result.id;
		SingletonMonoBehaviour<DormitoryData>.Instance.inventory.UpdateData(EDormitoryItemType.Wallpaper, result.invenWallpaper);
		Message.Send("Inven.Update");
		Message.Send("Room.Update.WallPaper");
		yield break;
	}

	// Token: 0x060061B6 RID: 25014 RVA: 0x001B1F84 File Offset: 0x001B0184
	private IEnumerator ChangeDormitoryWallpaperError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 85111)
		{
		}
		yield break;
	}*/