using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace UsersMS.Models.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime RegisterdAt { get; set; }
        [Required]
        public string PasswordHash { get; set; }




    }
}
