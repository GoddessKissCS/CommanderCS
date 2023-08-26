using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Shop
{
    [Packet(Id = MethodId.GetCashShopList)]
    public class GetCashShopList : BaseMethodHandler<GetCashShopListRequest>
    {
        public override object Handle(GetCashShopListRequest @params)
        {

#warning TODO
            // NEED TO ADD A MONTHLY BUYABLE package

            List<CashShopData> csl = new() { };
            CashShopData c = new()
            {
                price = "1",
                firstBuyCash = 1,
                eventCash = 1,
                remainTime = 0,
                buyCount = 1,
                priceId = "gk.dia.100",
                pType = Logic.Enums.ECashRechargePriceType.Dollars
            };

            csl.Add(c);

            ResponsePacket response = new()
            {
                Result = csl,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class GetCashShopListRequest
    {

    }

    /*
             * "gk.dia.100":
               "gk.dia.400":
               "gk.dia.1200":
               "gk.dia.2000":
               "gk.dia.4000":
               "gk.package.monthly":
               "gk.package.monthly03":
               "gk.package.starter.01":
               "gk.package.starter.02":
               "gk.package.starter.03":
               "gk.package.starter.04":
               "gk.package.starter.05":
               "gk.package.starter.06":
               "gk.package.starter.07":
               "gk.package.starter.08":
               "gk.package.gold.01":
               "gk.package.interlevel":
               "gk.package.ticket.01":
               "gk.package.gift.01":
               "gk.package.ticket.02":
               "gk.package.gift.02":
               "gk.package.pilot01":
               "gk.package.pilot02":
               "gk.package.pilot03":
               "gk.package.monthly.gold":
               "gk.package.gift.premium":
               "gk.package.growth.gold":
               "gk.package.enhance.red":
               "gk.package.wring.basic":
               "gk.package.wring.adv":
               "gk.package.baldr01":
               "gk.package.baldr02":
               "gk.package.baldr03":
               "gk.package.growth.commander":
               "gk.package.clear.stage":
               "gk.package.starter.booster":
               "gk.package.new.pilot01":
               "gk.package.new.pilot02":
               "gk.package.special.pilot":
               "gk.package.special.limit01":
               "gk.package.special.limit02":
               "gk.package.pilot04":
               "gk.package.pilot05":
               "gk.package.pilot06":
               "gk.package.pilot07":
               "gk.package.pilot08":
               "gk.package.dia.200.discount":
               "gk.package.dia.400.discount":
               "gk.package.dia.1200.discount":
               "gk.package.dia.2000.discount":
               "gk.package.dia.4000.discount":
               "gk.package.lvlboost.01":
               "gk.package.lvlboost.02":
               "gk.package.lvlboost.03":
               "gk.package.lvlboost.04":
               "gk.package.lvlboost.05":
               "gk.package.dormitory01":
               "gk.package.monthly.dorm":
               "gk.package.ltd.bonuspack":
               "gk.package.crystal.a":
               "gk.package.crystal.b":
               "gk.package.crystal.c":
               "gk.package.crystal.d":
               "gk.package.crystal.e":
               "gk.package.crystal.f":
               "gk.package.crystal.g":
               "gk.package.crystal.h":
               "gk.package.crystal.i":
               "gk.package.dia.8000":
               "gk.package.monthly.gold02":
               "gk.package.monthly.affection":
               "gk.package.monthly.premium.affection":
               "gk.package.5500r1":
               "gk.package.5500r2":
               "gk.package.11000r1":
               "gk.package.11000r2":
               "gk.package.11000r3":
               "gk.package.11000r4":
               "gk.package.11000r5":
               "gk.package.33000r1":
               "gk.package.33000r2":
               "gk.package.33000r3":
               "gk.package.33000r4":
               "gk.package.33000r5":
               "gk.package.55000r1":
               "gk.package.55000r2":
               "gk.package.55000r3":
               "gk.package.55000r4":
               "gk.package.55000r5":
               "gk.package.99000r1":
               "gk.package.99000r2":
               "gk.package.99000r3":
               "gk.package.99000r4":
               "gk.package.99000r5":
               "gk.package.110000r1":
               "gk.package.110000r2":
               "gk.package.110000r3":
               "gk.package.110000r4":
               "gk.package.110000r5":
             * */

}
/*
	// Token: 0x06006007 RID: 24583 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7100", true, true)]
	public void GetCashShopList()
	{
	}

	// Token: 0x06006008 RID: 24584 RVA: 0x001AFC54 File Offset: 0x001ADE54
	private IEnumerator GetCashShopListResult(JsonRpcClient.Request request, List<Protocols.CashShopData> result)
	{
		if (result != null)
		{
			if (result.Count != 0)
			{
				this.regulation.cashShopDtbl = result;
			}
			if (UIManager.instance.world != null)
			{
				UIManager.instance.world.mainCommand.OpenAndInitDiamondShop();
			}
			Message.Send("Shop.Open.CashShop");
		}
		yield break;
	}*/