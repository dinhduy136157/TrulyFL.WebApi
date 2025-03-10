using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Application.Services.Interfaces;
using TrulyFL.Domain.Entity;
using TrulyFL.Infrastructure.UnitOfWorks;


namespace TrulyFL.Application.Services.Implementations
{
    public class UserServices : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _unitOfWork.UserRepository.DeleteAsync(user);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByIdAsync(Guid id) => await _unitOfWork.UserRepository.GetByIdAsync(id);


        public async Task UpdateUserAsync(User user)
        {
            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
