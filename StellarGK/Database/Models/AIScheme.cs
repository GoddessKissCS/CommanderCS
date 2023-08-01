using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace StellarGK.Database.Models
{
    public class AIScheme
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
