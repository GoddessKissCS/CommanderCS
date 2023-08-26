using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.KeepAlives
{
    [Packet(Id = MethodId.GetCouponList)]
    public class GetCouponList : BaseMethodHandler<GetCouponListRequest>
    {
        public override object Handle(GetCouponListRequest @params)
        {

            ResponsePacket response = new();
            CouponList couponList = new();
            List<string> coupons = new()
            {
                "test",
            };

            couponList.list = coupons;

            response.Id = BasePacket.Id;
            response.Result = couponList;

            return response;
        }


        public class CouponList
        {
            [JsonPropertyName("list")]
            public List<string> list { get; set; }
        }
    }
    public class GetCouponListRequest
    {

    }
}