using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMS.Models.DTO.Users
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistereAt { get; set; }
    }
}
