using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAppServices.Entities
{
    public class EntityBase
    {
        public ObjectId _id { get; set; }
    }
}
