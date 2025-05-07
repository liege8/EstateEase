using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EstateEase.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;

        public int PropertyId { get; set; }
        public Property? Property { get; set; }

        [Required]
        public string ClientId { get; set; } = null!;
        public IdentityUser? Client { get; set; }

        [Required]
        public string AgentId { get; set; } = null!;
        public IdentityUser? Agent { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsResolved { get; set; }
    }
}