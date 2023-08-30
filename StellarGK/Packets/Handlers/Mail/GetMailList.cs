using StellarGK.Host;
using StellarGKLibrary.Protocols;

namespace StellarGK.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetMailList)]
    public class GetMailList : BaseMethodHandler<GetMailListRequest>
    {
        public override object Handle(GetMailListRequest @params)
        {
            MailInfo mailInfo = new()
            {
                mailList = GetUserGameProfile().MailDataList
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = mailInfo,
            };

            return response;
        }

    }

    public class GetMailListRequest
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6101", true, true)]
	public void GetMailList()
	{
	}

	// Token: 0x06005F6E RID: 24430 RVA: 0x001AEFD0 File Offset: 0x001AD1D0
	private IEnumerator GetMailListResult(JsonRpcClient.Request request, Protocols.MailInfo result)
	{
		int num = 0;
		for (int i = this.localUser.rewardList.Count - 1; i >= 0; i--)
		{
			if (this.localUser.rewardList[i].type == EReward.Mail)
			{
				this.localUser.rewardList.Remove(this.localUser.rewardList[i]);
				this.localUser.newMailCount--;
			}
		}
		if (result != null)
		{
			foreach (Protocols.MailInfo.MailData mailData in result.mailList)
			{
				RoReward roReward = new RoReward();
				roReward.type = EReward.Mail;
				roReward.id = mailData.idx.ToString();
				roReward.subType = mailData.type;
				if (mailData.type == 2)
				{
					roReward.title = Localization.Get("17079");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array = mailData.message.Split(new char[] { ',' });
						if (array.Length == 2)
						{
							RankingDataRow rankingDataRow = RemoteObjectManager.instance.regulation.rankingDtbl[array[1].ToString()];
							roReward.description = Localization.Format("17080", new object[]
							{
								array[0],
								Localization.Get(rankingDataRow.name)
							});
						}
					}
				}
				else if (mailData.type == 3)
				{
					roReward.title = Localization.Get("18913");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array2 = mailData.message.Split(new char[] { ',' });
						if (array2.Length == 2)
						{
							RankingDataRow rankingDataRow2 = RemoteObjectManager.instance.regulation.rankingDtbl[array2[1].ToString()];
							roReward.description = Localization.Format("18914", new object[]
							{
								array2[0],
								Localization.Get(rankingDataRow2.name)
							});
						}
					}
				}
				else if (mailData.type == 4)
				{
					roReward.title = Localization.Get("4818");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array3 = mailData.message.Split(new char[] { ',' });
						if (array3.Length == 2)
						{
							roReward.description = Localization.Format("4813", new object[] { array3[0] });
						}
					}
				}
				else if (mailData.type == 5)
				{
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array4 = mailData.message.Split(new char[] { ',' });
						if (array4[0] == "1")
						{
							roReward.title = Localization.Get("110285");
							roReward.description = Localization.Get("110361");
						}
						else if (array4[0] == "2")
						{
							roReward.title = Localization.Get("110287");
							roReward.description = Localization.Get("110363");
						}
						else if (array4[0] == "3")
						{
							roReward.title = Localization.Format("110288", new object[] { array4[1] });
							roReward.description = Localization.Get("110364");
						}
						else if (array4[0] == "4")
						{
							roReward.title = Localization.Get("110286");
							roReward.description = Localization.Get("110362");
						}
					}
				}
				else if (mailData.type == 6)
				{
					roReward.title = Localization.Get("5050015");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array5 = mailData.message.Split(new char[] { ',' });
						if (array5.Length == 2)
						{
							RankingDataRow rankingDataRow3 = RemoteObjectManager.instance.regulation.rankingDtbl[array5[1].ToString()];
							roReward.description = Localization.Format("5050016", new object[]
							{
								array5[0],
								Localization.Get(rankingDataRow3.name)
							});
						}
					}
				}
				else if (mailData.type == 7)
				{
					roReward.title = Localization.Get("70067");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array6 = mailData.message.Split(new char[] { ',' });
						if (array6.Length == 2)
						{
							roReward.description = Localization.Format("70068", new object[] { array6[1] });
						}
					}
				}
				else if (mailData.type == 8)
				{
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array7 = mailData.message.Split(new char[] { ',' });
						if (array7.Length == 2)
						{
							roReward.title = Localization.Format("21007", new object[] { array7[1] });
							roReward.description = Localization.Format("21008", new object[] { array7[1] });
						}
					}
				}
				else if (mailData.type == 9)
				{
					roReward.title = Localization.Get("400021");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array8 = mailData.message.Split(new char[] { ',' });
						if (array8.Length == 2)
						{
							RankingDataRow rankingDataRow4 = RemoteObjectManager.instance.regulation.rankingDtbl[array8[1].ToString()];
							roReward.description = Localization.Format("400022", new object[]
							{
								array8[0],
								Localization.Get(rankingDataRow4.name)
							});
						}
					}
				}
				else if (mailData.type == 10)
				{
					roReward.title = Localization.Get("400023");
					if (!string.IsNullOrEmpty(mailData.message))
					{
						string[] array9 = mailData.message.Split(new char[] { ',' });
						if (array9.Length == 2)
						{
							RankingDataRow rankingDataRow5 = RemoteObjectManager.instance.regulation.rankingDtbl[array9[1].ToString()];
							roReward.description = Localization.Format("400024", new object[]
							{
								array9[0],
								Localization.Get(rankingDataRow5.name)
							});
						}
					}
				}
				else
				{
					roReward.description = mailData.message;
				}
				roReward.completeTime = mailData.remainTime;
				if (string.IsNullOrEmpty(mailData.status))
				{
					roReward.received = false;
				}
				else
				{
					roReward.received = mailData.status.Equals("R");
				}
				if (mailData.reward != null)
				{
					roReward.rewardItem = mailData.reward;
				}
				this.localUser.rewardList.Add(roReward);
				this.localUser.newMailCount++;
				if (!roReward.received && roReward.IsCompleted())
				{
					num++;
				}
			}
		}
		this.localUser.badgeNewMailCount = num;
		UIManager.instance.world.mail.Set(EReward.Mail);
		UIManager.instance.world.mail.OpenPopup();
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("GetMailListResult");
		yield break;
	}*/