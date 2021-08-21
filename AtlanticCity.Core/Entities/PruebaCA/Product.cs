using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Entities.PruebaCA
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
