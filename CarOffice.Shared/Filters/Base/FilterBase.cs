using CarOffice.Shared.Entities.Base;
using CarOffice.Shared.Filters.Interfaces;
using System;
using System.Linq;

namespace CarOffice.Shared.Filters.Base
{
    public abstract class FilterBase<T> : PaginationFilter<T>, IFilter<T>
        where T : EntityBase, new()
    {
        public Guid? Id { get; set; }
        public bool ApplyPagination { get; set; } = true;

        public virtual IQueryable<T> Build(IQueryable<T> initialSet)
        {
            initialSet = (Id.HasValue && Id.Value != Guid.Empty)
                ? initialSet.Where(e => e.Id == Id.Value)
                : initialSet;

            return ApplyPagination
                ? ConfigurePagination(initialSet)
                : initialSet;
        }
    }
}