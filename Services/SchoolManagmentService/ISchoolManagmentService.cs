using STUDMANAG.DTO;

namespace STUDMANAG.Services.SchoolManagmentService
{
    public interface ISchoolManagmentService
    {
        Task<int> CreateSchool(SchoolDto SDto);
        Task<int> UpdateSchool(SchoolDto SDto);
        Task<int> DeleteSchool(int Id);
        Task<SchoolDto> GetSchoolById(int Id);
        Task<List<SchoolDto>> GetAllSchool();
    }
}
