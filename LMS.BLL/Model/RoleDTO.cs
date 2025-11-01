using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Model
{
    public class RoleDTO
    {
        public RoleDTO() {
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
