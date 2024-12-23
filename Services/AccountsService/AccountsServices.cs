using AutoMapper;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.AccountsService
{
    public class AccountsServices : IAccountsService
    {
        private readonly SDbcontext _dbContext;
        private readonly IMapper _mapper;
        public AccountsServices(SDbcontext dbcontext_, IMapper mapper_)
        {
            _dbContext = dbcontext_;
            _mapper = mapper_;
        }
        public Task<int> Login(LoginDto loginDto)
        {
            //if (loginDto == null)
            //{
            //    return Task.FromResult(0);
            //}
            //else
            //{
            //    var data = _dbContext.AspUsers.Where(x => x.UserName == loginDto.Username).FirstOrDefault();
            //    if (data != null)
            //    {

            //    }
            //}
            int result = 0;
            return Task.FromResult(result);
        }
        public Task<int> AccountCreation(AspUsersDto AspUsersDto)
        {
            var UserNameCheck = _dbContext.AspUsers.Where(x => x.UserName == AspUsersDto.UserName).FirstOrDefault();
            if (UserNameCheck != null)
            {
                return Task.FromResult(0);
            }
            else
            {
                var datatocreate = _mapper.Map<AspUsers>(AspUsersDto);
                _dbContext.AspUsers.Add(datatocreate);
                return Task.FromResult(1);
            }

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
