using System.Reflection.Emit;
using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.KeepAlives
{
    [Command(Id = CommandId.BulletCharge)]
    public class BulletCharge : BaseCommandHandler<BulletChargeResult>
    {


        public override string Handle(BulletChargeResult @params)
        {

            var charge = UserInfoReq(BasePacket.Session);

            int bullets = UserLevelData.GetInstance().FromLevel(Convert.ToInt32(charge.level)).maxBullet;

            ResponsePacket response = new();


            ResourceRecharge resource = new()
            {

                bulletData = new()
                {
                    cnt = Convert.ToInt32(charge.bullet),
                    remain = bullets,
                },
                oilData = new()
                {
                    cnt = Convert.ToInt32(charge.oil),
                    remain = Convert.ToInt32(charge.oil)
                },
                skillData = new()
                {
                    remain = 0,
                    cnt = 0,
                },
                chip = new()
                {
                    remain = Convert.ToInt32(charge.chip),
                    cnt = Convert.ToInt32(charge.chip),
                },
                weaponMaterialData1 = new()
                {
                    cnt = Convert.ToInt32(charge.weaponMaterial1),
                    remain = Convert.ToInt32(charge.weaponMaterial1),
                },
                weaponMaterialData2 = new()
                {
                    cnt = Convert.ToInt32(charge.weaponMaterial2),
                    remain = Convert.ToInt32(charge.weaponMaterial2),
                },
                weaponMaterialData3 = new()
                {
                    cnt = Convert.ToInt32(charge.weaponMaterial3),
                    remain = Convert.ToInt32(charge.weaponMaterial3),
                },
                weaponMaterialData4 = new()
                {
                    cnt = Convert.ToInt32(charge.weaponMaterial4),
                    remain = Convert.ToInt32(charge.weaponMaterial4),
                },
                worldState = charge.world,
                gacha = new()
                {

                }
            };

            response.id = BasePacket.Id;
            response.result = resource;


            return JsonConvert.SerializeObject(response);
        }

        private static _BulletCharge UserInfoReq(string sess)
        {
            var user = DatabaseManager.Account.FindBySession(sess);
            var res = DatabaseManager.Resources.FindBySession(sess);
            _BulletCharge _charge = new()
            {
                oil = res.oil,
                bullet = res.bullet,
            level = res.level,
            weaponMaterial1 = res.weaponMaterial1,
            weaponMaterial2 = res.weaponMaterial2,
            weaponMaterial3 = res.weaponMaterial3,
            weaponMaterial4 = res.weaponMaterial4,
            chip = res.chip,
            world = user.worldState,
             };

            return _charge;
        }

    }

    public class _BulletCharge
    {
        public string bullet { get; set; }
        public string chip { get; set; }
        public string level { get; set; }
        public string oil { get; set; }
        public string weaponMaterial1 { get; set; }
        public string weaponMaterial2 { get; set; }
        public string weaponMaterial3 { get; set; }
        public string weaponMaterial4 { get; set; }
        public int world { get; set; }
    }

    public class BulletChargeResult
    {

    }
}