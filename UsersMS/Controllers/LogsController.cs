using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMS.Models.DTO.Logs;
using UsersMS.Services;

namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        // GET: api/logs
        [HttpGet]
        public IEnumerable<LogRecordDTO> Get()
        {
            return LogsService.All();
        }
        // GET api/logs/5
        [HttpGet("{id}")]
        public IEnumerable<LogRecordDTO> Get(int id)
        {
            return LogsService.ByID(id);
        }    
    }
}
