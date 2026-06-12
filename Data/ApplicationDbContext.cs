using Microsoft.EntityFrameworkCore;
using EventEase.Models;

namespace EventEase.Data
{
    /// <summary>
    /// The central data context layer for the EventEase application.
    /// Manages the object-relational mapping configurations and cloud data storage behaviors.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// Part 3 Lookup Table addition for normalized event classification.
        /// </summary>
        public DbSet<EventType> EventTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure defensive schema restrictions for the Bookings-Venues relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany()
                .HasForeignKey(b => b.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure defensive schema restrictions for the Bookings-Events relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany()
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            // IMPROVEMENT: Enforce a default value for the new Availability column.
            // This safeguards pre-existing database records from failing due to missing data.
            modelBuilder.Entity<Venue>()
                .Property(v => v.Availability)
                .HasDefaultValue(true);

            // PART 3 IMPLEMENTATION: Seed predefined lookup categories dynamically.
            // Ensures the Azure SQL environment is instantly provisioned with immutable type categories.
            modelBuilder.Entity<EventType>().HasData(
                new EventType { EventTypeId = 1, Name = "Wedding 💍" },
                new EventType { EventTypeId = 2, Name = "Corporate Gala 💼" },
                new EventType { EventTypeId = 3, Name = "Live Concert 🎵" },
                new EventType { EventTypeId = 4, Name = "Art Exhibition 🎨" }
            );
        }
    }
}