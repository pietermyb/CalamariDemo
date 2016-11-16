using System;

namespace Calamari.Models
{
    public partial class Product : Entity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}