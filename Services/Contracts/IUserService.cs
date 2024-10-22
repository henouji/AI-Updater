using AI_Updater.Models;

namespace AI_Updater.Services.Contracts
{
    public interface IUserService
    {
        public List<_User> GetUsers();
        public Task<_User> GetUserByIdAsync(int id);
        public Task<bool> CreateUserAsync(_User user);
    }
}
