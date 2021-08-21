using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Models.PruebaCA
{
    public class ProductModel: BaseEntityModel
    {
        public string ProductName { get; set; }
        public CategoryModel Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
