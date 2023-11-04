using StellarGK.Host;

namespace StellarGK.Packets.Handlers.System
{
    //[Packet(Id = Method.GetRegion)]
    public class SystemMessage : BaseMethodHandler<SystemRequest>
    {
        public override object Handle(SystemRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = "system",
            };

            return response;
        }
    }
    public class SystemRequest {
    }
}
