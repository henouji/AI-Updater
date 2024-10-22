using AI_Updater.Repositories.Contracts;
using AI_Updater.SqlModels;
using Microsoft.EntityFrameworkCore;

namespace AI_Updater.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AIContext _context;
        public UserRepository(AIContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers(int page = 1)
        {
            int take = 10;
            return this._context.Users.Skip(take * (page - 1)).Take(take * page);
        }

        public async Task<User> GetUserAsync(int id)
        {
            var result = await this._context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null) { return  result; }
            return new User();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            await this._context.Users.AddAsync(user);
            var result = await this._context.SaveChangesAsync();
            return result > 0;
        }
    }
}
