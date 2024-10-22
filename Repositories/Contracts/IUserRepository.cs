using AI_Updater.SqlModels;

namespace AI_Updater.Repositories.Contracts
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers(int page = 1);
        public Task<User> GetUserAsync(int id);
        public Task<bool> CreateUserAsync(User user);
    }
}
