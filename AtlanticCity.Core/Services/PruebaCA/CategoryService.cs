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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper IMapper)
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
            var listCategories = await _unitOfWork.ICategoryRepository.GetAll();
            IEnumerable<CategoryModel> listCategoriesMap = _IMapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(listCategories);

            return new Response(listCategoriesMap, true);
        }

        public Task<Response> Insert(CategoryInsertDTO t1)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(CategoryUpdateDTO t2)
        {
            throw new NotImplementedException();
        }
    }
}
