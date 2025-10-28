using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Column("CategoryName", TypeName ="NVARCHAR(50)")]
        public string Name { get; set; }
        [Column("CategoryDescription", TypeName = "NVARCHAR(150)")]
        public string Description{ get; set; }
        public List<Book> Books { get; set; }
    }
}
