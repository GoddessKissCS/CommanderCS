using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.GetWaveDuelDefenderInfo)]
    public class GetWaveDuelDefenderInfo : BaseMethodHandler<GetWaveDuelDefenderInfoRequest>
    {
        public override object Handle(GetWaveDuelDefenderInfoRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

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