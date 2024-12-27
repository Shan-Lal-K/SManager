using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.SchoolManagmentService
{
    public class SchoolManagmentServices : ISchoolManagmentService
    {
        private readonly IMapper _mapper;
        private readonly SDbcontext _sdbContext;
        public SchoolManagmentServices(IMapper mapper_, SDbcontext sdbContext_)
        {
            _mapper = mapper_;
            _sdbContext = sdbContext_;
        }

        public Task<int> CreateSchool(SchoolDto SDto)
        {
            try
            {
                var InsertData = _mapper.Map<SchoolEntity>(SDto);
                _sdbContext.Schools.Add(InsertData);
                _sdbContext.SaveChanges();
                var Id = InsertData.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex);
            }
        }

        public Task<int> UpdateSchool(SchoolDto SDto)
        {
            try
            {
                var UpdateData = _mapper.Map<SchoolEntity>(SDto);
                _sdbContext.Schools.Update(UpdateData);
                _sdbContext.SaveChanges();
                var UpdateDataId = UpdateData.Id;
                return Task.FromResult(UpdateDataId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex);
            }
        }

        public Task<int> DeleteSchool(int Id)
        {
            try
            {
                var GetData = GetSchoolById(Id).Result;
                GetData.IsDeleted = true;
                GetData.DeletedTime = DateTime.UtcNow;
                GetData.DeletedId = "SGSFSFSFSFFSFSFSF";
                var UpdateData = UpdateSchool(GetData);
                return Task.FromResult(GetData.Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex);
            }
        }

        public Task<SchoolDto> GetSchoolById(int Id)
        {
            try
            {
                var Data = _sdbContext.Schools.FindAsync(Id).Result;
                var ReturnData = _mapper.Map<SchoolDto>(Data);
                return Task.FromResult(ReturnData);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Errors Encourtered", ex.InnerException);
            }
        }
        public Task<List<SchoolDto>> GetAllSchool()
        {
            try
            {
                var EntityData = _sdbContext.Schools.ToListAsync();
                var DataToReturn = _mapper.Map<List<SchoolDto>>(EntityData);
                return Task.FromResult(DataToReturn);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Errors Encourtered", ex.InnerException);
            }
        }

    }
}
