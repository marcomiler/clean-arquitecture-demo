using System;
using System.Collections.Generic;
using System.Text;
using AtlanticCity.Core.DTOs.PruebaCA;
using AtlanticCity.Core.Entities.PruebaCA;
using AtlanticCity.Core.Models.PruebaCA;
using AutoMapper;

namespace AtlanticCity.Core.Mappings.PruebaCA
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            
            CreateMap<Product, ProductInsertDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();

        }
    }
}
