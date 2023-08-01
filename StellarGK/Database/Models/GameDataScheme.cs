using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Models
{
    public class GameDataScheme
    {
        public int Id { get; set; }
        public Dictionary<string, List<WorldMapInformationResponse>> stages { get; set; }
        public Dictionary<string, int> medalData { get; set; }
        public Dictionary<string, int> foodData { get; set; }
        public Dictionary<string, int> groupItemData { get; set; }
        public Dictionary<string, int> ItemData { get; set; }
        public Dictionary<string, int> partData { get; set; }
        public Dictionary<string, int> eventResourceData { get; set; }
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }
        public List<UserInformationResponse.PreDeck> preDeck { get; set; }
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }
        public Dictionary<string, WeaponData> weaponList { get; set; }
        public List<int> completeRewardGroupIdx { get; set; }
        public Dictionary<string, List<int>> donHaveCommCostumeData { get; set; }
        public Dictionary<string, List<int>> sweepClearData { get; set; }
        public Dictionary<string, DiapatchCommanderInfo> dispatchedCommanders { get; set; }

    }
}
