using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.StudentManage
{
    public class StudentManagmentService : IStudentManagmentService
    {
        private readonly SDbcontext _dbContext;
        private readonly IMapper _mapper;
        public StudentManagmentService(SDbcontext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public Task<int> SaveStudent(StudentDto dto)
        {
            try
            {
                var InsertData = _mapper.Map<StudentEntity>(dto);
                _dbContext.StudentEntities.Add(InsertData);
                _dbContext.SaveChanges();
                var Id = InsertData.Id;
                return Task.FromResult(Id);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }

        public Task<StudentDto> GetStudentById(int studentId)
        {
            try
            {
                var studentDto = _dbContext.StudentEntities.FindAsync(studentId);
                var returnData = _mapper.Map<StudentDto>(studentDto);
                return Task.FromResult(returnData);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }
        public Task<int> UpdateStudent(StudentDto dto)
        {
            try
            {
                var UpdateData = _mapper.Map<StudentEntity>(dto);
                _dbContext.StudentEntities.Update(UpdateData);
                return Task.FromResult(UpdateData.Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }
        public Task<bool> DeleteStudent(int studentId)
        {
            try
            {
                var Data = GetStudentById(studentId);
                if (Data != null)
                {
                    Data.Result.IsDeleted = true;
                    Data.Result.DeletedId = "SGSGSGSGS";
                    Data.Result.DeletedTime = DateTime.UtcNow;
                    var DeleteData = _mapper.Map<StudentDto>(Data);
                    UpdateStudent(DeleteData);
                    _dbContext.SaveChanges();
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }
        public Task<List<StudentDto>> GetAllStudents()
        {
            try
            {
                var returnList = _mapper.Map<List<StudentDto>>(_dbContext.StudentEntities.ToListAsync());
                if (returnList == null)
                {
                    throw new InvalidOperationException("No Data Found");
                }
                return Task.FromResult(returnList);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Some Error Encountered", ex.InnerException);
            }
        }
    }
}
