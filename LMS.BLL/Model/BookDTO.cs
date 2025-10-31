using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Model
{
    public class BookDTO
    {
        public BookDTO()
        {
            CreatedOn = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
