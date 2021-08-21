using AtlanticCity.Core.Core;
using AtlanticCity.Core.DTOs.PruebaCA;
using AtlanticCity.Core.Entities.PruebaCA;
using AtlanticCity.Core.Interfaces.ICore;
using AtlanticCity.Core.Interfaces.IServices.PruebaCA;
using AtlanticCity.Core.Models.PruebaCA;
using AtlanticCity.Core.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanticCity.Core.Services.PruebaCA
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper IMapper)
        {
            _IMapper = IMapper;
            _unitOfWork = unitOfWork;
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetAll()
        {
            var listProducts = await _unitOfWork.IProductRepository.GetAll();
            IEnumerable<ProductModel> listProductsMap = _IMapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(listProducts);

            return new Response(listProductsMap, true);
        }

        public async Task<Response> Insert(ProductInsertDTO productDto)
        {

            var resultMap = _IMapper.Map<Product>(productDto);
            var product = await _unitOfWork.IProductRepository.Insert(resultMap);

            return new Response(product, true);
        }

        public Task<Response> Update(ProductUpdateDTO t2)
        {
            throw new NotImplementedException();
        }
    }
}
