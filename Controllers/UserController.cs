using AI_Updater.Models;
using AI_Updater.Services;
using AI_Updater.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AI_Updater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public List<_User> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpGet("{id}")]        
        public async Task<_User> GetUserAsync(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateUserAsync(_User user)
        {
            return await _userService.CreateUserAsync(user);
        }

        
    }
}
