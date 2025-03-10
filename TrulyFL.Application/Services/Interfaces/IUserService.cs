using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulyFL.Domain.Entity;

namespace TrulyFL.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task UpdateUserAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
    }
}
