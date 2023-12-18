using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.ExcelReader;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.KeepAlives
{
    [Packet(Id = Method.BulletCharge)]
    public class BulletCharge : BaseMethodHandler<BulletChargeResult>
    {
        public override object Handle(BulletChargeResult @params)
        {
            var user = GetUserGameProfile();

            int bullets = UserLevelData.GetInstance().FromLevel(user.UserResources.level).maxBullet;

            ResourceRecharge resource = new()
            {
                bulletData = new()
                {
                    cnt = user.UserResources.bullet,
                    remain = bullets,
                },
                oilData = new()
                {
                    cnt = user.UserResources.oil,
                    remain = user.UserResources.oil,
                },
                skillData = new()
                {
                    remain = 0,
                    cnt = 0,
                },
                chip = new()
                {
                    remain = user.UserResources.chip,
                    cnt = user.UserResources.chip,
                },
                weaponMaterialData1 = new()
                {
                    cnt = user.UserResources.weaponMaterial1,
                    remain = user.UserResources.weaponMaterial1,
                },
                weaponMaterialData2 = new()
                {
                    cnt = user.UserResources.weaponMaterial2,
                    remain = user.UserResources.weaponMaterial2,
                },
                weaponMaterialData3 = new()
                {
                    cnt = user.UserResources.weaponMaterial3,
                    remain = user.UserResources.weaponMaterial3,
                },
                weaponMaterialData4 = new()
                {
                    cnt = user.UserResources.weaponMaterial4,
                    remain = user.UserResources.weaponMaterial4,
                },
                worldState = user.WorldState,
                gacha = []
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