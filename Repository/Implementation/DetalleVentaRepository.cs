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
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly Conexion _conexion;

        public DetalleVentaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<string> Crear(DetalleVenta objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_guardarDetalleVenta", con);
                cmd.Parameters.AddWithValue("@idProducto", objeto.RefProducto.idProducto);
                cmd.Parameters.AddWithValue("@cantidad", objeto.cantidad);
                cmd.Parameters.AddWithValue("@precio_total", objeto.precio_total);
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

        public async Task<List<DetalleVenta>> Lista()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaDetalleVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new DetalleVenta()
                        {
                            idDetalleVenta = Convert.ToInt32(dr["idDetalleVenta"]),
                            RefVenta = new Venta
                            {
                                nombre_cliente = dr["nombre_cliente"].ToString()!
                            },
                            RefProducto = new Producto
                            {
                                nombre = dr["nombre"].ToString()!,
                                precio = Convert.ToDecimal(dr["precio"])
                            },
                            cantidad = Convert.ToInt32(dr["cantidad"]),
                            precio_total = Convert.ToDecimal(dr["precio_total"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
