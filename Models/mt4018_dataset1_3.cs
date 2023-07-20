using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetECINo.Models
{
    public class mt4018_dataset1_3
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public int ecino{ get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
