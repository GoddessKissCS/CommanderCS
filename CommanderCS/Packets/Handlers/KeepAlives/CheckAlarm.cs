using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.CheckAlarm)]
    public class CheckAlarm : BaseMethodHandler<CheckAlarmRequest>
    {
        public override object Handle(CheckAlarmRequest @params)
        {
            AlarmData AlarmData = new();

            //Probably useless but still needs to adjusted if it actually does something

            ResponsePacket response = new ResponsePacket()
            {
                Id = BasePacket.Id,
                Result = AlarmData,
            };

            return response;
        }
    }

    public class CheckAlarmRequest
    {
    }
}

/*	// Token: 0x06006001 RID: 24577 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1505", true, true)]
	public void CheckAlarm()
	{
	}

	// Token: 0x06006002 RID: 24578 RVA: 0x001AFBE0 File Offset: 0x001ADDE0
	private IEnumerator CheckAlarmResult(JsonRpcClient.Request request, Protocols.AlarmData result)
	{
		this.localUser.alarmData = result;
		UIManager.instance.world.alarm.InitAndOpenAlarm();
		yield break;
	}*/