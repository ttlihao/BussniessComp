using GuYou.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersByFullNameAsync(string fullName);
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUsesByIdAsync(string userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<string> GetUserEmailByIdAsync(string userId);
        Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
        Task<bool> UpdateUserAsync(User user);
        Task<string?> GetUserNameByIdAsync(object id);
        Task<Dictionary<string, string>> GetFullNamesByIdsAsync(IEnumerable<string> userIds);
    }
}
