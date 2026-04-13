using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Ro;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCS.Packets.Handlers.Gacha;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.BulletCharge)]
    public class BulletCharge : BaseMethodHandler<BulletChargeResult>
    {
        public override object Handle(BulletChargeResult request)
        {
            GameProfileScheme User = GetUserGameProfile();

            int bullets = RemoteObjectManager.instance.regulation.userLevelDtbl.Find(x => x.level == User.Resources.level).maxBullet;

            Dictionary<string, GachaInformationResponse> gacha = User.GachaInformation.ToDictionary(kvp => kvp.Key, kvp => GachaInformation.ToResponse(kvp.Value));

            Library.Protocols.ResourceRecharge resource = new()
            {
                bulletData = new()
                {
                    cnt = User.Resources.bullet,
                    remain = bullets,
                },
                oilData = new()
                {
                    cnt = User.Resources.oil,
                    remain = User.Resources.oil,
                },
                skillData = new()
                {
                    remain = 0, // NO IDEA ABOUT THOSE TWOS
                    cnt = 0,
                },
                chip = new()
                {
                    remain = User.Resources.chip,
                    cnt = User.Resources.chip,
                },
                weaponMaterialData1 = new()
                {
                    cnt = User.Resources.weaponMaterial1,
                    remain = User.Resources.weaponMaterial1,
                },
                weaponMaterialData2 = new()
                {
                    cnt = User.Resources.weaponMaterial2,
                    remain = User.Resources.weaponMaterial2,
                },
                weaponMaterialData3 = new()
                {
                    cnt = User.Resources.weaponMaterial3,
                    remain = User.Resources.weaponMaterial3,
                },
                weaponMaterialData4 = new()
                {
                    cnt = User.Resources.weaponMaterial4,
                    remain = User.Resources.weaponMaterial4,
                },
                worldState = User.WorldState,
                gacha = gacha
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