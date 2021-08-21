using AtlanticCity.Core.Core;
using AtlanticCity.Core.Entities.PruebaCA;
using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
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
    public class CategoryRepository : Base, ICategoryRepository
    {

        public CategoryRepository(IConfiguration configuration) : base(configuration) { }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion(Constants.ChooseSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Category>(
                    "dbo.GetAllCategory",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public Task<int> Insert(Category t)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
