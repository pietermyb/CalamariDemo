using Calamari.Models.Contracts;
using System;

namespace Calamari.Models
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }

        public virtual Guid RefId { get; set; }
    }
}