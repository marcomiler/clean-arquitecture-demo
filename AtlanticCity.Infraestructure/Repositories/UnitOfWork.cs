using AtlanticCity.Core.Interfaces.ICore;
using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
using AtlanticCity.Core.Interfaces.Repositories.PruebaCA;
using AtlanticCity.Infraestructure.Connections;
using AtlanticCity.Infraestructure.Repositories.PruebaCA;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        private readonly ICategoryRepository _ICategoryRepository;
        private readonly IProductRepository _IProductRepository;
        private readonly IActorRepository _IActorRepository;
       


        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public UnitOfWork(IMongoDBContext context)
        //{
        //    _context = context;
        //}

        public IProductRepository IProductRepository => _IProductRepository ?? new ProductRepository(_configuration);

        public ICategoryRepository ICategoryRepository => _ICategoryRepository ?? new CategoryRepository(_configuration);

        public IActorRepository IActorRepository => _IActorRepository ?? new ActorRepository(_configuration);

       // public IEstadoRepository IEstadoRepository => _IEstadoRepository ?? new EstadoRepository(_context);
    }
}
