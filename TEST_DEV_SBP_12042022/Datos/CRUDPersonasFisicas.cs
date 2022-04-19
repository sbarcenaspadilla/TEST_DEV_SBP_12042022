using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TEST_DEV_SBP_12042022.Models;

namespace TEST_DEV_SBP_12042022.Datos
{
    public class CRUDPersonasFisicas
    {
        public static bool Agregar(PersonasFisicas oPersonasFisicas)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarPersonaFisica", oConexion); //Especificamos que procedimiento almacenado utilizamos
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fechaRegistro", oPersonasFisicas.FechaRegistro); //pasamos parametros de entrada
                cmd.Parameters.AddWithValue("@fechaActualizacion", oPersonasFisicas.FechaActualizacion);
                cmd.Parameters.AddWithValue("@nombre", oPersonasFisicas.Nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", oPersonasFisicas.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", oPersonasFisicas.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@rfc", oPersonasFisicas.RFC);
                cmd.Parameters.AddWithValue("@fechaNacimiento", oPersonasFisicas.FechaNacimiento);
                cmd.Parameters.AddWithValue("@usuarioAgrega", oPersonasFisicas.UsuarioAgrega);
                cmd.Parameters.AddWithValue("@activo", oPersonasFisicas.Activo);

                try
                {
                    oConexion.Open();   //Abrimos cadena de conexion
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(PersonasFisicas oPersonasFisicas)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarPersonaFisica", oConexion);
                cmd.CommandType =CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPersonaFisica", oPersonasFisicas.IdPersonaFisica);
                cmd.Parameters.AddWithValue("@fechaRegistro", oPersonasFisicas.FechaRegistro);
                cmd.Parameters.AddWithValue("@fechaActualizacion", oPersonasFisicas.FechaActualizacion);
                cmd.Parameters.AddWithValue("@nombre", oPersonasFisicas.Nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", oPersonasFisicas.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", oPersonasFisicas.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@rfc", oPersonasFisicas.RFC);
                cmd.Parameters.AddWithValue("@fechaNacimiento", oPersonasFisicas.FechaNacimiento);
                cmd.Parameters.AddWithValue("@usuarioAgrega", oPersonasFisicas.UsuarioAgrega);
                cmd.Parameters.AddWithValue("@activo", oPersonasFisicas.Activo);

                try
                {
                    oConexion.Open();   //Abrimos cadena de conexion
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public static List<PersonasFisicas> MostrarTodos()
        {
            List<PersonasFisicas> oListarPersonas = new List<PersonasFisicas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("select * from Tb_PersonasFisicas", oConexion);
                cmd.CommandType= System.Data.CommandType.Text;

                try
                {
                    oConexion.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oListarPersonas.Add(new PersonasFisicas()
                            {
                                IdPersonaFisica = Convert.ToInt32(reader["IdPersonaFisica"]),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                                FechaActualizacion = Convert.ToDateTime(reader["FechaActualizacion"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                                ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                                RFC = reader["RFC"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString()),
                                UsuarioAgrega = Convert.ToInt32(reader["UsuarioAgrega"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            });
                        }
                    }
                    return oListarPersonas;
                }
                catch (Exception ex)
                {
                    return oListarPersonas;
                }
            }
        }

        public static PersonasFisicas ConsultarUno(int IdPersonaFisica)
        {
            PersonasFisicas oPersonasFisicas = new PersonasFisicas();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Estados WHERE id=@IdPersonaFisica", oConexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdPersonaFisica", IdPersonaFisica);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oPersonasFisicas = new PersonasFisicas()
                            {
                                IdPersonaFisica = Convert.ToInt32(reader["IdPersonaFisica"]),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                                FechaActualizacion = Convert.ToDateTime(reader["FechaActualizacion"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                                ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                                RFC = reader["RFC"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString()),
                                UsuarioAgrega = Convert.ToInt32(reader["UsuarioAgrega"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };
                        }
                    }
                    return oPersonasFisicas;
                }
                catch (Exception ex)
                {
                    return oPersonasFisicas;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarPersonaFisica", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonaFisica", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

    }
}
