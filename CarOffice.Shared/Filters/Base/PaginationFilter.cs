using CarOffice.Shared.Entities.Base;
using CarOffice.Shared.Filters.Interfaces;
using System;
using System.Linq;

namespace CarOffice.Shared.Filters.Base
{
    public abstract class PaginationFilter<T> : IPaginationFilter<T>
        where T : EntityBase, new()
    {
        private const int _defaultPageNumber = 1;
        private const int _defaultPageSize = 6;
        private int _pageNumber = _defaultPageNumber;
        private int _pageSize = _defaultPageSize;
        private int _totalPages = _defaultPageNumber;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < _defaultPageNumber)
                ? _defaultPageNumber
                : value;
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value < _defaultPageNumber)
                ? _defaultPageSize
                : value;
        }
        public int TotalPages => _totalPages;
        public bool HasPrevious => PageNumber > _defaultPageNumber;
        public bool HasNext => PageNumber < TotalPages;

        public IQueryable<T> ConfigurePagination(IQueryable<T> initialSet)
        {
            _totalPages = (int)Math.Ceiling(initialSet.Count() / (double)PageSize);
            return initialSet.Skip((PageNumber - _defaultPageNumber) * PageSize).Take(PageSize);
        }
    }
}