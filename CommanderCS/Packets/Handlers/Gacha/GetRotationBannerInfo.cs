using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Gacha
{
    [Packet(Id = Method.GetRotationBannerInfo)]
    public class GetRotationBannerInfo : BaseMethodHandler<GetRotationBannerInfoRequest>
    {
        public override object Handle(GetRotationBannerInfoRequest @params)
        {
            RotationBanner.BannerList banner = new()
            {
                ImgUrl = "http://192.168.178.29:8080/FileCDN/Event/TitleBanner/Notice_Icon.png",
                linkType = BannerListType.DiaShop,
                linkIdx = 0,
                eventIdx = 0,
                startDate = "1718721052",
                endDate = "1719757852",
               
            };

            RotationBanner.BannerList banner2 = new()
            {
                ImgUrl = "http://192.168.178.29:8080/FileCDN/Event/TitleBanner/Event_Icon.png",
                linkType = BannerListType.DiaShop,
                linkIdx = 1,
                eventIdx = 1,
                startDate = "1718721052",
                endDate = "1719757852",
            };

            // needs further investigation.

            List<RotationBanner.BannerList> bannerlist = new(new List<RotationBanner.BannerList>()
            {
                //{ banner }, { banner2 }
            });

            RotationBanner rotationBanner = new()
            {
                roataionTime = 1719757852,
                bannerList = bannerlist,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = rotationBanner,
            };

            return response;
        }
    }

    public class GetRotationBannerInfoRequest
    {
    }
}