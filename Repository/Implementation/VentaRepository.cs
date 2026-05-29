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
    public class VentaRepository : IVentaRepository
    {
        public readonly Conexion _conexion;

        public VentaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<string> Guardar(Venta objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_guardarVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                var detalleJson = System.Text.Json.JsonSerializer.Serialize(
                    objeto.Detalles.Select(d => new
                    {
                        idProducto = d.RefProducto.idProducto,
                        cantidad = d.cantidad,
                        precio_total = d.precio_total
                    })
                );

                cmd.Parameters.AddWithValue("@idUsuario", objeto.UsuarioRegistro.idUsuario);
                cmd.Parameters.AddWithValue("@nombre_cliente", objeto.nombre_cliente);
                cmd.Parameters.AddWithValue("@pago_total", objeto.pago_total);
                cmd.Parameters.AddWithValue("@pago", objeto.pago);
                cmd.Parameters.AddWithValue("@cambio", objeto.cambio);
                cmd.Parameters.AddWithValue("@detalle", detalleJson);

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = "OK";
                }
                catch (Exception ex)
                {
                    respuesta = "Error(rp): " + ex.Message;
                }
            }
            return respuesta;
        }

        public async Task<Venta> Obtener(string idVenta)
        {
            Venta Objeto = new Venta();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        Objeto = new Venta()
                        {
                            idVenta = Convert.ToInt32(dr["idVenta"].ToString()),
                            UsuarioRegistro = new Usuario
                            {
                                nombre_completo = dr["nombre_completo"].ToString()!
                            },
                            nombre_cliente = dr["nombre_cliente"].ToString()!,
                            pago_total = Convert.ToDecimal(dr["pago_total"]),
                            pago = Convert.ToDecimal(dr["pago"]),
                            cambio = Convert.ToDecimal(dr["cambio"]),
                            fecha_registro = dr["fecha_registro"].ToString()!
                        };
                    }
                }
            }
            return Objeto;
        }

        public async Task<List<DetalleVenta>> ObtenerDetalle()
        {
            List<DetalleVenta>lista = new List<DetalleVenta>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        lista.Add(new DetalleVenta
                        {
                            RefProducto = new Producto
                            {
                                descripcion = dr["descripcion"].ToString()!,
                                
                            },
                            cantidad = Convert.ToInt32(dr["cantidad"]),
                            precio_total = Convert.ToDecimal(dr["precio_total"])
                             
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<string> Registrar(string venta)
        {
            var respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_guardarVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = "Completado con éxito";
                }
                catch
                {
                    respuesta = "Error(rp): No se pudo procesar";
                }
            }
            return respuesta;
        }
    }
}
