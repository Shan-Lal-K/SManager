using STUDMANAG.DTO;

namespace STUDMANAG.Services.ExamManageService
{
    public interface IExamManagmentService
    {
        Task<int> CreateExam(ExamDto dto);
        Task<ExamDto> GetExamById(int Examid);
        Task<List<ExamDto>> GetAllExams();
        Task<bool> DeleteExam(int Examid);
        Task<int> UpdateExam(ExamDto dto);
    }
}
