using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.DTOs
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
