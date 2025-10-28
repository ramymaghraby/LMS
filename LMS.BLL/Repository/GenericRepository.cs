using LMS.DAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        ApplicationContext _db = new ApplicationContext();

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _db.Set<TEntity>().Where(filter).ToListAsync();
            return result;

        }

        public async Task<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _db.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

    }

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);
        public Task<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);
        public Task CreateAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
    }
}
