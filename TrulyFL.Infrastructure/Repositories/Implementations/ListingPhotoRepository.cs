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
    public class ListingPhotoRepository : GenericRepository<ListingPhoto>, IListingPhotoRepository
    {
        public ListingPhotoRepository(TrulyFLContext context) : base(context)
        {
        }
    }
}
