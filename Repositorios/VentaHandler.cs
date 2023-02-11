
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

        public static void InsertVenta(List<Producto> productos, long IdUsuario)
        {
            Venta venta = new Venta();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Venta(Comentarios,IdUsuario) VALUES ('venta por usuario {IdUsuario}', {IdUsuario})", conn);

                command.ExecuteNonQuery(); 
                venta.Id = GetId.Get(command);
                venta.IdUser = IdUsuario;

                foreach (Producto producto in productos)
                {
                    SqlCommand command2 = new SqlCommand($"INSERT INTO ProductoVendido(Stoc,IdProducto,IdVenta) VALUES({producto.Stock},{producto.Id},{venta.Id})", conn);
                    command2.ExecuteNonQuery(); 
                    command2.Parameters.Clear();

                    SqlCommand command3 = new SqlCommand( $" UPDATE Producto SET Stock = (Stock - {producto.Stock}) WHERE Id = {producto.Id}",conn);

                    command3.ExecuteNonQuery(); 
                    command3.Parameters.Clear();
                }
            }
        }

    }
}

