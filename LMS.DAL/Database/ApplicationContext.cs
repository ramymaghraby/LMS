using LMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Database
{
    public class ApplicationContext :DbContext
    {

        //Configuew Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ramymaghrabylt\\SQLEXPRESS22; database = LMS; integrated security = true; TrustServerCertificate = true");
        }

        //Adding Entities

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles {  get; set; }
        public DbSet<UserInRole> UserInRole {  get; set; }
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
        public DbSet<ReservationTransaction> ReservationTransactions { get; set; }

    }
}

