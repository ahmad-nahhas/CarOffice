using System.Linq;

namespace CarOffice.Shared.Filters.Interfaces
{
    public interface IFilter<T> where T : class
    {
        bool ApplyPagination { get; set; }

        IQueryable<T> Build(IQueryable<T> initialSet);
    }
}