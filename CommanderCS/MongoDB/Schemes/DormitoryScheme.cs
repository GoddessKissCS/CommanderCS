﻿using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class DormitoryScheme
    {
        public ObjectId Id { get; set; }
        public int Uno { get; set; }
        public Dictionary<string, int> DormitoryInfo { get; set; }
        public Dormitory.Resource DormitoryResource { get; set; }
        public Dictionary<string, int> ItemNormal { get; set; }
        public Dictionary<string, int> ItemAdvanced { get; set; }
        public Dictionary<string, int> ItemWallpaper { get; set; }
        public Dictionary<string, int> CostumeBody { get; set; }
        public Dictionary<string, List<string>> CostumeHead { get; set; }
    }
}