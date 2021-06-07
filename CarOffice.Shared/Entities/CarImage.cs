using CarOffice.Shared.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarOffice.Shared.Entities
{
    public class CarImage : EntityBase
    {
        [Required(ErrorMessage = "Image Path is required.")]
        public string Path { get; set; }

        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}