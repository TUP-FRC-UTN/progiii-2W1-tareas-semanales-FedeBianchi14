using NegocioInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NegocioInstrumentos.AccesoDatos
{
    public class AD_Instrumentos
    {
        //AGREGAR NUEVO INSTRUMENTO
        public static bool InsertarInstrumentos(Instrumento instrumento)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "INSERT INTO Instrumento (Nombre, Descripcion, Stock, Precio, idTipo) VALUES (@Nombre, @Descripcion, @Stock, @Precio, @idTipo)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Nombre", instrumento.pNombre);
                comando.Parameters.AddWithValue("@Descripcion", instrumento.pDescripcion);
                comando.Parameters.AddWithValue("@Stock", instrumento.pStock);
                comando.Parameters.AddWithValue("@Precio", instrumento.pPrecio);
                comando.Parameters.AddWithValue("@idTipo", instrumento.IdTipo);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        //LISTADO INSTRUMENTO
        public static List<Instrumento> ListadoInstrumento()
        {
            List<Instrumento> listaInstrumentos = new List<Instrumento>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM instrumento";
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();

                if(lector != null)
                {
                    while (lector.Read())
                    {
                        Instrumento auxiliar = new Instrumento();
                        auxiliar.pIdInstrumento = int.Parse(lector["idInstrumento"].ToString());
                        auxiliar.pNombre = lector["Nombre"].ToString();
                        auxiliar.pDescripcion = lector["Descripcion"].ToString();
                        auxiliar.pStock = int.Parse(lector["Stock"].ToString());
                        auxiliar.pPrecio = float.Parse(lector["Precio"].ToString());

                        listaInstrumentos.Add(auxiliar);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return listaInstrumentos;
        }
    }
}