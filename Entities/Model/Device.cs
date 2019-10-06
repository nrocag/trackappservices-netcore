using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Device : EntityBase
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Serie { get; set; }

        public int Category { get; set; }

        [Required]
        public bool StateDevice { get; set; }
    }
}
