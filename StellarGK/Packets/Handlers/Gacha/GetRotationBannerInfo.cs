﻿using StellarGK.Logic.Enums;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Command(Id = CommandId.GetRotationBannerInfo)]
    public class GetRotationBannerInfo : BaseCommandHandler<GetRotationBannerInfoRequest>
    {
        public override object Handle(GetRotationBannerInfoRequest @params)
        {
            RotationBanner.BannerList banner = new()
            {
                ImgUrl = "http://192.168.178.29:8080/events/event1.png",
                linkType = BannerListType.DiaShop,
                linkIdx = 1,
                eventIdx = 1,
                startDate = "1643673600",
                endDate = "1656626399",
            };
            List<RotationBanner.BannerList> bannerlist = new(new List<RotationBanner.BannerList>()
            {
                //{ banner }
            });

            RotationBanner rotationBanner = new()
            {
                roataionTime = 1643673600,
                bannerList = bannerlist,
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = rotationBanner,
            };

            return response;
        }

    }

    public class GetRotationBannerInfoRequest
    {

    }
}