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


    public class GetBuyVipShopRequest
    {

    }


}