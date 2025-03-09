using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class Booking : BaseEntity
    {
        public Guid GuestId { get; set; }
        public Guid ListingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        // Khóa ngoại
        public User Guest { get; set; }
        public Listing Listing { get; set; }
        public Review Review { get; set; }
        public Payment Payment { get; set; }
    }

}
