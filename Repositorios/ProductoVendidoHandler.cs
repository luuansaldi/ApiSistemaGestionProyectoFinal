
using SistemaGestionProyectoFinal.Models;
using System.Data.SqlClient;

namespace SistemaGestionProyectoFinal.Repositorios
{
    internal class ProductoVendidoHandler
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DKO2V17;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                List<long> idProductos = new List<long>();
                SqlCommand comand = new SqlCommand($"SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = {idUsuario}", connection);
                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));
                    }
                }
                List<Producto> productos = new List<Producto>();
                foreach (var item in idProductos)
                {
                    Producto prodTemp = ProductoHandler.ObtenerProducto(item);
                    productos.Add(prodTemp);
                }

                return productos;
            }
        }

        //public static void InsertarProductoVendido(ProductoVendido productoVendido)
        //{
        //    using (SqlConnection conn = new SqlConnection(cadenaConexion))
        //    {
                
        //        SqlCommand command = new SqlCommand($"INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) VALUES ({productoVendido.Stock},{productoVendido.IdProducto},{idVenta})",conn);
        //        conn.Open();
        //        command.ExecuteReader();
        //    }
        //}
    }
}
