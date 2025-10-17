using ConferenceRoomAndDeskBookingApplication.Models;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomAndDeskBookingApplication.Models;

namespace ConferenceRoomAndDeskBookingApplication.Data
{
    public class RoomDeskBookingDbContext : DbContext
    {
        public RoomDeskBookingDbContext(DbContextOptions<RoomDeskBookingDbContext> options)
            : base(options)
        {
        }

        // User Management
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        // Location Hierarchy
        public DbSet<Location> Locations { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }

        // Resource Management
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Desk> Desks { get; set; }

        // Booking
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingCheckIn> BookingCheckIns { get; set; }

        // Events
        public DbSet<Event> Events { get; set; }

        // Notifications
        public DbSet<BroadcastNotification> BroadcastNotifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        // Analytics & Stats
        public DbSet<UserBookingStats> UserBookingStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========================================
            // USER
            // ========================================
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.EmployeeId).IsUnique();

                entity.HasOne(u => u.Location)
                    .WithMany(l => l.Users)
                    .HasForeignKey(u => u.LocationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(u => u.Department)
                    .WithMany(d => d.Users)
                    .HasForeignKey(u => u.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(u => u.Bookings)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Notifications)
                    .WithOne(n => n.User)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.BookingStats)
                    .WithOne(s => s.User)
                    .HasForeignKey<UserBookingStats>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ========================================
            // DEPARTMENT
            // ========================================
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasMany(d => d.Users)
                    .WithOne(u => u.Department)
                    .HasForeignKey(u => u.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ========================================
            // LOCATION HIERARCHY
            // ========================================
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasMany(l => l.Buildings)
                    .WithOne(b => b.Location)
                    .HasForeignKey(b => b.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(l => l.Users)
                    .WithOne(u => u.Location)
                    .HasForeignKey(u => u.LocationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(l => l.Resources)
                    .WithOne(r => r.Location)
                    .HasForeignKey(r => r.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasOne(b => b.Location)
                    .WithMany(l => l.Buildings)
                    .HasForeignKey(b => b.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(b => b.Floors)
                    .WithOne(f => f.Building)
                    .HasForeignKey(f => f.BuildingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(b => b.Resources)
                    .WithOne(r => r.Building)
                    .HasForeignKey(r => r.BuildingId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.HasOne(f => f.Location)
                    .WithMany()
                    .HasForeignKey(f => f.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(f => f.Building)
                    .WithMany(b => b.Floors)
                    .HasForeignKey(f => f.BuildingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(f => f.Resources)
                    .WithOne(r => r.Floor)
                    .HasForeignKey(r => r.FloorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ========================================
            // RESOURCE MANAGEMENT
            // ========================================
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasOne(r => r.Location)
                    .WithMany(l => l.Resources)
                    .HasForeignKey(r => r.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(r => r.Building)
                    .WithMany(b => b.Resources)
                    .HasForeignKey(r => r.BuildingId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(r => r.Floor)
                    .WithMany(f => f.Resources)
                    .HasForeignKey(r => r.FloorId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(r => r.Room)
                    .WithOne(rm => rm.Resource)
                    .HasForeignKey<Room>(rm => rm.ResourceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Desk)
                    .WithOne(d => d.Resource)
                    .HasForeignKey<Desk>(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(r => r.Bookings)
                    .WithOne(b => b.Resource)
                    .HasForeignKey(b => b.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasOne(rm => rm.Resource)
                    .WithOne(r => r.Room)
                    .HasForeignKey<Room>(rm => rm.ResourceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Desk>(entity =>
            {
                entity.HasOne(d => d.Resource)
                    .WithOne(r => r.Desk)
                    .HasForeignKey<Desk>(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ========================================
            // BOOKING
            // ========================================
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(u => u.Bookings)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Resource)
                    .WithMany(r => r.Bookings)
                    .HasForeignKey(b => b.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.CheckIn)
                    .WithOne(c => c.Booking)
                    .HasForeignKey<BookingCheckIn>(c => c.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(b => b.Notifications)
                    .WithOne(n => n.Booking)
                    .HasForeignKey(n => n.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Indexes for quick lookup
                entity.HasIndex(b => b.Date);
                entity.HasIndex(b => b.Status);
                entity.HasIndex(b => new { b.ResourceId, b.Date, b.Status });
            });

            // ========================================
            // BOOKING CHECK-IN
            // ========================================
            modelBuilder.Entity<BookingCheckIn>(entity =>
            {
                entity.HasOne(c => c.Booking)
                    .WithOne(b => b.CheckIn)
                    .HasForeignKey<BookingCheckIn>(c => c.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ========================================
            // EVENT
            // ========================================
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Building)
                    .WithMany()
                    .HasForeignKey(e => e.BuildingId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Floor)
                    .WithMany()
                    .HasForeignKey(e => e.FloorId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Notifications)
                    .WithOne()
                    .HasForeignKey("EventId")
                    .OnDelete(DeleteBehavior.Cascade);

                // Index for date queries
                entity.HasIndex(e => e.Date);
            });

            // ========================================
            // NOTIFICATIONS
            // ========================================
            modelBuilder.Entity<BroadcastNotification>(entity =>
            {
                entity.HasOne(n => n.Location)
                    .WithMany()
                    .HasForeignKey(n => n.LocationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(n => n.Department)
                    .WithMany()
                    .HasForeignKey(n => n.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(n => n.CreatedAt);
                entity.HasIndex(n => n.Status);
            });

            modelBuilder.Entity<UserNotification>(entity =>
            {
                entity.HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(n => n.Booking)
                    .WithMany(b => b.Notifications)
                    .HasForeignKey(n => n.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(n => n.Location)
                    .WithMany()
                    .HasForeignKey(n => n.LocationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(n => n.Department)
                    .WithMany()
                    .HasForeignKey(n => n.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(n => n.UserId);
                entity.HasIndex(n => n.Status);
                entity.HasIndex(n => n.CreatedAt);
            });

            // ========================================
            // ANALYTICS & STATS
            // ========================================

            // UserBookingStats
            modelBuilder.Entity<UserBookingStats>(entity =>
            {
                entity.HasOne(s => s.User)
                    .WithOne(u => u.BookingStats)
                    .HasForeignKey<UserBookingStats>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(s => s.UserId).IsUnique();
            });
        }
    }
}