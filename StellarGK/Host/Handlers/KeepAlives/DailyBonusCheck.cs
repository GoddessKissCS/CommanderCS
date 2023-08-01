using Newtonsoft.Json;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.KeepAlives
{
    [Command(Id = CommandId.DailyBonusCheck)]
    public class DailyBonusCheck : BaseCommandHandler<DailyBonusCheckRequest>
    {
        public override string Handle(DailyBonusCheckRequest @params)
        {
            // TODO
            // ADD Daily list that clears every month
            // Check against which day it is today and give the apprioate response

            DailyBonusCheckResponse DailyBonusCheckResponse = new()
            {
                day = 1,
                version = "1",
                goodsId = "1",
                goodsCount = 10,
                startTimeString = "1",
                endTimeString = "2",
                receiveState = 0,
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = DailyBonusCheckResponse,
            };

            return JsonConvert.SerializeObject(response);
        }

    }

    public class DailyBonusCheckRequest
    {

    }
}