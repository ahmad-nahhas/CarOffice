using CarOffice.Shared.Entities.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarOffice.Shared.Entities
{
    public class Car : EntityBase
    {
        [Display(Name = "Car Type")]
        public CarType Type { get; set; }

        [Display(Name = "Car Status")]
        public CarStatus Status { get; set; }

        [Display(Name = "Fuel Type")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Gearbox")]
        public Gearbox Gearbox { get; set; }

        [Display(Name = "Show In Home")]
        public bool ShowInHome { get; set; }

        [Required]
        [Column(TypeName = "decimal(38, 0)")]
        [Range(ulong.MinValue, ulong.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Display(Name = "Brand")]
        public Guid BrandId { get; set; }
        public virtual CarBrand Brand { get; set; }

        [NotMapped]
        public ICollection<IFormFile> Files { get; set; }

        public virtual ICollection<CarImage> Images { get; set; }

        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Color { get; set; }

        [Range(1960, 2150, ErrorMessage = "{0} must be between {1} and {2}.")]
        [Display(Name = "Model Year")]
        public int? ModelYear { get; set; }

        [Range(0, 10000000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int? Mileage { get; set; }

        [Display(Name = "Number of Seats")]
        [Range(1, 75, ErrorMessage = "Number of seats must be between {1} and {2}.")]
        public int? SeatCount { get; set; }

        [Display(Name = "Weight Total")]
        [Column(TypeName = "decimal(38, 0)")]
        [Range(ulong.MinValue, ulong.MaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public decimal? WeightTotal { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1024, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Display(Name = "Car Extras")]
        [DataType(DataType.MultilineText)]
        [StringLength(1024, ErrorMessage = "The Car Extras value cannot exceed {1} characters.")]
        public string CarExtras { get; set; }
    }
}