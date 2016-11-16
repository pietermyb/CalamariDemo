using System;

namespace Calamari.Models.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        Guid RefId { get; set; }
    }
}