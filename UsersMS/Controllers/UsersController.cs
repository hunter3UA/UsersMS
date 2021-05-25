using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Services;
using UsersMS.Models.DTO;
using UsersMS.Models.DTO.Users;

namespace UsersMS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            return await _userService.All();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await _userService.ByID(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async  Task<UserDTO> Post([FromBody] UserCreateDTO newUserDTO)
        {
            return await _userService.Create(newUserDTO);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<UserDTO> Put([FromBody] UserUpdateDTO userUpdateDTO)
        {
            return await _userService.Update(userUpdateDTO);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _userService.DeleteByID(id);
        }
    }
}
