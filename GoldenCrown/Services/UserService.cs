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

        public async Task<Result> RegisterAsync(RegisterRequest request)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.Login == request.Login);

            if (existing != null)
            {
                return Result.Failure(errorCode: ErrorCodes.Conflict, errorMessage: "The user is existing.");
            }

            var user = new User
            {
                Login = request.Login,
                Name = request.Name,
                Password = request.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await _accountService.CreateAccountAsync(user.Login);

            return Result.Success();
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == request.Login && u.Password == request.Password);

            if (user == null)
            {
                return Result<LoginResponse>.Failure(errorCode: ErrorCodes.Unauthorized, errorMessage: "Invalid login or password.");
            }

            var session = new Session
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };

            var existingSession = await _context.Sessions.FirstOrDefaultAsync(s => s.UserId == user.Id);

            if (existingSession != null)
            {
                _context.Sessions.Remove(existingSession);
            }

            _context.Sessions.Add(session);

            await _context.SaveChangesAsync();

            return Result<LoginResponse>.Success(new LoginResponse(session.Token));
        }

    }


}
