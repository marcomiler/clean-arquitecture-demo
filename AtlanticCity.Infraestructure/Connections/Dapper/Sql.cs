
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AtlanticCity.Infraestructure.Dapper.Connections
{
    public class Sql : Base
    {
        public Sql(IConfiguration _configuration) : base(_configuration)
        {
            _dapperConfiguration = _configuration;
        }

        static internal IDbConnection ObtenerConexion(string databaseName)
        {

            var connectionStringName = "ConnectionStrings:ConnectionSqlServer";
            var dapperConnectionString = _dapperConfiguration[connectionStringName];
            dapperConnectionString = dapperConnectionString.Replace("DefaultDataBase", databaseName);


            if (string.IsNullOrEmpty(dapperConnectionString))
                throw new ArgumentException("El parámetro connectionStringSql se encuentra nulo.");

            return new SqlConnection(dapperConnectionString);
        }
    }
}
