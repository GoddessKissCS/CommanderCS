using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using static CommanderCSLibrary.Shared.Constants;

namespace CommanderCS.Packets.Handlers.PreDeck
{
    [Packet(Id = Method.BuyPredeckSlot)]
    public class BuyPredeckSlot : BaseMethodHandler<BuyPredeckSlotRequest>
    {
        public override object Handle(BuyPredeckSlotRequest @params)
        {
            var session = GetSession();
            var user = GetUserGameProfile();

            if (user.UserStatistics.PredeckCount >= 20)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            int cashCost = DefineDataTable.DECK_PLUS_CASH + DefineDataTable.DECK_PLUS_CASH_VALUE * (user.UserStatistics.PredeckCount - DefineDataTable.BASE_DECK_COUNT);

            if (user.UserResources.cash > cashCost)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            user = DatabaseManager.GameProfile.UpdateCash(session, cashCost, false);

            DatabaseManager.GameProfile.AddEmptyPreDeckSlot(session, user.UserStatistics.PredeckCount);

            var userInformationResponse = GetUserInformationResponse(user);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class BuyPredeckSlotRequest
    {
    }
}