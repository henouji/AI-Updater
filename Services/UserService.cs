using AI_Updater.Models;
using AI_Updater.Repositories;
using AI_Updater.Repositories.Contracts;
using AI_Updater.Services.Contracts;
using AI_Updater.SqlModels;

namespace AI_Updater.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<_User> GetUsers()
        {
            List<_User> users = [];
            foreach (User user in _userRepository.GetAllUsers())
            {
                users.Add(GetFromSqlModel(user));
            };
            return users;
        }

        public async Task<_User> GetUserByIdAsync(int id)
        {
            return GetFromSqlModel(await _userRepository.GetUserAsync(id));
        }

        public async Task<bool> CreateUserAsync(_User user)
        {
            return await _userRepository.CreateUserAsync(user.GetSqlModel());
        }

        private static _User GetFromSqlModel(User sqlUSer)
        {
            return new _User()
            {
                Id = sqlUSer.Id,
                Name = sqlUSer.Name
            };
        }
}
}
