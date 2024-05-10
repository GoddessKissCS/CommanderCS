using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Packets.Handlers.PreDeck
{
    [Packet(Id = Method.BuyPredeckSlot)]
    public class BuyPredeckSlot : BaseMethodHandler<BuyPredeckSlotRequest>
    {
        public override object Handle(BuyPredeckSlotRequest @params)
        {
            if (User.UserStatistics.PredeckCount >= 20)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            int cashCost = RemoteObjectManager.DefineDataTable.DECK_PLUS_CASH + RemoteObjectManager.DefineDataTable.DECK_PLUS_CASH_VALUE * (User.UserStatistics.PredeckCount - RemoteObjectManager.DefineDataTable.BASE_DECK_COUNT);

            if (User.UserResources.cash > cashCost)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            User = DatabaseManager.GameProfile.UpdateCash(Session, cashCost, false);

            DatabaseManager.GameProfile.AddEmptyPreDeckSlot(Session, User.UserStatistics.PredeckCount);

            var userInformationResponse = GetUserInformationResponse(User);

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