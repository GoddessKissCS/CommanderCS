using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DormitoryUpgradeDataRow : DataRow
    {
        [JsonProperty("idx")]
        public List<string> goodsIdxs;

        [JsonProperty("value")]
        public List<int> goodsValue;

        private List<GoodsDataRow> _goods;

        [JsonProperty("floor")]
        public string floorId { get; private set; }

        [JsonProperty("level")]
        public int userLevel { get; private set; }

        [JsonProperty("immeCash")]
        public int immediateCash { get; private set; }

        [JsonProperty("prodTime")]
        public int productionTime { get; private set; }

        public List<GoodsDataRow> goods
        {
            get
            {
                if (_goods is null)
                {
                    _goods = new List<GoodsDataRow>();
                    for (int i = 0; i < goodsIdxs.Count; i++)
                    {
                        if (goodsIdxs[i] == "0")
                        {
                            _goods.Add(null);
                        }
                        else
                        {
                            _goods.Add(RemoteObjectManager.instance.regulation.goodsDtbl[goodsIdxs[i]]);
                        }
                    }
                }
                return _goods;
            }
        }

        public string GetKey()
        {
            return floorId;
        }
    }
}