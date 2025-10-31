using LMS.DAL.Database;
using LMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Repository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        ApplicationContext _db = new ApplicationContext();
        public async Task<(Member?, List<BorrowTransaction>, List<ReservationTransaction>)> ViewProfile(int memberId)
        {
            var member = await _db.Members.FirstOrDefaultAsync(m => m.Id == memberId);

            if (member == null)
                return (null, new List<BorrowTransaction>(), new List<ReservationTransaction>());
            var borr = await _db.BorrowTransactions.Where(x => x.MemberId == memberId).Include(b => b.Book).ToListAsync();
            var res = await _db.ReservationTransactions.Where(x => x.MemberId == memberId).Include(r => r.Book).ToListAsync();
                      
            return (member,borr, res);
        }
    }

    public interface IMemberRepository
    {
        Task<(Member?, List<BorrowTransaction>, List<ReservationTransaction>)> ViewProfile(int memberId);
    }
}
