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
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.ToTable("Listings");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(l => l.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(l => l.Host)
                .WithMany(u => u.Listings)
                .HasForeignKey(l => l.HostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
