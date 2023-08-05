using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.KeepAlives
{
    [Command(Id = CommandId.GetCouponList)]
    public class GetCouponList : BaseCommandHandler<GetCouponListRequest>
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

            response.id = BasePacket.Id;
            response.result = couponList;

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