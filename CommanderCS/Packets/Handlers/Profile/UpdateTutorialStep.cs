﻿using Newtonsoft.Json;
using CommanderCS.Database;

namespace CommanderCS.Host.Handlers.Profile
{
    [Packet(Id = Method.UpdateTutorialStep)]
    public class UpdateTutorialStep : BaseMethodHandler<UpdateTutorialStepRequest>
    {
        public override object Handle(UpdateTutorialStepRequest @params)
        {
            UpdateTutorialStepInfo utsi = new();

            DatabaseManager.GameProfile.UpdateTutorialStep(GetSession(), @params.step);

            utsi.step = @params.step;

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = utsi,
            };

            return response;
        }

        public class UpdateTutorialStepInfo
        {
            [JsonProperty("step")]
            public int step { get; set; }
        }
    }

    public class UpdateTutorialStepRequest
    {
        [JsonProperty("mIdx")]
        public int mIdx { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }
    }
}