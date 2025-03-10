using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Infrastructure.Context;
using TrulyFL.Infrastructure.Repositories.Implementations;
using TrulyFL.Infrastructure.Repositories.Interfaces;

namespace TrulyFL.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TrulyFLContext _context;

        public UnitOfWork(TrulyFLContext context)
        {
            _context = context;
            AmenityRepository = new AmenityRepository(_context);
            BookingRepository = new BookingRepository(_context);
            ListingAmenityRepository = new ListingAmenityRepository(_context);
            ListingPhotoRepository = new ListingPhotoRepository(_context);
            ListingRepository = new ListingRepository(_context);
            MessageRepository = new MessageRepository(_context);
            PaymentRepository = new PaymentRepository(_context);
            ReviewRepository = new ReviewRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public IAmenityRepository AmenityRepository { get; }
        public IBookingRepository BookingRepository { get; }
        public IListingAmenityRepository ListingAmenityRepository { get; }
        public IListingPhotoRepository ListingPhotoRepository { get; }
        public IListingRepository ListingRepository { get; }

        public IMessageRepository MessageRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IUserRepository UserRepository { get; }

        //public IUserRepository UserRepository => throw new NotImplementedException();

        //public IRoleRepository RoleRepository => throw new NotImplementedException();

        public void Dispose()
        {
            _context.Dispose();
        }

        public override bool Equals(object? obj)
        {
            return obj is UnitOfWork work &&
                   EqualityComparer<TrulyFLContext>.Default.Equals(_context, work._context);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
