using CommanderCS.Library.Enums;

namespace CommanderCS.Packets.Handlers.Bank
{
    [Packet(Id = Method.BankInfo)]
    public class BankInfo : BaseMethodHandler<BankInfoRequest>
    {
        public override object Handle(BankInfoRequest @params)
        {
            var bankInfo = new CommanderCS.Library.Protocols.BankInfo()
            {
                exchangeRateCnt = 0,
                level = 0,
                luck = 0,
                remain = 0,
                __cash = "0",
                __chip = "0",
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = bankInfo
            };

            return response;
        }
    }

    public class BankInfoRequest
    {
    }
}