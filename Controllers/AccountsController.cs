using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;
using STUDMANAG.Services.AccountsService;
using System.Security.Cryptography;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly SDbcontext _context;
        private readonly IMapper _mapper;
        public AccountsController(IAccountsService accountsService_, SDbcontext context_, IMapper mapper_)
        {
            _context = context_;
            _accountsService = accountsService_;
            _mapper = mapper_;
        }
        [HttpPost]
        public async Task<IActionResult> AccountsCreation(AspUsersDto Dto)
        {
            if (_context.AspUsers.Any(x => x.UserName == Dto.UserName))
            {
                return BadRequest("User Already Exists");
            }
            if (string.IsNullOrWhiteSpace(Dto.Password))
            {
                return BadRequest("Password Is Required");
            }
            PasswordHashing(Dto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            var InsertData = _mapper.Map<AspUsers>(Dto);
            InsertData.PasswordHash = PasswordHash;
            InsertData.PasswordSalt = PasswordSalt;
            _context.AspUsers.Add(InsertData);
            _context.SaveChanges();
            //AspUsers data = new AspUsers();
            return Ok("Account Created");
        }

        private void PasswordHashing(string Password, out byte[] Hash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                Hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
    }
}
