using AtlanticCity.Core.Interfaces.ICore;
using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
using AtlanticCity.Infraestructure.Connections;
using AtlanticCity.Infraestructure.Repositories.PruebaCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Infraestructure.Repositories
{
    public class UnitOfWorkMongoDB : IUnitOfWorkMongoDB
    {
        private readonly IMongoDBContext _context;
        private readonly IEstadoRepository _IEstadoRepository;

        public UnitOfWorkMongoDB(IMongoDBContext context)
        {
            _context = context;
        }

        public IEstadoRepository IEstadoRepository => _IEstadoRepository ?? new EstadoRepository(_context);
    }
}
