using STUDMANAG.DTO;

namespace STUDMANAG.Services.AccountsService
{
    public class AccountsServices : IAccountsService
    {
        public Task<int> Login(LoginDto loginDto)
        {
            int result = 0;
            return Task.FromResult(result);
        }
        public Task<int> AccountCreation(AspUsersDto AspUsersDto)
        {
            int i = 0;
            return Task.FromResult(i);
        }
        public Task<string> RefreshToken(LoginDto loginDto)
        {
            var data = "DSDSDSDSDSD%$$$%%%";
            return Task.FromResult(data);
        }
    }
}
