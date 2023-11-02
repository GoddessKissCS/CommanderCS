using static StellarGKLibrary.Protocols.UserInformationResponse;

namespace StellarGKLibrary.Utils
{
    public static class Misc
    {
        public static string[] Badwords = {
            "/", ".", "=", "Mod", "Admin", "Owner", "_", "?", "&", "$", "!",
        };

        public static bool NameCheck(string username)
        {
            var name = username.ToLower();
            bool isBadWord = Badwords.Any(name.Contains);
            return isBadWord;
        }


        public static int GetVipRechargeCount(List<VipRechargeData> vipRechargedata, int key)
        {
            VipRechargeData matchingItem = vipRechargedata.FirstOrDefault(item => item.idx == key);

            return matchingItem.count;
        }

        public static List<VipRechargeData> UpdateVipRechargeCount(List<VipRechargeData> vipRechargedata, int key, int count)
        {
            int index = vipRechargedata.FindIndex(item => item.idx == key);

            if (index != null)
            {
                vipRechargedata[index].count = count;
            }

            return vipRechargedata;
        }

    }
}