using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMS.Models.DTO.Users
{
    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}
