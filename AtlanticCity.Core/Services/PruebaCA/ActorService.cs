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
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;

        public ActorService(IUnitOfWork unitOfWork, IMapper IMapper)
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
            var listActors = await _unitOfWork.IActorRepository.GetAll();

            return new Response(listActors, true);
        }

        public Task<Response> Insert(ActorInsertDTO t1)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(ActorUpdateDTO t2)
        {
            throw new NotImplementedException();
        }
    }
}
