using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Host.Handlers.KeepAlives
{
    [Packet(Id = Method.GetCouponList)]
    public class GetCouponList : BaseMethodHandler<GetCouponListRequest>
    {
        public override object Handle(GetCouponListRequest @params)
        {
            CouponList couponList = new()
            {
                list = []
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = couponList
            };

            return response;
        }

        public class CouponList
        {
            [JsonProperty("list")]
            public List<string> list { get; set; }
        }
    }

    public class GetCouponListRequest
    {
    }
}