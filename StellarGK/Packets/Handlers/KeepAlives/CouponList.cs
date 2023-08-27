using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.KeepAlives
{
    [Packet(Id = Method.GetCouponList)]
    public class GetCouponList : BaseMethodHandler<GetCouponListRequest>
    {
        public override object Handle(GetCouponListRequest @params)
        {
            CouponList couponList = new();
            List<string> coupons = new()
            {

            };

            couponList.list = coupons;

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = couponList
            };

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