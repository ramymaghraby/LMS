using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Entities
{
    public class User : BaseEntity
    {
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(120)]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
