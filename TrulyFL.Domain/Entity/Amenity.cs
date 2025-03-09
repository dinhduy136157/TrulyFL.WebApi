using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class Amenity : BaseEntity
    {
        public string AmenityName { get; set; }

        // Quan hệ nhiều-nhiều với Listings
        public ICollection<ListingAmenity> ListingAmenities { get; set; }
    }

}
