using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class ListingAmenity
    {
        public Guid ListingId { get; set; }
        public Guid AmenityId { get; set; }

        // Khóa ngoại
        public Listing Listing { get; set; }
        public Amenity Amenity { get; set; }
    }

}
