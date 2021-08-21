using AtlanticCity.Core.DTOs.PruebaCA;
using AtlanticCity.Core.Interfaces.ICore;
using AtlanticCity.Core.Interfaces.IServices.PruebaCA;
using AtlanticCity.Core.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.Core.Services.PruebaCA
{
    public class EstadoService : IEstadoService
    {
        private readonly IUnitOfWorkMongoDB _unitOfWork;
        private readonly IMapper _IMapper;

        public EstadoService(IUnitOfWorkMongoDB unitOfWork, IMapper IMapper)
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
            var listEstados = await _unitOfWork.IEstadoRepository.GetAll();

            return new Response(listEstados, true);
        }

        public Task<Response> Insert(EstadoInserDTO t1)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(EstadoUpdateDTO t2)
        {
            throw new NotImplementedException();
        }
    }
}
