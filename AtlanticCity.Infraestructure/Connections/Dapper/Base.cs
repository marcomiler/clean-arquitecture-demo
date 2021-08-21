
using Microsoft.Extensions.Configuration;

namespace AtlanticCity.Infraestructure.Dapper.Connections
{
    public class Base
    {
        protected static IConfiguration _dapperConfiguration;

        public IConfiguration DapperConfiguration
        {
            get { return _dapperConfiguration; }
        }

        public Base(IConfiguration _configuration)
        {
            _dapperConfiguration = _configuration;
        }
    }
}
