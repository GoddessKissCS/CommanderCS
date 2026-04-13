using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Dormitory
{
    [Packet(Id = Method.GetDormitoryFloorDetailInfo)]
    public class GetDormitoryFloorDetailInfo : BaseMethodHandler<GetDormitoryFloorDetailInfoRequest>
    {
        public override object Handle(GetDormitoryFloorDetailInfoRequest request)
        {
            Library.Protocols.Dormitory.FloorDetailInfo floorDetailInfo = new()
            {
                fno = request.fno,
                name = "Room " + request.fno,
                wallpaperId = "1",
                decos = [],
                characters = [],
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = floorDetailInfo,
            };

            return response;
        }
    }

    public class GetDormitoryFloorDetailInfoRequest
    {
        [JsonProperty("fno")]
        public string fno { get; set; }
    }
}

/*	// Token: 0x060061A6 RID: 24998 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8620", true, true)]
	public void GetDormitoryFloorDetailInfo(string fno)
	{
	}

	// Token: 0x060061A7 RID: 24999 RVA: 0x001B1E70 File Offset: 0x001B0070
	private IEnumerator GetDormitoryFloorDetailInfoResult(JsonRpcClient.Request request, Protocols.Dormitory.FloorDetailInfo result)
	{
		DormitoryInitData.Instance.Set(result);
		Loading.Load(Loading.Dormitory);
		yield break;
	}*/