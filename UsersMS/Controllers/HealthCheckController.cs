using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        // GET: api/<HealthCheckController>
        [HttpGet]
        public bool Get()
        {
            return true;
        }

    }
}
