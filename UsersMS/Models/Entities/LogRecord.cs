using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UsersMS.Models.Entities
{
    public class LogRecord
    {
        [Key]
        public long LogRecordID { get; set; }

        [Required]
        public DateTime AddedAt { get; set; }

        [Required]
        public string Details { get; set; }



       
    }
}
