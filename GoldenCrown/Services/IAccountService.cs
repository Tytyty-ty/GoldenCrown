namespace GoldenCrown.Services
{
    public interface IAccountService
    {
        Task<Result> CreateAccountAsync(string login);
    }
}
