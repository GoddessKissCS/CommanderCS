using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Command(Id = CommandId.GetVipBuyCount)]
    public class GetVipBuyCount : BaseCommandHandler<GetVipBuyCountRequest>
    {
        public override object Handle(GetVipBuyCountRequest @params)
        {

            //gets send EVipRechargeType enum + ["rchg"]

            ResponsePacket response = new();
            GetVIPBuyCountInv VIP = new();

            List<UserInformationResponse.VipRechargeData> rchg = new();
            /*
            rchg.Add(new UserInformationResponse.VipRechargeData()
            {
                count = 1,
                mid = 1,
                idx = 101,
            });
            */
            VIP.rchg = rchg;


            response.id = BasePacket.Id;
            response.result = VIP;

            return response;
        }

        public class GetVIPBuyCountInv
        {
            public List<UserInformationResponse.VipRechargeData> rchg { get; set; }

        }

    }

    public class GetVipBuyCountRequest
    {

    }
}