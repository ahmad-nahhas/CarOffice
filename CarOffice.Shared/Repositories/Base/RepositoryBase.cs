using CarOffice.Shared.Entities.Base;
using CarOffice.Shared.Filters.Interfaces;
using CarOffice.Shared.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarOffice.Shared.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase, new()
    {
        private readonly CarOfficeDbContext _context;
        private readonly DbSet<T> _table;

        public RepositoryBase(CarOfficeDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
            => await _table.ToListAsync();

        public async Task<IEnumerable<T>> GetAsync(IFilter<T> filter)
            => await filter.Build(_table).ToListAsync();

        public async Task<T> GetAsync(object id)
            => await _table.FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            var added = await _table.AddAsync(entity);
            var affected = await _context.SaveChangesAsync();

            return (affected > 0) ? added.Entity : null;
        }

        public async Task<T> DeleteAsync(object id)
        {
            var deleted = _table.Remove(await GetAsync(id));
            var affected = await _context.SaveChangesAsync();

            return (affected > 0) ? deleted.Entity : null;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updated = _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            var affected = await _context.SaveChangesAsync();

            return (affected > 0) ? updated.Entity : null;
        }
    }
}