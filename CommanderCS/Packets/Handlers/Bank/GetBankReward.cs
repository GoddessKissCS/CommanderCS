using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Bank
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.GetBankReward)]
    public class GetBankReward : BaseMethodHandler<GetBankRewardRequest>
    {
        public override object Handle(GetBankRewardRequest @params)
        {
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