using GuYou.Repositories.DTOs;

namespace GuYou.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponse>> GetAllRolesAsync();
        Task<RoleResponse> GetRoleByNameAsync(string roleName);
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> UpdateRoleAsync(UpdateRoleDTO role);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<bool> AddUserToRoleAsync(UserRoleDTO userRole);
        Task<bool> RemoveUserFromRoleAsync(UserRoleDTO userRole);
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<List<UserRoleDTO>> GetAllUserRoleAsync();

    }
}
