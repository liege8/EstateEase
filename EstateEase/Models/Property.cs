using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EstateEase.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SquareFootage { get; set; }
        public bool IsActive { get; set; }
        
        // Navigation properties
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; } = null!;
        
        public string? AgentId { get; set; }
        public IdentityUser? Agent { get; set; }  // Changed from ApplicationUser to IdentityUser
        
        public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
    }
}