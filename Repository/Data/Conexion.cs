using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Repository.Data
{
    public class Conexion
    {
        private readonly IConfiguration _configuration;
        private readonly string _cadenaSql = null!;

        public Conexion( IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaSql = _configuration.GetConnectionString("cadenaSql")!;
        }

        public SqlConnection ObtenerSQLConexion()
        {
            return new SqlConnection(_cadenaSql);
        }
    }
}
