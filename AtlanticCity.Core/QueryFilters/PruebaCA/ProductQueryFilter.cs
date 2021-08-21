using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.QueryFilters.PruebaCA
{
    public class ProductQueryFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int IdCategory { get; set; }
    }
}
