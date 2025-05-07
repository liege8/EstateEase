using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EstateEase.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public int PropertyId { get; set; }
        public Property? Property { get; set; }

        [Required]
        public string ClientId { get; set; } = null!;
        public IdentityUser? Client { get; set; }

        [Required]
        public string AgentId { get; set; } = null!;
        public IdentityUser? Agent { get; set; }

        [Required]
        public string Status { get; set; } = null!; // Pending, Confirmed, Cancelled
        public string? Notes { get; set; }
    }
}