using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class AlumnoDatos
    {
        public List<AlumnoModel> Listar()
        {
            var oLista = new List<AlumnoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAlumnos", conexion); // Procedimiento almacenado que deberías definir
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new AlumnoModel()
                        {
                            Matricula = dr["Matricula"].ToString(),
                            NombreC = dr["NombreC"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            CorreoE = dr["CorreoE"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }


        public AlumnoModel Obtener(string matricula)
        {
            var oAlumno = new AlumnoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAlumno", conexion);
                cmd.Parameters.AddWithValue("Matricula", matricula);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oAlumno.Matricula = dr["Matricula"].ToString();
                        oAlumno.NombreC = dr["NombreC"].ToString();
                        oAlumno.Telefono = dr["Telefono"].ToString();
                        oAlumno.CorreoE = dr["CorreoE"].ToString();
                    }
                }
            }

            return oAlumno;
        }

        public bool Guardar(AlumnoModel oAlumno)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarAlumno", conexion);
                    cmd.Parameters.AddWithValue("Matricula", oAlumno.Matricula);
                    cmd.Parameters.AddWithValue("NombreC", oAlumno.NombreC);
                    cmd.Parameters.AddWithValue("Telefono", oAlumno.Telefono);
                    cmd.Parameters.AddWithValue("CorreoE", oAlumno.CorreoE);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(AlumnoModel oAlumno)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAlumno", conexion);
                    cmd.Parameters.AddWithValue("Matricula", oAlumno.Matricula);
                    cmd.Parameters.AddWithValue("NombreC", oAlumno.NombreC);
                    cmd.Parameters.AddWithValue("Telefono", oAlumno.Telefono);
                    cmd.Parameters.AddWithValue("CorreoE", oAlumno.CorreoE);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(string matricula)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAlumno", conexion);
                    cmd.Parameters.AddWithValue("Matricula", matricula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
