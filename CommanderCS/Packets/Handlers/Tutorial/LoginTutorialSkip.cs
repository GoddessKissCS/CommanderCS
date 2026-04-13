using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCS.Packets.Handlers.Commander;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Tutorial
{
    [Packet(Id = Method.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseMethodHandler<LoginTutorialSkipRequest>
    {
        public override object Handle(LoginTutorialSkipRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            // Needs to be set to 1 or something later on 

            UserInformationResponse.TutorialData tutorialData = new() { skip = Convert.ToBoolean(request.skip), step = 12 };

            if (request.skip == 1)
            {
                User.LastStage = 3;
                User.BattleData.WorldMapStageReward["0"] = 1;
                User.BattleData.WorldMapStages["0"][0].star = 3;
                User.BattleData.WorldMapStages["0"][1].star = 3;
                User.BattleData.WorldMapStages["0"][2].star = 3;
                User.TutorialData.step = 12;
                User.TutorialData.skip = Convert.ToBoolean(request.skip);
                User.Inventory.medalData.Remove("1");
                User.Resources.gold = 50000;
                User.Resources.cash = 500;
                User.Resources.bullet = 500;

                var firstCommander = CommanderRankUp.CreateCommander(1, 0, 1);
                var secondCommander = CommanderRankUp.CreateCommander(1, 0, 1);
                var thirdCommander = CommanderRankUp.CreateCommander(1, 0, 1);

                User.CommanderData.Add("1", firstCommander);

#warning       Needs to be adjusted to for each thing not update the whole

                DatabaseManager.GameProfile.UpdateUserData(SessionId, User);
            }

            DatabaseManager.GameProfile.UpdateTutorialData(SessionId, tutorialData);

            TutorialStep lts = new()
            {
                ttrl = tutorialData,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = lts
            };

            return response;
        }

        private class TutorialStep
        {
            [JsonProperty("ttrl")]
            public UserInformationResponse.TutorialData ttrl { get; set; }
        }
    }

    public class LoginTutorialSkipRequest
    {
        [JsonProperty("skip")]
        public int skip { get; set; }
    }
}