using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseMethodHandler<LoginTutorialSkipRequest>
    {
        public override object Handle(LoginTutorialSkipRequest @params)
        {

            UserInformationResponse.TutorialData tutorialData = new() { skip = Convert.ToBoolean(@params.skip), step = 12 };

            // add missing heros and shit


            if (@params.skip == 1)
            {
                User.LastStage = 4;
                User.BattleData.WorldMapStageReward["0"] = 1;
                User.BattleData.WorldMapStages["0"][0].star = 3;
                User.BattleData.WorldMapStages["0"][1].star = 3;
                User.BattleData.WorldMapStages["0"][2].star = 3;
                User.TutorialData.step = 12;
                User.TutorialData.skip = Convert.ToBoolean(@params.skip);

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