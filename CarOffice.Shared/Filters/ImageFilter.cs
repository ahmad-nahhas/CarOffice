using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters.Base;
using System;
using System.Linq;

namespace CarOffice.Shared.Filters
{
    public class ImageFilter : FilterBase<CarImage>
    {
        public Guid? CarId { get; set; }
        public string Path { get; set; }

        public override IQueryable<CarImage> Build(IQueryable<CarImage> initialSet)
        {
            initialSet = (CarId.HasValue && CarId != Guid.Empty)
                ? initialSet.Where(i => i.CarId.Equals(CarId))
                : initialSet;

            initialSet = (!string.IsNullOrWhiteSpace(Path))
                ? initialSet.Where(i => i.Path.Equals(Path))
                : initialSet;

            return base.Build(initialSet);
        }
    }
}