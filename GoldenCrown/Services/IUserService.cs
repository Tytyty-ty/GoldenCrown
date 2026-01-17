using GoldenCrown.DTOs;

namespace GoldenCrown.Services
{
    public interface IUserService
    {
        Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
        Task<Result> RegisterAsync(RegisterRequest request);
    }
}