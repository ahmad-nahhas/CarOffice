using CarOffice.Shared.Filters.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarOffice.Shared.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(IFilter<T> filter);
        Task<T> GetAsync(object id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(object id);
    }
}