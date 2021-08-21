using AtlanticCity.Core.Core;
using AtlanticCity.Core.Entities.PruebaCA;
using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
using AtlanticCity.Infraestructure.Connections.Dapper;
using AtlanticCity.Infraestructure.Dapper.Connections;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticCity.Infraestructure.Repositories.PruebaCA
{
    public class ActorRepository : Base, IActorRepository
    {
        public ActorRepository(IConfiguration configuration) : base(configuration) { }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            using (IDbConnection dbConnection = Mysql.ObtenerConexion(Constants.ChooseMYSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Actor>(
                    "GetAllActor",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public Task<int> Insert(Actor t)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Actor t)
        {
            throw new NotImplementedException();
        }
    }
}
