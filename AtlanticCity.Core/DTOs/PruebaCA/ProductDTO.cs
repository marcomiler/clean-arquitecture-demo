using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.DTOs.PruebaCA
{
    public abstract class ProductDTO
    {
        public string ProductName { get; set; }
        public int IdCategory { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class ProductInsertDTO : ProductDTO
    {
        
    }

    public class ProductUpdateDTO : ProductDTO
    {
        public int Id { get; set; }
    }

}
