using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Domain.Entity;

namespace TrulyFL.Infrastructure.Configurations
{
    public class ListingAmenityConfiguration : IEntityTypeConfiguration<ListingAmenity>
    {
        public void Configure(EntityTypeBuilder<ListingAmenity> builder)
        {
            builder.ToTable("ListingAmenities");

            builder.HasKey(la => new { la.ListingId, la.AmenityId });

            builder.HasOne(la => la.Listing)
                .WithMany(l => l.ListingAmenities)
                .HasForeignKey(la => la.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(la => la.Amenity)
                .WithMany()
                .HasForeignKey(la => la.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
