﻿using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Login
{
    [Packet(Id = Method.Logout)]
    public class Logout : BaseMethodHandler<LogoutRequest>
    {
        public override object Handle(LogoutRequest @params)
        {            
            logout logout = new() { success = true };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = logout.success
            };

            return response;
        }

        private class logout
        {
            [JsonProperty("success")]
            public bool success { get; set; }
        }
    }

    public class LogoutRequest
    {
    }
}