using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.PreDeck
{
    [Packet(Id = Method.BuyPredeckSlot)]
    public class BuyPredeckSlot : BaseMethodHandler<BuyPredeckSlotRequest>
    {
        public override object Handle(BuyPredeckSlotRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

            if (User.Statistics.PredeckCount >= 20)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            int cashCost = RemoteObjectManager.DefineDataTable.DECK_PLUS_CASH + RemoteObjectManager.DefineDataTable.DECK_PLUS_CASH_VALUE * (User.Statistics.PredeckCount - RemoteObjectManager.DefineDataTable.BASE_DECK_COUNT);

            if (User.Resources.cash > cashCost)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            var user = DatabaseManager.GameProfile.UpdateCash(SessionId, cashCost, false);

            DatabaseManager.GameProfile.AddEmptyPreDeckSlot(SessionId, user.Statistics.PredeckCount);

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