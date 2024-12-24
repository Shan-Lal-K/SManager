using STUDMANAG.DTO;

namespace STUDMANAG.Services.RolesService
{
    public interface IRolesService
    {
        Task<int> RoleCreation(RoleDto Dto);
        Task<int> RoleDelete(int Id);
        Task<int> RoleUpdate(RoleDto Dto);
        Task<RoleDto> GetRoleById(int Id);
        Task<List<RoleDto>> GetRoles();
    }
}
