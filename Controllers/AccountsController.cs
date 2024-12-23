using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;
using STUDMANAG.Services.AccountsService;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly SDbcontext _context;
        public AccountsController(IAccountsService accountsService_, SDbcontext context_)
        {
            _context = context_;
            _accountsService = accountsService_;
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
            AspUsers data = new AspUsers();
            return Ok(data);
        }
    }
}
