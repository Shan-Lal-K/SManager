using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.PrincipalManagmentService
{
    public class PrincipalService : IPrincipalService
    {
        private readonly SDbcontext _dbContext;
        private readonly IMapper _mapper;
        public PrincipalService(SDbcontext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<int> CreatePrincipal(PrincipalDto dto)
        {
            try
            {
                var InsertEntity = _mapper.Map<PrincipalEntity>(dto);
                var r = _dbContext.Principals.Add(InsertEntity);
                var Id = InsertEntity.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<int> UpdatePrincipal(PrincipalDto dto)
        {
            try
            {
                var UpdateData = _mapper.Map<PrincipalEntity>(dto);
                var Update = _dbContext.Principals.Update(UpdateData);
                var Id = UpdateData.Id;
                return Task.FromResult(Id);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<int> DeletePrincipal(int principalId)
        {
            try
            {
                var Deletedata = GetPrincipalById(principalId).Result;
                if (Deletedata == null)
                {
                    throw new Exception("No Data Found Corresponding to this id");
                }
                else
                {
                    Deletedata.IsDeleted = true;
                    Deletedata.DeletedTime = DateTime.UtcNow;
                    Deletedata.DeletedId = "IDSAMPLEDATA";
                }
                
                var DtoConvert = _mapper.Map<PrincipalDto>(Deletedata);
                UpdatePrincipal(DtoConvert);
                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<PrincipalDto> GetPrincipalById(int principalId)
        {
            try
            {
                var GetData = _dbContext.Principals.FindAsync(principalId);
                var returnDto = _mapper.Map<PrincipalDto>(GetData);
                return Task.FromResult(returnDto);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<List<PrincipalDto>> GetAll()
        {
            try
            {
                var principalList = _mapper.Map<List<PrincipalDto>>(_dbContext.Principals.ToListAsync());
                return Task.FromResult(principalList);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }
    }
}
