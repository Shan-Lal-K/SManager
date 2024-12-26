using STUDMANAG.DTO;

namespace STUDMANAG.Services.RoleAspUserDetailsService
{
    public interface IRoleBasedUserDetailsService
    {
        Task<int> CreateRoleUser(AspUserRoleDetailsDto Dto);
        Task<int> UpdateRoleUser(AspUserRoleDetailsDto Dto);
        Task<bool> DeleteRoleUser(int Id);
        Task<List<AspUserRoleDetailsDto>> GetAllRolesByUser(string UserId);
        Task<List<AspUserRoleDetailsDto>> GetAllUserByRoles(int RoleId);
    }
}
