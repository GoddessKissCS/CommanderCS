using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.KeepAlives
{
    [Command(Id = CommandId.BulletCharge)]
    public class BulletCharge : BaseCommandHandler<BulletChargeResult>
    {
        public override object Handle(BulletChargeResult @params)
        {
            var user = GetGameProfile();

            int bullets = UserLevelData.GetInstance().FromLevel(user.userResources.level).maxBullet;

            ResourceRecharge resource = new()
            {

                bulletData = new()
                {
                    cnt = user.userResources.bullet,
                    remain = bullets,
                },
                oilData = new()
                {
                    cnt = user.userResources.oil,
                    remain = user.userResources.oil,
                },
                skillData = new()
                {
                    remain = 0,
                    cnt = 0,
                },
                chip = new()
                {
                    remain = user.userResources.chip,
                    cnt = user.userResources.chip,
                },
                weaponMaterialData1 = new()
                {
                    cnt = user.userResources.weaponMaterial1,
                    remain = user.userResources.weaponMaterial1,
                },
                weaponMaterialData2 = new()
                {
                    cnt = user.userResources.weaponMaterial2,
                    remain = user.userResources.weaponMaterial2,
                },
                weaponMaterialData3 = new()
                {
                    cnt = user.userResources.weaponMaterial3,
                    remain = user.userResources.weaponMaterial3,
                },
                weaponMaterialData4 = new()
                {
                    cnt = user.userResources.weaponMaterial4,
                    remain = user.userResources.weaponMaterial4,
                },
                worldState = user.worldState,
                gacha = new()
                {

                }
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = resource
            };

            return response;
        }

    }

    public class BulletChargeResult
    {

    }
}