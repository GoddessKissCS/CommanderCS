using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Payment
{
    public class CheckPaymentTotalResult
    {
        
    }
}
/*	// Token: 0x06006014 RID: 24596 RVA: 0x001AFD68 File Offset: 0x001ADF68
	private IEnumerator CheckPaymentTotalResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		UIManager.World world = UIManager.instance.world;
		bool flag = this.localUser.vipLevel != result.resource.vipLevel;
		float inAppPrice = result.inAppPrice;
		if (result.reward != null && result.reward.Count > 0)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		if (result.userInfo != null)
		{
			this.localUser.statistics.firstPayment = result.userInfo.firstPayment;
		}
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		string text = this._FindRequestProperty(request, "productId");
		if (FB.IsInitialized)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["fb_content_id"] = "AddedPaymentInfo";
			dictionary["fb_payment_info_available"] = text;
			string text2 = "fb_mobile_add_payment_info";
			Dictionary<string, object> dictionary2 = dictionary;
			FB.LogAppEvent(text2, null, dictionary2);
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			dictionary3["mygame_packagename"] = text;
			FB.LogPurchase(inAppPrice, "USD", dictionary3);
		}
		switch (text)
		{
		case "gk.dia.100":
			AdjustManager.Instance.RevenueEvent("lt7ya0", (double)inAppPrice);
			break;
		case "gk.dia.400":
			AdjustManager.Instance.RevenueEvent("bvtogn", (double)inAppPrice);
			break;
		case "gk.dia.1200":
			AdjustManager.Instance.RevenueEvent("pkqgvx", (double)inAppPrice);
			break;
		case "gk.dia.2000":
			AdjustManager.Instance.RevenueEvent("ebptpz", (double)inAppPrice);
			break;
		case "gk.dia.4000":
			AdjustManager.Instance.RevenueEvent("sa7ufx", (double)inAppPrice);
			break;
		case "gk.package.monthly":
			AdjustManager.Instance.RevenueEvent("sdk3vu", (double)inAppPrice);
			break;
		case "gk.package.monthly03":
			AdjustManager.Instance.RevenueEvent("p2prt3", (double)inAppPrice);
			break;
		case "gk.package.starter.01":
			AdjustManager.Instance.RevenueEvent("8ycf4m", (double)inAppPrice);
			break;
		case "gk.package.starter.02":
			AdjustManager.Instance.RevenueEvent("w2ifnn", (double)inAppPrice);
			break;
		case "gk.package.starter.03":
			AdjustManager.Instance.RevenueEvent("urqrls", (double)inAppPrice);
			break;
		case "gk.package.starter.04":
			AdjustManager.Instance.RevenueEvent("2x7ggq", (double)inAppPrice);
			break;
		case "gk.package.starter.05":
			AdjustManager.Instance.RevenueEvent("apyz3u", (double)inAppPrice);
			break;
		case "gk.package.starter.06":
			AdjustManager.Instance.RevenueEvent("34rggg", (double)inAppPrice);
			break;
		case "gk.package.starter.07":
			AdjustManager.Instance.RevenueEvent("kvwr3j", (double)inAppPrice);
			break;
		case "gk.package.starter.08":
			AdjustManager.Instance.RevenueEvent("cyres1", (double)inAppPrice);
			break;
		case "gk.package.gold.01":
			AdjustManager.Instance.RevenueEvent("hguwxm", (double)inAppPrice);
			break;
		case "gk.package.interlevel":
			AdjustManager.Instance.RevenueEvent("veflju", (double)inAppPrice);
			break;
		case "gk.package.ticket.01":
			AdjustManager.Instance.RevenueEvent("x74eow", (double)inAppPrice);
			break;
		case "gk.package.gift.01":
			AdjustManager.Instance.RevenueEvent("vsrt1x", (double)inAppPrice);
			break;
		case "gk.package.ticket.02":
			AdjustManager.Instance.RevenueEvent("s1hrug", (double)inAppPrice);
			break;
		case "gk.package.gift.02":
			AdjustManager.Instance.RevenueEvent("y08121", (double)inAppPrice);
			break;
		case "gk.package.pilot01":
			AdjustManager.Instance.RevenueEvent("nk6cdb", (double)inAppPrice);
			break;
		case "gk.package.pilot02":
			AdjustManager.Instance.RevenueEvent("l7s441", (double)inAppPrice);
			break;
		case "gk.package.pilot03":
			AdjustManager.Instance.RevenueEvent("kegoyx", (double)inAppPrice);
			break;
		case "gk.package.monthly.gold":
			AdjustManager.Instance.RevenueEvent("deeg8e", (double)inAppPrice);
			break;
		case "gk.package.gift.premium":
			AdjustManager.Instance.RevenueEvent("kojdub", (double)inAppPrice);
			break;
		case "gk.package.growth.gold":
			AdjustManager.Instance.RevenueEvent("wcxlp0", (double)inAppPrice);
			break;
		case "gk.package.enhance.red":
			AdjustManager.Instance.RevenueEvent("wd28jj", (double)inAppPrice);
			break;
		case "gk.package.wring.basic":
			AdjustManager.Instance.RevenueEvent("ryttek", (double)inAppPrice);
			break;
		case "gk.package.wring.adv":
			AdjustManager.Instance.RevenueEvent("xhk2w7", (double)inAppPrice);
			break;
		case "gk.package.baldr01":
			AdjustManager.Instance.RevenueEvent("k4sx0m", (double)inAppPrice);
			break;
		case "gk.package.baldr02":
			AdjustManager.Instance.RevenueEvent("kclizw", (double)inAppPrice);
			break;
		case "gk.package.baldr03":
			AdjustManager.Instance.RevenueEvent("mmrhb7", (double)inAppPrice);
			break;
		case "gk.package.growth.commander":
			AdjustManager.Instance.RevenueEvent("hljqgz", (double)inAppPrice);
			break;
		case "gk.package.clear.stage":
			AdjustManager.Instance.RevenueEvent("uzng79", (double)inAppPrice);
			break;
		case "gk.package.starter.booster":
			AdjustManager.Instance.RevenueEvent("yfhiut", (double)inAppPrice);
			break;
		case "gk.package.new.pilot01":
			AdjustManager.Instance.RevenueEvent("xowv93", (double)inAppPrice);
			break;
		case "gk.package.new.pilot02":
			AdjustManager.Instance.RevenueEvent("30ghla", (double)inAppPrice);
			break;
		case "gk.package.special.pilot":
			AdjustManager.Instance.RevenueEvent("vdw3ym", (double)inAppPrice);
			break;
		case "gk.package.special.limit01":
			AdjustManager.Instance.RevenueEvent("woaev4", (double)inAppPrice);
			break;
		case "gk.package.special.limit02":
			AdjustManager.Instance.RevenueEvent("vcffuz", (double)inAppPrice);
			break;
		case "gk.package.pilot04":
			AdjustManager.Instance.RevenueEvent("bqmi4j", (double)inAppPrice);
			break;
		case "gk.package.pilot05":
			AdjustManager.Instance.RevenueEvent("9895vi", (double)inAppPrice);
			break;
		case "gk.package.pilot06":
			AdjustManager.Instance.RevenueEvent("v4sy21", (double)inAppPrice);
			break;
		case "gk.package.pilot07":
			AdjustManager.Instance.RevenueEvent("vadwa7", (double)inAppPrice);
			break;
		case "gk.package.pilot08":
			AdjustManager.Instance.RevenueEvent("ys1o2h", (double)inAppPrice);
			break;
		case "gk.package.dia.200.discount":
			AdjustManager.Instance.RevenueEvent("jc6h46", (double)inAppPrice);
			break;
		case "gk.package.dia.400.discount":
			AdjustManager.Instance.RevenueEvent("2b671h", (double)inAppPrice);
			break;
		case "gk.package.dia.1200.discount":
			AdjustManager.Instance.RevenueEvent("2g3c8q", (double)inAppPrice);
			break;
		case "gk.package.dia.2000.discount":
			AdjustManager.Instance.RevenueEvent("kk0hhd", (double)inAppPrice);
			break;
		case "gk.package.dia.4000.discount":
			AdjustManager.Instance.RevenueEvent("m452dx", (double)inAppPrice);
			break;
		case "gk.package.lvlboost.01":
			AdjustManager.Instance.RevenueEvent("7r5n59", (double)inAppPrice);
			break;
		case "gk.package.lvlboost.02":
			AdjustManager.Instance.RevenueEvent("jxyi67", (double)inAppPrice);
			break;
		case "gk.package.lvlboost.03":
			AdjustManager.Instance.RevenueEvent("jsqrng", (double)inAppPrice);
			break;
		case "gk.package.lvlboost.04":
			AdjustManager.Instance.RevenueEvent("6cabyw", (double)inAppPrice);
			break;
		case "gk.package.lvlboost.05":
			AdjustManager.Instance.RevenueEvent("8dqwce", (double)inAppPrice);
			break;
		case "gk.package.dormitory01":
			AdjustManager.Instance.RevenueEvent("qvslr2", (double)inAppPrice);
			break;
		case "gk.package.monthly.dorm":
			AdjustManager.Instance.RevenueEvent("fa99ax", (double)inAppPrice);
			break;
		case "gk.package.ltd.bonuspack":
			AdjustManager.Instance.RevenueEvent("lkpu8i", (double)inAppPrice);
			break;
		case "gk.package.crystal.a":
			AdjustManager.Instance.RevenueEvent("on5rkm", (double)inAppPrice);
			break;
		case "gk.package.crystal.b":
			AdjustManager.Instance.RevenueEvent("146e6o", (double)inAppPrice);
			break;
		case "gk.package.crystal.c":
			AdjustManager.Instance.RevenueEvent("2qiudc", (double)inAppPrice);
			break;
		case "gk.package.crystal.d":
			AdjustManager.Instance.RevenueEvent("g6uyzo", (double)inAppPrice);
			break;
		case "gk.package.crystal.e":
			AdjustManager.Instance.RevenueEvent("vyefkn", (double)inAppPrice);
			break;
		case "gk.package.crystal.f":
			AdjustManager.Instance.RevenueEvent("l0aamv", (double)inAppPrice);
			break;
		case "gk.package.crystal.g":
			AdjustManager.Instance.RevenueEvent("pftp6l", (double)inAppPrice);
			break;
		case "gk.package.crystal.h":
			AdjustManager.Instance.RevenueEvent("b8dl5n", (double)inAppPrice);
			break;
		case "gk.package.crystal.i":
			AdjustManager.Instance.RevenueEvent("dsgwkf", (double)inAppPrice);
			break;
		case "gk.package.dia.8000":
			AdjustManager.Instance.RevenueEvent("5jhck2", (double)inAppPrice);
			break;
		case "gk.package.monthly.gold02":
			AdjustManager.Instance.RevenueEvent("f6mbwp", (double)inAppPrice);
			break;
		case "gk.package.monthly.affection":
			AdjustManager.Instance.RevenueEvent("f0jzwl", (double)inAppPrice);
			break;
		case "gk.package.monthly.premium.affection":
			AdjustManager.Instance.RevenueEvent("76kz46", (double)inAppPrice);
			break;
		case "gk.package.5500r1":
			AdjustManager.Instance.RevenueEvent("4f3jtz", (double)inAppPrice);
			break;
		case "gk.package.5500r2":
			AdjustManager.Instance.RevenueEvent("pazdpf", (double)inAppPrice);
			break;
		case "gk.package.11000r1":
			AdjustManager.Instance.RevenueEvent("o0wt43", (double)inAppPrice);
			break;
		case "gk.package.11000r2":
			AdjustManager.Instance.RevenueEvent("pzs0fq", (double)inAppPrice);
			break;
		case "gk.package.11000r3":
			AdjustManager.Instance.RevenueEvent("slj6as", (double)inAppPrice);
			break;
		case "gk.package.11000r4":
			AdjustManager.Instance.RevenueEvent("bor0w5", (double)inAppPrice);
			break;
		case "gk.package.11000r5":
			AdjustManager.Instance.RevenueEvent("74fg8t", (double)inAppPrice);
			break;
		case "gk.package.33000r1":
			AdjustManager.Instance.RevenueEvent("1b77tz", (double)inAppPrice);
			break;
		case "gk.package.33000r2":
			AdjustManager.Instance.RevenueEvent("gnc4sj", (double)inAppPrice);
			break;
		case "gk.package.33000r3":
			AdjustManager.Instance.RevenueEvent("6h3dp9", (double)inAppPrice);
			break;
		case "gk.package.33000r4":
			AdjustManager.Instance.RevenueEvent("pws2lz", (double)inAppPrice);
			break;
		case "gk.package.33000r5":
			AdjustManager.Instance.RevenueEvent("7c4u97", (double)inAppPrice);
			break;
		case "gk.package.55000r1":
			AdjustManager.Instance.RevenueEvent("872ua8", (double)inAppPrice);
			break;
		case "gk.package.55000r2":
			AdjustManager.Instance.RevenueEvent("oljq03", (double)inAppPrice);
			break;
		case "gk.package.55000r3":
			AdjustManager.Instance.RevenueEvent("d89w5x", (double)inAppPrice);
			break;
		case "gk.package.55000r4":
			AdjustManager.Instance.RevenueEvent("h0ulqs", (double)inAppPrice);
			break;
		case "gk.package.55000r5":
			AdjustManager.Instance.RevenueEvent("wf4r62", (double)inAppPrice);
			break;
		case "gk.package.99000r1":
			AdjustManager.Instance.RevenueEvent("4gsym7", (double)inAppPrice);
			break;
		case "gk.package.99000r2":
			AdjustManager.Instance.RevenueEvent("2j9n1y", (double)inAppPrice);
			break;
		case "gk.package.99000r3":
			AdjustManager.Instance.RevenueEvent("mssu51", (double)inAppPrice);
			break;
		case "gk.package.99000r4":
			AdjustManager.Instance.RevenueEvent("g9yqmb", (double)inAppPrice);
			break;
		case "gk.package.99000r5":
			AdjustManager.Instance.RevenueEvent("ecxk18", (double)inAppPrice);
			break;
		case "gk.package.110000r1":
			AdjustManager.Instance.RevenueEvent("ew82jt", (double)inAppPrice);
			break;
		case "gk.package.110000r2":
			AdjustManager.Instance.RevenueEvent("24t4d7", (double)inAppPrice);
			break;
		case "gk.package.110000r3":
			AdjustManager.Instance.RevenueEvent("v1mmll", (double)inAppPrice);
			break;
		case "gk.package.110000r4":
			AdjustManager.Instance.RevenueEvent("n82enz", (double)inAppPrice);
			break;
		case "gk.package.110000r5":
			AdjustManager.Instance.RevenueEvent("y641b9", (double)inAppPrice);
			break;
		}
		if (world != null)
		{
			RoBuilding roBuilding = this.localUser.FindBuilding(EBuilding.VipShop);
			if (roBuilding != null && this.localUser.vipLevel == roBuilding.reg.vipLevel && !roBuilding.GetUIBuilding().gameObject.activeSelf)
			{
				NetworkAnimation.Instance.CreateFloatingText_OnlyUIToast(Localization.Get("22006"), roBuilding.reg.resourceId);
			}
			RoBuilding roBuilding2 = this.localUser.FindBuilding(EBuilding.VipGacha);
			if (roBuilding2 != null && this.localUser.vipLevel == roBuilding2.reg.vipLevel && !roBuilding2.GetUIBuilding().gameObject.activeSelf)
			{
				string text3 = "Loot_carrier";
				NetworkAnimation.Instance.CreateFloatingText_OnlyUIToast(Localization.Get("7167"), text3);
			}
		}
		if (world != null && world.existCarnival && world.carnival.isActive)
		{
			this.RequestGetCarnivalList(UIManager.instance.world.carnival.categoryType, 0);
		}
		else
		{
			UIManager.instance.RefreshOpenedUI();
		}
		int num2 = int.Parse(this.regulation.defineDtbl["VIPGRADE_GACHA_DELAY_FREE"].value);
		int num3 = int.Parse(this.regulation.defineDtbl["VIPGRADE_GACHA_FREE_PREMIUM"].value);
		if (world != null && world.existGacha && world.gacha.isActive && (this.localUser.vipLevel >= num2 || this.localUser.vipLevel >= num3) && flag)
		{
			this.RequestGachaInformation();
		}
		int num4 = int.Parse(this.regulation.defineDtbl["VIPGRADE_BATTLESHOP_REFRESH"].value);
		if (world != null && world.existSecretShop && world.secretShop.isActive && this.localUser.vipLevel >= num4 && flag)
		{
			UIManager.instance.RefreshOpenedUI();
		}
		if (world != null && world.existWaveBattle && world.waveBattle.isActive && flag)
		{
			this.RequestWaveBattleList();
		}
		int num5 = int.Parse(this.regulation.defineDtbl["DAILYMISSION_MIN_VIP"].value);
		if (world != null && world.existWarHome && world.warHome.isActive && this.localUser.vipLevel >= num5 && flag)
		{
			world.warHome.Close();
		}
		Message.Send("Update.Goods");
		yield break;
	}*/