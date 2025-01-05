using STUDMANAG.DTO;

namespace STUDMANAG.Services.PrincipalManagmentService
{
    public interface IPrincipalService
    {
        Task<int> CreatePrincipal (PrincipalDto dto);
        Task<int> UpdatePrincipal (PrincipalDto dto);
        Task<int> DeletePrincipal (int principalId);
        Task<PrincipalDto> GetPrincipalById (int principalId);
        Task<List<PrincipalDto>> GetAll ();
    }
}
