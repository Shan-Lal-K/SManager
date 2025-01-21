using STUDMANAG.DTO;

namespace STUDMANAG.Services.StudentManage
{
    public interface IStudentManagmentService
    {
        Task<int> SaveStudent(StudentDto dto);
        Task<StudentDto> GetStudentById(int studentId);
        Task<int> UpdateStudent(StudentDto dto);
        Task<bool> DeleteStudent(int studentId);
        Task<List<StudentDto>> GetAllStudents();
    }
}
