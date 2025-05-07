using EstateEase.Models;
using EstateEase.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace EstateEase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Inquiry> Inquiries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call base first to set up Identity tables
            base.OnModelCreating(builder);

            // Configure property decimal fields
            builder.Entity<Property>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Property>()
                .Property(p => p.SquareFootage)
                .HasColumnType("decimal(18,2)");

            // Configure Inquiry relationships with NoAction delete behavior
            builder.Entity<Inquiry>()
                .HasOne(i => i.Client)
                .WithMany()
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Inquiry>()
                .HasOne(i => i.Agent)
                .WithMany()
                .HasForeignKey(i => i.AgentId)
                .OnDelete(DeleteBehavior.NoAction);

            // If you have Appointment relationships to Users, configure them too
            // This is a guess since I haven't seen your Appointment class
            if (builder.Model.FindEntityType(typeof(Appointment)) != null)
            {
                var appointmentEntity = builder.Entity<Appointment>();

                // Check if these properties exist before configuring
                var properties = typeof(Appointment).GetProperties().Select(p => p.Name).ToList();

                if (properties.Contains("ClientId"))
                {
                    appointmentEntity
                        .HasOne(a => a.Client)
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction);
                }

                if (properties.Contains("AgentId"))
                {
                    appointmentEntity
                        .HasOne(a => a.Agent)
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.NoAction);
                }
            }
        }
    }
}