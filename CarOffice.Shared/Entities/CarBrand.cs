using CarOffice.Shared.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarOffice.Shared.Entities
{
    public class CarBrand : EntityBase
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}