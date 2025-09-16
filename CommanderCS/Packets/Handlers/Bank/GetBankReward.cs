using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Bank
{
    [Packet(Id = CommanderCS.Library.Enums.Method.GetBankReward)]
    public class GetBankReward : BaseMethodHandler<GetBankRewardRequest>
    {
        public override object Handle(GetBankRewardRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            GetBankRewardResponse getBankRewardResponse = new()
            {
                gold = User.Resources.gold
            };

            ResponsePacket response = new() { Id = BasePacket.Id, Result = getBankRewardResponse };

            return response;
        }
    }

    public class GetBankRewardRequest
    {
    }

    public class GetBankRewardResponse
    {
        public long gold { get; set; }
    }
}