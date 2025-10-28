using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Entities
{
    [Table("Books")]
    public class Book : BaseEntity
    {
       
        [Column("BookTitle", TypeName ="NVARCHAR(80)")]
        public string Title { get; set; }
        [Column("BookAuthor", TypeName = "NVARCHAR(80)")]
        public string Author{ get; set; }
        [StringLength(13)]
        public string ISBN{ get; set; }
        public int PublishedYear { get; set; }
        public int CategoryId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
        public bool IsAvailable { get; set; }
        
    }
}
