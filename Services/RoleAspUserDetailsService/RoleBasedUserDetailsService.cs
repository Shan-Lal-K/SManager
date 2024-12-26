using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.RoleAspUserDetailsService
{
    public class RoleBasedUserDetailsService : IRoleBasedUserDetailsService
    {
        private readonly IMapper _mapper;
        private readonly SDbcontext _context;

        public RoleBasedUserDetailsService(IMapper mapper, SDbcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<int> CreateRoleUser(AspUserRoleDetailsDto Dto)
        {
            //AspUserRoleDetailsEntity InsertData = new AspUserRoleDetailsEntity();
            try
            {
                var InsertData = _mapper.Map<AspUserRoleDetailsEntity>(Dto);
                var Data = _context.AspUserRoleDetails.Add(InsertData);
                _context.SaveChanges();
                var Id = InsertData.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Some Error Encountered ", ex);
            }
        }

        public Task<int> UpdateRoleUser(AspUserRoleDetailsDto Dto)
        {
            try
            {
                var UpdateData = _mapper.Map<AspUserRoleDetailsEntity>(Dto);
                var Updated = _context.AspUserRoleDetails.Update(UpdateData);
                _context.SaveChanges();
                var Id = UpdateData.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<bool> DeleteRoleUser(int Id)
        {
            var DeletionData = _mapper.Map<AspUserRoleDetailsDto>(_context.AspUserRoleDetails.FindAsync(Id).Result);
            if (DeletionData != null)
            {
                DeletionData.IsDeleted = true;
                DeletionData.DeletedTime = DateTime.UtcNow;
                DeletionData.DeletedId = "ASPASPASPASPASPAS";
                UpdateRoleUser(DeletionData);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<List<AspUserRoleDetailsDto>> GetAllRolesByUser(string UserId)
        {
            try
            {
                var Data = _context.AspUserRoleDetails.ToListAsync().Result.Where(x => x.AspUserId == UserId);
                var ReturnList = _mapper.Map<List<AspUserRoleDetailsDto>>(Data);
                return Task.FromResult(ReturnList);
            }
            catch (Exception ex)
            {
                throw new Exception("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<List<AspUserRoleDetailsDto>> GetAllUserByRoles(int RoleId)
        {
            try
            {
                var Data = _context.AspUserRoleDetails.ToListAsync().Result.Where(x => x.AspRoleId == RoleId);
                var ReturnList = _mapper.Map<List<AspUserRoleDetailsDto>>(Data);
                return Task.FromResult(ReturnList);
            }
            catch (Exception ex)
            {
                throw new Exception("Some Error Encountered", ex.InnerException);
            }
        }
    }
}
