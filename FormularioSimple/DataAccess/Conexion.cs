using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FormularioSimple.DataAccess
{
    internal class Conexion
    {
        public bool intentoDeConexion(string cadenaDeConexion)
        {
            try
            {
                using (var conexion = new MySqlConnection(cadenaDeConexion))
                {
                    conexion.Open();
                    return true;
                }
            }
            catch(Exception ex)
            {

                return false;
            }

        }

        public DataTable obtenerDatos(string cadenaDeConexion)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conexion = new MySqlConnection(cadenaDeConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM CatPersonal";

                    using (var comando = new MySqlCommand(query, conexion))
                    using (var adapter = new MySqlDataAdapter(comando)) 
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al obtener información: " + ex.Message);
            }

            return dt;

        }
    }
}
