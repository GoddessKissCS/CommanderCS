﻿using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Sign
{
    [Command(Id = CommandId.GuestSignUp)]
    public class GuestSignUp : BaseCommandHandler<GuestSignUpRequest>
    {
        public override object Handle(GuestSignUpRequest @params)
        {

            GuestSignUpPacket SignUp = new()
            {
                uid = RequestSignUp(@params.plfm, @params.ch),
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = SignUp
            };

            return response;
        }


        private static string RequestSignUp(int platformid, int channel)
        {
            return DatabaseManager.Account.CreateGuest(platformid, channel).name;
        }

        public class GuestSignUpPacket
        {
            [JsonPropertyName("uid")]
            public string uid { get; set; }
        }
    }
    public class GuestSignUpRequest
    {
        [JsonPropertyName("ch")]
        public int ch { get; set; }

        [JsonPropertyName("plfm")]
        public int plfm { get; set; }
    }
}