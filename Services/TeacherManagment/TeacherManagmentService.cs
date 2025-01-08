using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.TeacherManagment
{
    public class TeacherManagmentService : ITeacherManagmentService
    {
        private readonly IMapper _mapper;
        private readonly SDbcontext _dbcontext;
        public TeacherManagmentService(IMapper mapper, SDbcontext dbContext)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
        }
        public Task<int> CreateTeacher(TeacherDto dto)
        {
            try
            {
                var InsertData = _mapper.Map<TeacherEntity>(dto);
                var r = _dbcontext.Teachers.Add(InsertData);
                var Id = InsertData.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<bool> DeleteTeacher(int TeacherId)
        {
            try
            {
                var DatatoDelete = GetTeacherById(TeacherId).Result;
                DatatoDelete.DeletedId = "SAMPLEIDFORDEVELOP";
                DatatoDelete.IsDeleted = true;
                DatatoDelete.DeletedTime = DateTime.UtcNow;
                var Data = _mapper.Map<TeacherDto>(DatatoDelete);
                UpdateTeacher(Data);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<List<TeacherDto>> GetAllTeacher()
        {
            try
            {
                var TeacherList = _dbcontext.Teachers.ToListAsync();
                var TeacherListDto = _mapper.Map<List<TeacherDto>>(TeacherList);
                return Task.FromResult(TeacherListDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public async Task<TeacherDto> GetTeacherById(int TeacherId)
        {
            if (TeacherId <= 0)
            {
                throw new ArgumentException("Teacher ID must be greater than zero.", nameof(TeacherId));
            }
            try
            {
                var TeacherData = await _dbcontext.Teachers.FindAsync(TeacherId);
                if (TeacherData == null)
                {
                    throw new KeyNotFoundException($"Teacher with ID {TeacherId} not found.");
                }
                var DataToReturn = _mapper.Map<TeacherDto>(TeacherData);
                return DataToReturn;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<bool> UpdateTeacher(TeacherDto dto)
        {
            try
            {
                var UpdateData = _mapper.Map<TeacherEntity>(dto);
                var r = _dbcontext.Teachers.Update(UpdateData);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }
    }
}
