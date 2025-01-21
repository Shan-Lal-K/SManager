using AutoMapper;
using Microsoft.EntityFrameworkCore;
using STUDMANAG.DTO;
using STUDMANAG.Modal;
using STUDMANAG.SContext;

namespace STUDMANAG.Services.ExamManageService
{
    public class ExamManagmentService : IExamManagmentService
    {
        private readonly IMapper _mapper;
        private readonly SDbcontext _dbContext;
        public ExamManagmentService(IMapper mapper, SDbcontext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task<int> CreateExam(ExamDto dto)
        {
            try
            {
                var InsertData = _mapper.Map<Exam>(dto);
                _dbContext.Exams.Add(InsertData);
                var Id = InsertData.Id;
                return Task.FromResult(Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error Found", ex.InnerException);
            }
        }

        public Task<ExamDto> GetExamById(int Examid)
        {
            try
            {
                var examDetail = _mapper.Map<ExamDto>(_dbContext.Exams.FindAsync(Examid));
                if (examDetail != null)
                {
                    return Task.FromResult(examDetail);
                }
                else
                {
                    throw new InvalidOperationException("No data found to the corresponding Id");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error Found", ex.InnerException);
            }
        }
        public Task<List<ExamDto>> GetAllExams()
        {
            try
            {
                var ReturnList = _mapper.Map<List<ExamDto>>(_dbContext.Exams.ToListAsync());
                if (ReturnList == null)
                {
                    throw new InvalidOperationException("No data found");
                }
                return Task.FromResult(ReturnList);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error Found ", ex.InnerException);
            }
        }

        public Task<int> UpdateExam(ExamDto dto)
        {
            try
            {
                var UpdateData = _mapper.Map<Exam>(dto);
                return Task.FromResult(UpdateData.Id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error ", ex.InnerException);
            }
        }

        public Task<bool> DeleteExam(int Examid)
        {
            try
            {
                var DeletedData = _mapper.Map<ExamDto>(_dbContext.Exams.FindAsync(Examid));
                if (DeletedData == null)
                {
                    throw new InvalidOperationException("No data found to Delete");
                }
                DeletedData.IsDeleted = true;
                DeletedData.DeletedTime = DateTime.UtcNow;
                DeletedData.DeletedId = "SFSFSFSFSFSFS";
                UpdateExam(DeletedData);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error found");
            }
        }
    }
}
