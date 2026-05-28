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
    public class ProductoRepository : IProductoRepository
    {
        private readonly Conexion _conexion;

        public ProductoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<string> Crear(Producto objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_guardarProducto", con);
                cmd.Parameters.AddWithValue("@idCategoria", objeto.RefCategoria.idCategoria);
                cmd.Parameters.AddWithValue("@nombre", objeto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", objeto.descripcion);
                cmd.Parameters.AddWithValue("@precio", objeto.precio);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch
                {
                    respuesta = "Error(rp): No se pudo procesar";
                }
            }
            return respuesta;
        }

        public async Task<string> Editar(Producto objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarProducto", con);
                cmd.Parameters.AddWithValue("@idProducto", objeto.idProducto);
                cmd.Parameters.AddWithValue("@idCategoria", objeto.RefCategoria.idCategoria);
                cmd.Parameters.AddWithValue("@nombre", objeto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", objeto.descripcion);
                cmd.Parameters.AddWithValue("@precio", objeto.precio);
                cmd.Parameters.AddWithValue("@activo", objeto.activo);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch
                {
                    respuesta = "Error(rp): No se pudo procesar";
                }
            }
            return respuesta;
        }

        public async Task<List<Producto>> Lista(string buscar)
        {
            List<Producto> lista = new List<Producto>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaProducto", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Producto()
                        {
                            idProducto = Convert.ToInt32(dr["idProducto"]),
                            RefCategoria = new Categoria
                            {
                                idCategoria = Convert.ToInt32(dr["idCategoria"]),
                                nombre = dr["nombre_categoria"].ToString()!
                            },
                            nombre = dr["nombre"].ToString()!,
                            descripcion = dr["descripcion"].ToString()!,
                            precio = Convert.ToInt32(dr["precio"]),
                            activo = Convert.ToInt32(dr["activo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
