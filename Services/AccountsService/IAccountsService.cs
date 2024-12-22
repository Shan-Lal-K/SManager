using STUDMANAG.DTO;

namespace STUDMANAG.Services.AccountsService
{
    public interface IAccountsService
    {
        Task<int> Login(LoginDto loginDto);
        Task<int> AccountCreation(AspUsersDto Dto);
        Task<string> RefreshToken(LoginDto loginDto);
    }
}
