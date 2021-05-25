using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMS.Models.Events
{
    public class UserEvent
    {
        public string EventType { get; set; }

        public string PayLoad { get; set; }
    }
}
