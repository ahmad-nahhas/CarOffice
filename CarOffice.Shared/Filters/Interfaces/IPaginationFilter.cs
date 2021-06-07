using System.Linq;

namespace CarOffice.Shared.Filters.Interfaces
{
    public interface IPaginationFilter<T> where T : class
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalPages { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }

        IQueryable<T> ConfigurePagination(IQueryable<T> initialSet);
    }
}