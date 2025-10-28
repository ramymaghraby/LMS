using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Entities
{
    public class Role : BaseEntity
    {
        [Column("RoleName", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
    }
}
