using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Infrastructure.Repositories.Interfaces;

namespace TrulyFL.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IAmenityRepository AmenityRepository { get; }
        IBookingRepository BookingRepository { get; }
        IListingAmenityRepository ListingAmenityRepository { get; }
        IListingPhotoRepository ListingPhotoRepository { get; }
        IListingRepository ListingRepository { get; }

        IMessageRepository MessageRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangeAsync();

    }
}
