using CommanderCSLibrary.Shared.Enum;

using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.KeepAlives
{
    [Packet(Id = Method.BulletCharge)]
    public class BulletCharge : BaseMethodHandler<BulletChargeResult>
    {
        public override object Handle(BulletChargeResult @params)
        {
            int bullets = Regulation.userLevelDtbl.Find(x => x.level == User.UserResources.level).maxBullet;

            ResourceRecharge resource = new()
            {
                bulletData = new()
                {
                    cnt = User.UserResources.bullet,
                    remain = bullets,
                },
                oilData = new()
                {
                    cnt = User.UserResources.oil,
                    remain = User.UserResources.oil,
                },
                skillData = new()
                {
                    remain = 0, // NO IDEA ABOUT THOSE TWOS
                    cnt = 0,
                },
                chip = new()
                {
                    remain = User.UserResources.chip,
                    cnt = User.UserResources.chip,
                },
                weaponMaterialData1 = new()
                {
                    cnt = User.UserResources.weaponMaterial1,
                    remain = User.UserResources.weaponMaterial1,
                },
                weaponMaterialData2 = new()
                {
                    cnt = User.UserResources.weaponMaterial2,
                    remain = User.UserResources.weaponMaterial2,
                },
                weaponMaterialData3 = new()
                {
                    cnt = User.UserResources.weaponMaterial3,
                    remain = User.UserResources.weaponMaterial3,
                },
                weaponMaterialData4 = new()
                {
                    cnt = User.UserResources.weaponMaterial4,
                    remain = User.UserResources.weaponMaterial4,
                },
                worldState = User.WorldState,
                gacha = User.GachaInformation
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = resource
            };

            return response;
        }
    }

    public class BulletChargeResult
    {
    }
}