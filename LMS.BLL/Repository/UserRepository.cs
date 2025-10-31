using LMS.DAL.Database;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        ApplicationContext _db = new ApplicationContext();
        public async Task<bool> DeReActivateUser(int memberId)
        {
            var member = await _db.Members.FindAsync(memberId);
            if (member == null)
                return false;
            member.IsActive = !member.IsActive;
            await _db.SaveChangesAsync();
            return true;
        }
    }
    public interface IUserRepository
    {
        Task<bool> DeReActivateUser(int memberId);
    }
}

