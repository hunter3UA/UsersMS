using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMS.Models.DTO.Users
{
    public class UserPasswordChangeDTO
    {
        public int UserID { get; set; }
        public string NewPassword { get; set; }
    }
}
