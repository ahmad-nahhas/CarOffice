using System;
using System.ComponentModel.DataAnnotations;

namespace CarOffice.Shared.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        [Display(Name = "Addition Date")]
        public DateTime CreatedAt { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}