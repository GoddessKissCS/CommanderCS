using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.GetWaveDuelDefenderInfo)]
    public class GetWaveDuelDefenderInfo : BaseMethodHandler<GetWaveDuelDefenderInfoRequest>
    {
        public override object Handle(GetWaveDuelDefenderInfoRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

            GetWaveDuelDefenderInfoResponse defenderInfoResponse = new() { decks = User.DefenderDeck.WaveDuelDefenderDecks };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = defenderInfoResponse
            };

            return response;
        }
    }

    public class GetWaveDuelDefenderInfoResponse
    {
        public Dictionary<string, Dictionary<string, string>> decks { get; set; }
    }

    public class GetWaveDuelDefenderInfoRequest
    {
    }
}