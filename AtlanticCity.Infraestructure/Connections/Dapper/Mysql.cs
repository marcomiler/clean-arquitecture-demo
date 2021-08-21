using AtlanticCity.Infraestructure.Dapper.Connections;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;

namespace AtlanticCity.Infraestructure.Connections.Dapper
{
    public class Mysql : Base
    {
        public Mysql(IConfiguration _configuration) : base(_configuration)
        {
            _dapperConfiguration = _configuration;
        }

        static internal IDbConnection ObtenerConexion(string databaseName)
        {

            var connectionStringName = "ConnectionStringsMySql:ConnectionMySqlServer";
            var dapperConnectionString = _dapperConfiguration[connectionStringName];
            dapperConnectionString = dapperConnectionString.Replace("DefaultDataBase", databaseName);

            if (string.IsNullOrEmpty(dapperConnectionString))
                throw new ArgumentException("El parámetro connectionStringMySql se encuentra nulo.");

            var connectionStringBuilder = new MySqlConnectionStringBuilder(dapperConnectionString)
            {
                SslMode = MySqlSslMode.None,
            };

            return new MySqlConnection(connectionStringBuilder.ConnectionString);
        }
    }
}
