using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class ListingPhoto : BaseEntity
    {
        public Guid ListingId { get; set; }
        public string PhotoURL { get; set; }

        // Khóa ngoại
        public Listing Listing { get; set; }
    }

}
