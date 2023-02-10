
using SistemaGestionProyectoFinal.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaGestionProyectoFinal.Repositorios
{
    internal static class VentaHandler
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DKO2V17;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static List<Venta> ObtenerVentasRealizadas(long idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                List<Venta> ventas = new List<Venta>();
                SqlCommand comand = new SqlCommand($"SELECT *  FROM Venta WHERE Venta.IdUsuario = {idUsuario}", conn);
                conn.Open();

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Venta ventaTemporal = new Venta();
                        ventaTemporal.Id = reader.GetInt64(0);
                        ventaTemporal.Comentarios = reader.GetString(1);
                        ventaTemporal.IdUser = reader.GetInt64(2);

                        ventas.Add(ventaTemporal);
                    }
                }

                return ventas;
            }
        }

        public static long InsertarVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Venta(Comentarios,IdUsuario) Values('{venta.Comentarios}',{venta.IdUser}) SELECT @@IDENTITY", conn);
                conn.Open();
                return Convert.ToInt64(command.ExecuteScalar());
            }

        }
        public static void CargarVentas(List<Producto> productos, long idUsuario)
        {

        }
    }
}

