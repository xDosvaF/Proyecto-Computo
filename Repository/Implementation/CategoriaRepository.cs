using Microsoft.Data.SqlClient;
using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
            private readonly Conexion _conexion;

        public CategoriaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<List<Categoria>> Lista()
        {
            List<Categoria> lista = new List<Categoria>();
            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Categoria()
                        {
                            idCategoria = Convert.ToInt32(dr["idCategoria"]),
                            nombre = dr["nombre"].ToString()!
                        });
                    }
                }
            }
            return lista;
        }
    }
}
