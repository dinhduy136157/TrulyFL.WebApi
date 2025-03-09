using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Domain.Entity;
using TrulyFL.Infrastructure.Context;
using TrulyFL.Infrastructure.Repositories.Interfaces;

namespace TrulyFL.Infrastructure.Repositories.Implementations
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(TrulyFLContext context) : base(context)
        {
        }
    }
}
