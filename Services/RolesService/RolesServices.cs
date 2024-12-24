using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.RolesService
{
    public class RolesServices : IRolesService
    {
        private readonly IMapper _mapper;
        private readonly SDbcontext _dbContext;
        public RolesServices(IMapper mapper_, SDbcontext dbContext_)
        {
            _mapper = mapper_;
            _dbContext = dbContext_;
        }

        public Task<int> RoleCreation(RoleDto Dto)
        {
            try
            {
                var InsertionData = _mapper.Map<AspRoles>(Dto);
                _dbContext.AspRoles.Add(InsertionData);
                _dbContext.SaveChanges();
                int Id = InsertionData.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex);
            }
        }

        public Task<int> RoleDelete(int Id)
        {
            try
            {
                var role = _dbContext.AspRoles.FindAsync(Id).Result;
                role.DeletedId = "SHANALALALAA";
                role.IsDeleted = true;
                role.DeletedTime = DateTime.UtcNow;
                var DeleteData = _mapper.Map<RoleDto>(role);
                RoleUpdate(DeleteData);
                return Task.FromResult(role.Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex);
            }
        }
        public Task<int> RoleUpdate(RoleDto Dto)
        {
            try
            {
                var InsertData = _mapper.Map<AspRoles>(Dto);
                _dbContext.AspRoles.Update(InsertData);
                _dbContext.SaveChanges();
                return Task.FromResult(InsertData.Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex);
            }
        }

        public Task<RoleDto> GetRoleById(int Id)
        {
            try
            {
                var Data = _dbContext.AspRoles.FindAsync(Id).Result;
                var ReturnData = _mapper.Map<RoleDto>(Data);
                return Task.FromResult(ReturnData);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error Found", ex.InnerException);
            }
        }

        public async Task<List<RoleDto>> GetRoles()
        {
            try
            {
                var AllRoles = await _dbContext.AspRoles.ToListAsync();
                var rolesDto = _mapper.Map<List<RoleDto>>(AllRoles);
                return rolesDto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error Encountered");
            }
        }
    }
}
