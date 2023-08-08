using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Command(Id = CommandId.GachaInformation)]
    public class GachaInformation : BaseCommandHandler<GachaInformationRequest>
    {

        public override object Handle(GachaInformationRequest @params)
        {
            ResponsePacket response = new();

            Dictionary<string, GachaInformationResponse> test = new();

            GachaInformationResponse w = new()
            {
                freeOpenRemainTime = 0,
                freeOpenRemainCount = 0,
                pilotRate = 1,
                type = "1"
            };

            test.Add("1", w);


            response.id = BasePacket.Id;
            response.result = test;

            return response;
        }

        /*
        public static string GachaOpenBox(Packet packet)
        {
            GachaBoxOpenResult gacha = new();

            List<GachaOpenBoxResponse.Reward> rewards = new();

            int count = (int)packet.Parameters["cnt"];
            int GachaType = (int)packet.Parameters["gbIdx"];

            for (int i = 0; i > count; i++)
            {
                var reward = JsonParser.GachaReward(GachaType);
                JObject rewarded = (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(reward));

                GachaOpenBoxResponse.Reward RealItem = new();

                ERewardType MN = (ERewardType)Enum.ToObject(typeof(ERewardType), (int)rewarded["rewardType"]);

                RealItem.id = (string)rewarded["rewardId"];
                RealItem.count = (int)rewarded["rewardCount"];
                RealItem.type = MN;

                rewards.Add(RealItem);
            }

            GachaOpenBoxResponse gachaOpen = new();
            gachaOpen.changedGachaInformation = new();
            gachaOpen.rewardList = rewards;
            gachaOpen.goodsResult = new();
            gachaOpen.costumeData = new();
            gachaOpen.foodData = new();
            gachaOpen.partData = new();
            gachaOpen.itemData = new();
            gachaOpen.medalData = new();
            gachaOpen.commanderIdDict = new();
            gachaOpen.commanderIdMedalDict = new();
            gachaOpen.eventResourceData = new();
            gachaOpen.equipItem = new();

            gacha.id = packet.id;
            gacha.result = gachaOpen;

            return Serialize(gacha);
        }

        */

    }


    public class GachaInformationRequest
    {

    }


}
