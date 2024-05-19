using Hotel.Data.Models;
using Hotel.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Configurations.Hotel;

namespace Hotel.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<RoomTypeEntity> RoomTypes { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<GuestEntity> Guests { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);            
            ApplyConfigurations(modelBuilder);            
        }
        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        }
    }
}
