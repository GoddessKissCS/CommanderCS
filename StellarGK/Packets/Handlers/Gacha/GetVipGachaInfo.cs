﻿using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Command(Id = CommandId.GetVipGachaInfo)]
    public class GetVipGachaInfo : BaseCommandHandler<GetVipGachaInfoRequest>
    {
        public override object Handle(GetVipGachaInfoRequest @params)
        {
            VipGacha result = new VipGacha();

            return "{}";
        }


    }

    public class GetVipGachaInfoRequest
    {

    }
}