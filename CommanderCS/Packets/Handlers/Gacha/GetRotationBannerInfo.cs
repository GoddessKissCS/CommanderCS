using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Gacha
{
    [Packet(Id = Method.GetRotationBannerInfo)]
    public class GetRotationBannerInfo : BaseMethodHandler<GetRotationBannerInfoRequest>
    {
        public override object Handle(GetRotationBannerInfoRequest @params)
        {
            // https://unixtime.org/

            // needs further investigation.

            List<RotationBanner.BannerList> bannerListFromDatabase = DatabaseManager.RotationBanner.GetAllCurrentBannersList();

            RotationBanner rotationBanner = new()
            {
                //max banner rotation
                //probably useless but who cares
                roataionTime = 1719757852,

                bannerList = bannerListFromDatabase,
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