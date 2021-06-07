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
            initialSet = (CarId.HasValue && !CarId.Equals(Guid.Empty)) ?
                initialSet.Where(i => i.CarId == CarId) : initialSet;

            initialSet = string.IsNullOrWhiteSpace(Path) ?
                initialSet : initialSet.Where(i => i.Path.Equals(Path));

            return base.Build(initialSet);
        }
    }
}