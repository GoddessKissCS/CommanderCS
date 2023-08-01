using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Host.Handlers.Nickname;

namespace StellarGK.Host.Handlers.Event
{
    [Command(Id = CommandId.GetPlugEventInfo)]
    public class GetPlugEventInfo : BaseCommandHandler<GetPlugEventInfoRequest>
    {
        public override string Handle(GetPlugEventInfoRequest @params)
        {
            ResponsePacket response = new();

            GetPlugEventInfoPacket plugEventInfo = new();


            plugEventInfo.cmt = new List<int>() { };
            plugEventInfo.pst = new List<int>() { };

            response.id = BasePacket.Id;
            response.result = plugEventInfo;

            return JsonConvert.SerializeObject(response);
        }

        public class GetPlugEventInfoPacket
        {
            public List<int> pst { get; set; }

            public List<int> cmt { get; set; }
        }
    }

    public class GetPlugEventInfoRequest
    {

    }
}