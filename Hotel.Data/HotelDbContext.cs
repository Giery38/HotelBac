using Hotel.Data.Configurations;
using Hotel.Data.Configurations.Hotel;
using Hotel.Data.Configurations.Users;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using Hotel.Data.Models.Users.Staff;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #region HOTEL
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<RoomTypeEntity> RoomTypes { get; set; }
        public DbSet<RoomViewEntity> RoomViews { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<ServiceTypeEntity> ServiceTypes { get; set; }
        #endregion
        #region USERS
        public DbSet<GenderEntity> Genders { get; set; }
        public DbSet<UserFeedbackEntity> Feedbacks { get; set; }
        public DbSet<UserFeedbackTypeEntity> FeedbackTypes { get; set; }
        public DbSet<GuestEntity> Guests { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<StaffEntity> Staff { get; set; }
        public DbSet<PositionTypeEntity> PositionTypes { get; set; }
        #endregion

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
            #region HOTEL
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoomViewConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            #endregion
            #region USER
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new PositionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new UserFeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new UserFeedbackTypeConfiguration());
            #endregion
        }
    }
}