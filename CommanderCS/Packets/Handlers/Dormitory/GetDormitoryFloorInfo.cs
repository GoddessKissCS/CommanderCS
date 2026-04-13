using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Dormitory
{
    [Packet(Id = Method.GetDormitoryFloorInfo)]
    public class GetDormitoryFloorInfo : BaseMethodHandler<GetDormitoryFloorInfoRequest>
    {
        public override object Handle(GetDormitoryFloorInfoRequest request)
        {
            // Return floor info with a default constructed first floor
            Library.Protocols.Dormitory.FloorInfo floorInfo = new()
            {
                pointState = false,
                floors = new Dictionary<string, Library.Protocols.Dormitory.RoomInfo>
                {
                    ["1"] = new Library.Protocols.Dormitory.RoomInfo
                    {
                        fno = "1",
                        name = "Room 1",
                        state = "N",
                        commanders = [],
                        remain = 0,
                        commanderInfos = [],  
                    }
                },
                isMasterUser = false
            };


            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = floorInfo,
            };

            return response;
        }
    }

    public class GetDormitoryFloorInfoRequest
    {
    }
}

/*	// Token: 0x0600619E RID: 24990 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8601", true, true)]
	public void GetDormitoryFloorInfo()
	{
	}

	// Token: 0x0600619F RID: 24991 RVA: 0x001B1DF0 File Offset: 0x001AFFF0
	private IEnumerator GetDormitoryFloorInfoResult(JsonRpcClient.Request request, Protocols.Dormitory.FloorInfo result)
	{
		result.isMasterUser = true;
		UIPopup.Create<UIRoomList>("RoomList").Set(result);
		yield break;
	}*/