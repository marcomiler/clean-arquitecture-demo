using AtlanticCity.Core.Core;
using AtlanticCity.Core.Entities.PruebaCA;
using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
using AtlanticCity.Infraestructure.Connections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticCity.Infraestructure.Repositories.PruebaCA
{
    public class EstadoRepository : IEstadoRepository
    {
        protected readonly IMongoDBContext _context;
        protected IMongoCollection<Estado> _dbSet;

        public  EstadoRepository(IMongoDBContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<Estado>(typeof(Estado).Name, Constants.ChooseMongoDBDataBaseName.basededatos1);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Estado> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estado>> GetAll()
        {
            var listadoEstado = _dbSet.AsQueryable().ToList();
            return await Task.Run(() => listadoEstado);
        }

        public Task<int> Insert(Estado t)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Estado t)
        {
            throw new NotImplementedException();
        }
    }
}
