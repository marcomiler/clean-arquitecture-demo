using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.DTOs.PruebaCA
{
    public abstract class CategoryDTO
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class CategoryInsertDTO : ProductDTO
    {

    }

    public class CategoryUpdateDTO : ProductDTO
    {
        public int Id { get; set; }
    }
}
