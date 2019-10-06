using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class EntityBase
    {
        [Key]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
    }
}
