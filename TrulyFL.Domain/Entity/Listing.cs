using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class Listing : BaseEntity
    {
        public Guid HostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxGuests { get; set; }
        public int NumBedrooms { get; set; }
        public int NumBathrooms { get; set; }
        public int NumBeds { get; set; }
        public string ListingType { get; set; }
        public string Status { get; set; }

        // Khóa ngoại
        public User Host { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<ListingPhoto> Photos { get; set; }
        public ICollection<ListingAmenity> ListingAmenities { get; set; }
    }

}
