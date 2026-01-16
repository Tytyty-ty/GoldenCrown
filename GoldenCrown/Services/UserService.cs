using GoldenCrown.Data;
using GoldenCrown.DTOs;
using GoldenCrown.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenCrown.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;

        public UserService(ApplicationDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.Login == request.Login);

            if (existing != null)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            {
                return false;
            }

            // Создать нового пользователя
            var user = new User
            {
                Login = request.Login,
                Name = request.Name,
                Password = request.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await _accountService.CreateAccountAsync(user.Login);

            // Вернуть результат(успех / ошибка)
            return true;

        }
    }
}
