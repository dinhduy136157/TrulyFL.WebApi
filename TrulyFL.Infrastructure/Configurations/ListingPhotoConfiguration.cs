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
    public class ListingPhotoConfiguration : IEntityTypeConfiguration<ListingPhoto>
    {
        public void Configure(EntityTypeBuilder<ListingPhoto> builder)
        {
            builder.ToTable("ListingPhotos");

            builder.HasKey(lp => lp.Id);

            builder.Property(lp => lp.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(lp => lp.PhotoURL)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(lp => lp.Listing)
                .WithMany(l => l.Photos)
                .HasForeignKey(lp => lp.ListingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
