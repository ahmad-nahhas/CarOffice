using CarOffice.Shared.Entities.Base;
using CarOffice.Shared.Filters.Interfaces;
using System;
using System.Linq;

namespace CarOffice.Shared.Filters.Base
{
    public abstract class PaginationFilter<T> : IPaginationFilter<T> where T : EntityBase, new()
    {
        private const int _defaultPageNumber = 1;
        private int _pageNumber = _defaultPageNumber;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < _defaultPageNumber) ? _defaultPageNumber : value;
        }

        private const int _defaultPageSize = 6;
        private int _pageSize = _defaultPageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value < 1) ? _defaultPageSize : value;
        }

        public int TotalPages { get; private set; }

        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        public IQueryable<T> ConfigurePagination(IQueryable<T> initialSet)
        {
            TotalPages = (int)Math.Ceiling(initialSet.Count() / (double)PageSize);

            return initialSet.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}