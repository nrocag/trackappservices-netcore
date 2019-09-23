using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAppServices.Entities
{
    public class Device : EntityBase
    {   
        public string Name { get; set; }

        public string Description { get; set; }

        public string Serie { get; set; }

        public int Category { get; set; }

        public bool StateDevice { get; set; }
    }
}
