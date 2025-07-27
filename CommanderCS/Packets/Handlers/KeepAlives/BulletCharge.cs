using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.BulletCharge)]
    public class BulletCharge : BaseMethodHandler<BulletChargeResult>
    {
        public override object Handle(BulletChargeResult @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

            int bullets = Regulation.userLevelDtbl.Find(x => x.level == User.Resources.level).maxBullet;

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