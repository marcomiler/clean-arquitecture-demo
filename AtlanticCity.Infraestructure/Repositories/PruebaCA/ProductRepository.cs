using AtlanticCity.Core.Core;
using AtlanticCity.Core.Entities.PruebaCA;
using AtlanticCity.Core.Interfaces.Repositories.PruebaCA;
using AtlanticCity.Core.Models.PruebaCA;
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
    public class ProductRepository : Base, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> Delete(int id)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion(Constants.ChooseSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<bool>(
                    "",
                    new
                    {

                    },
                    commandType: CommandType.StoredProcedure
                );

                return result.SingleOrDefault<bool>();
            }
        }

        public async Task<Product> Find(int id)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion(Constants.ChooseSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Product>(
                    "",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion(Constants.ChooseSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Product>(
                    "dbo.GetAllUser",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public async Task<int> Insert(Product t)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion(Constants.ChooseSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<int>(
                    "",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                return result.SingleOrDefault<int>();
            }
        }

        public async Task<int> Update(Product t)
        {
            using (IDbConnection dbConnection = Sql.ObtenerConexion(Constants.ChooseSQLDataBaseName.basededatos1))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<int>(
                    "",
                    new { },
                    commandType: CommandType.StoredProcedure
                );

                return result.SingleOrDefault<int>();
            }
        }
    }
}
