using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.KeepAlives
{
    [Command(Id = CommandId.BulletCharge)]
    public class BulletCharge : BaseCommandHandler<BulletChargeResult>
    {
        public override object Handle(BulletChargeResult @params)
        {
            var user = GetAccount();
            var res = GetResources();

            int bullets = UserLevelData.GetInstance().FromLevel(res.level).maxBullet;

            ResourceRecharge resource = new()
            {

                bulletData = new()
                {
                    cnt = Convert.ToInt32(res.bullet),
                    remain = bullets,
                },
                oilData = new()
                {
                    cnt = Convert.ToInt32(res.oil),
                    remain = Convert.ToInt32(res.oil)
                },
                skillData = new()
                {
                    remain = 0,
                    cnt = 0,
                },
                chip = new()
                {
                    remain = Convert.ToInt32(res.chip),
                    cnt = Convert.ToInt32(res.chip),
                },
                weaponMaterialData1 = new()
                {
                    cnt = Convert.ToInt32(res.weaponMaterial1),
                    remain = Convert.ToInt32(res.weaponMaterial1),
                },
                weaponMaterialData2 = new()
                {
                    cnt = Convert.ToInt32(res.weaponMaterial2),
                    remain = Convert.ToInt32(res.weaponMaterial2),
                },
                weaponMaterialData3 = new()
                {
                    cnt = Convert.ToInt32(res.weaponMaterial3),
                    remain = Convert.ToInt32(res.weaponMaterial3),
                },
                weaponMaterialData4 = new()
                {
                    cnt = Convert.ToInt32(res.weaponMaterial4),
                    remain = Convert.ToInt32(res.weaponMaterial4),
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