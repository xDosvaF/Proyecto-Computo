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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexion _conexion;

        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<string> Crear(Usuario objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_guardarUsuario", con);
                cmd.Parameters.AddWithValue("@idRol", objeto.RefRol.idRol);
                cmd.Parameters.AddWithValue("@nombre_completo", objeto.nombre_completo);
                cmd.Parameters.AddWithValue("@correo", objeto.correo);
                cmd.Parameters.AddWithValue("@sexo", objeto.sexo);
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

        public async Task<string> Editar(Usuario objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarUsuario", con);
                cmd.Parameters.AddWithValue("@idUsuario", objeto.idUsuario);
                cmd.Parameters.AddWithValue("@idRol", objeto.RefRol.idRol);
                cmd.Parameters.AddWithValue("@nombre_completo", objeto.nombre_completo);
                cmd.Parameters.AddWithValue("@correo", objeto.correo);
                cmd.Parameters.AddWithValue("@sexo", objeto.sexo);
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

        public async Task<List<Usuario>> Lista(string buscar)
        {
            List<Usuario> lista = new List<Usuario>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaUsuario", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Usuario()
                        {
                            idUsuario = Convert.ToInt32(dr["idUsuario"]),
                            RefRol = new Rol
                            {
                                idRol = Convert.ToInt32(dr["idRol"]),
                                nombre = dr["nombre_rol"].ToString()!
                            },
                            nombre_completo = dr["nombre_completo"].ToString()!,
                            correo = dr["correo"].ToString()!,
                            sexo = Convert.ToInt32(dr["sexo"]),
                            activo = Convert.ToBoolean(dr["activo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
