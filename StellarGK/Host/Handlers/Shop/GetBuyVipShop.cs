using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Shop
{
    [Command(Id = CommandId.GetBuyVipShop)]
    public class GetBuyVipShop : BaseCommandHandler<GetBuyVipShopRequest>
    {
        public override object Handle(GetBuyVipShopRequest @params)
        {
            return "{}";
        }
    }

    public class GetBuyVipShopRes
    {
        public string id { get; set; }
        public BuyVipShop result { get; set; }
    }

    public class GetBuyVipShopRequest
    {

    }


}