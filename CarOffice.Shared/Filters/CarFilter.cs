using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters.Base;
using System;
using System.Linq;

namespace CarOffice.Shared.Filters
{
    public class CarFilter : FilterBase<Car>
    {
        public string Brand { get; set; }
        public CarType? Type { get; set; }
        public CarStatus? Status { get; set; }
        public FuelType? FuelType { get; set; }
        public Gearbox? Gearbox { get; set; }
        public bool? ShowInHome { get; set; }
        public bool? Shuffle { get; set; }
        public decimal? LowerLimit { get; set; }
        public decimal? UpperLimit { get; set; }
        public string Color { get; set; }
        public int? ModelYear { get; set; }
        public int? Mileage { get; set; }
        public int? SeatCount { get; set; }
        public decimal? WeightTotal { get; set; }
        public string Description { get; set; }
        public string CarExtras { get; set; }

        public override IQueryable<Car> Build(IQueryable<Car> initialSet)
        {
            if (!string.IsNullOrWhiteSpace(Brand))
                initialSet = initialSet.Where(c => c.Brand.Name.ToLower().Contains(Brand.ToLower()));

            if (Type.HasValue)
                initialSet = initialSet.Where(c => c.Type == Type);

            if (Type.HasValue)
                initialSet = initialSet.Where(c => c.Status == Status);

            if (Type.HasValue)
                initialSet = initialSet.Where(c => c.FuelType == FuelType);

            if (Type.HasValue)
                initialSet = initialSet.Where(c => c.Gearbox == Gearbox);

            if (ShowInHome.HasValue)
                initialSet = initialSet.Where(c => c.ShowInHome == ShowInHome);

            if (Shuffle.HasValue && Shuffle == true)
                initialSet = initialSet.OrderBy(c => Guid.NewGuid());

            if (LowerLimit.HasValue)
                initialSet = initialSet.Where(c => c.Price >= LowerLimit);

            if (UpperLimit.HasValue)
                initialSet = initialSet.Where(c => c.Price <= UpperLimit);

            if (!string.IsNullOrWhiteSpace(Color))
                initialSet = initialSet.Where(c => c.Color.ToLower().Contains(Color.ToLower()));

            if (ModelYear.HasValue)
                initialSet = initialSet.Where(c => c.ModelYear == ModelYear);

            if (Mileage.HasValue)
                initialSet = initialSet.Where(c => c.Mileage <= Mileage);

            if (SeatCount.HasValue)
                initialSet = initialSet.Where(c => c.SeatCount == SeatCount);

            if (WeightTotal.HasValue)
                initialSet = initialSet.Where(c => c.WeightTotal <= WeightTotal);

            if (!string.IsNullOrWhiteSpace(Description))
                initialSet = initialSet.Where(c => c.Description.ToLower().Contains(Description.ToLower()));

            if (!string.IsNullOrWhiteSpace(CarExtras))
                initialSet = initialSet.Where(c => c.CarExtras.ToLower().Contains(CarExtras.ToLower()));

            return base.Build(initialSet);
        }
    }
}