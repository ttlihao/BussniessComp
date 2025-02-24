namespace GuYou.Contracts.DTOs.UserDTO
{
    public class UpdateRoleDTO
    {
        public string RoleId { get; set; }
        public string NewRoleName { get; set; }

        public UpdateRoleDTO(string roleId, string newRoleName)
        {
            RoleId = roleId;
            NewRoleName = newRoleName;
        }
    }
}
