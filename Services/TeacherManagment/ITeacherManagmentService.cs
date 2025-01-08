using STUDMANAG.DTO;

namespace STUDMANAG.Services.TeacherManagment
{
    public interface ITeacherManagmentService
    {
        Task<int> CreateTeacher(TeacherDto dto);
        Task<bool> UpdateTeacher(TeacherDto dto);
        Task<bool> DeleteTeacher(int TeacherId);
        Task<TeacherDto> GetTeacherById(int TeacherId);
        Task<List<TeacherDto>> GetAllTeacher();
    }
}
