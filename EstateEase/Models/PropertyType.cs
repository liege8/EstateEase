using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateEase.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}