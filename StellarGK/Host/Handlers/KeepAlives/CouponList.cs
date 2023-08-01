using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.KeepAlives
{
    [Command(Id = CommandId.GetCouponList)]
    public class GetCouponList : BaseCommandHandler<GetCouponListRequest>
    {
        public override string Handle(GetCouponListRequest @params)
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

            return JsonConvert.SerializeObject(response);
        }


        public class CouponList
        {
            public List<string> list { get; set; }
        }
    }
    public class GetCouponListRequest
    {

    }
}