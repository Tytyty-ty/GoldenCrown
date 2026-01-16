using GoldenCrown.DTOs;

namespace GoldenCrown.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterRequest request);
    }
}