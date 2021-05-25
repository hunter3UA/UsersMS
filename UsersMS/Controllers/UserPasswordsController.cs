using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Services;
using UsersMS.Models.DTO.Users;

namespace UsersMS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserPasswordsController : ControllerBase
    {
        private IUserService _userService;
        public UserPasswordsController(IUserService userService)
        {
            _userService = userService;
        }
        // PUT api/v1/userPasswords
        [HttpPut]
        public async Task<bool> Put([FromBody] UserPasswordChangeDTO passwordChangeDTO)
        {
            return await _userService.PasswordUpdate(passwordChangeDTO);
        }

      
    }
}
