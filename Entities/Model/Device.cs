using System.ComponentModel.DataAnnotations;

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
