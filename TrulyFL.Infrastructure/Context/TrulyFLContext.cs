using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Domain.Entity;
using TrulyFL.Infrastructure.Configurations;

namespace TrulyFL.Infrastructure.Context
{
    public class TrulyFLContext : DbContext
    {
        public TrulyFLContext(DbContextOptions<TrulyFLContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingAmenity> ListingAmenities { get; set; }
        public DbSet<ListingPhoto> ListingPhotos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply tất cả configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ListingConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new AmenityConfiguration());
            modelBuilder.ApplyConfiguration(new ListingAmenityConfiguration());
            modelBuilder.ApplyConfiguration(new ListingPhotoConfiguration());

            // Cấu hình khóa chính cho bảng trung gian
            modelBuilder.Entity<ListingAmenity>()
                .HasKey(la => new { la.ListingId, la.AmenityId });
        }
    }
}