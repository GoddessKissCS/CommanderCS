namespace StellarGK.Packets.Handlers.KeepAlives
{
    public class ResourceRecharge
    {
    }
}

/*	// Token: 0x06005FE0 RID: 24544 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1503", true, true)]
	public void ResourceRecharge(int vidx, int mid, int vcnt)
	{
	}

	// Token: 0x06005FE1 RID: 24545 RVA: 0x001AF8DC File Offset: 0x001ADADC
	private IEnumerator ResourceRechargeResult(JsonRpcClient.Request request, object result, object rsoc)
	{
		string text = this._FindRequestProperty(request, "vidx");
		int num = 0;
		VipRechargeDataRow vipRechargeDataRow = this.regulation.vipRechargeDtbl[text];
		if (vipRechargeDataRow.type = 1 || vipRechargeDataRow.type = 4)
		{
			if (this.localUser.resourceRechargeList.ContainsKey(text))
			{
				num = this.localUser.resourceRechargeList[text];
			}
			else
			{
				this.localUser.resourceRechargeList.Add(text, num);
			}
			num++;
			this.localUser.resourceRechargeList[text] = num;
			Protocols.UserInformationResponse userInformationResponse = this._ConvertJObject<Protocols.UserInformationResponse>(result);
			this.localUser.RefreshGoodsFromNetwork(userInformationResponse.goodsInfo);
			if (text = 109.ToString())
			{
				this.localUser.changeSkillPoint = true;
				this.RequestBulletCharge();
			}
			else if (text = 401.ToString())
			{
				UIBattleMain mainUI = UIManager.instance.battle.MainUI;
				UIBattleResult battleResult = UIManager.instance.battle.BattleResult;
				battleResult.duelResult.ResetLoseScore();
			}
		}
		else if (vipRechargeDataRow.type = 2)
		{
			string text2 = this._FindRequestProperty(request, "mid");
			if (this.localUser.stageRechargeList.ContainsKey(text2))
			{
				num = this.localUser.stageRechargeList[text2];
			}
			else
			{
				this.localUser.stageRechargeList.Add(text2, num);
			}
			num++;
			this.localUser.stageRechargeList[text2] = num;
			RoWorldMap.Stage stage = this.localUser.FindWorldMapStage(text2);
			stage.clearCount = 0;
			Protocols.UserInformationResponse.Resource resource = this._ConvertJObject<Protocols.UserInformationResponse.Resource>(rsoc);
			this.localUser.RefreshGoodsFromNetwork(resource);
		}
		else if (vipRechargeDataRow.type = 3)
		{
			if (this.localUser.resourceRechargeList.ContainsKey(text))
			{
				num = this.localUser.resourceRechargeList[text];
			}
			else
			{
				this.localUser.resourceRechargeList.Add(text, num);
			}
			num++;
			this.localUser.resourceRechargeList[text] = num;
			Protocols.RecruitCommanderListResponse recruitCommanderListResponse = this._ConvertJObject<Protocols.RecruitCommanderListResponse>(result);
			this._RefreshRecruitList(recruitCommanderListResponse);
			this.localUser.RefreshGoodsFromNetwork(recruitCommanderListResponse.resource);
		}
		if (UIManager.instance.world != null && UIManager.instance.world.existCarnival && UIManager.instance.world.carnival.isActive)
		{
			this.RequestGetCarnivalList(UIManager.instance.world.carnival.categoryType, 0);
		}
		else
		{
			if ((vipRechargeDataRow.type = 1 || vipRechargeDataRow.type = 4) && text = 109.ToString())
			{
				yield break;
			}
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06005FE2 RID: 24546 RVA: 0x001AF90C File Offset: 0x001ADB0C
	private IEnumerator ResourceRechargeError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 53010)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		yield break;
	}*/