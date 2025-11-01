using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Model
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            CreatedOn = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
