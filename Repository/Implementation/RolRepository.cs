

using Microsoft.Data.SqlClient;
using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Repository.Implementation
{
    public class RolRepository : IRolRepository
    {
        private readonly Conexion _conexion;

        public RolRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<List<Rol>> Lista()
        {
            List<Rol> lista = new List<Rol>();
            using(var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaRol", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Rol()
                        {
                            idRol = Convert.ToInt32(dr["idRol"]),
                            nombre = dr["nombre"].ToString()!
                        });
                    }
                }
            }
            return lista;
        }
    }

}
