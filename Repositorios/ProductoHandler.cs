using SistemaGestionProyectoFinal.Models;
using System.Data.SqlClient;

namespace SistemaGestionProyectoFinal.Repositorios
{
    internal static class ProductoHandler
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DKO2V17;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                SqlCommand comand = new SqlCommand("SELECT * FROM Producto", connection);
                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoTemporal = new Producto();
                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Description = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUser = reader.GetInt64(5);

                        productos.Add(productoTemporal);
                    }
                }
                return productos;
            }

        }
        public static Producto ObtenerProducto(string description)
        {
            Producto producto = new Producto();
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                SqlCommand comand = new SqlCommand($"SELECT * FROM Producto WHERE Descripciones ='{description}' ", connection);
                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {

                    {
                        reader.Read();
                        producto.Id = reader.GetInt64(0);
                        producto.Description = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUser = reader.GetInt64(5);

                    }
                }
                return producto;
            }

        }
        public static int InsertarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                SqlCommand comand = new SqlCommand($"INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" +
                    $" VALUES('{producto.Description}',{producto.Costo},{producto.PrecioVenta},{producto.Stock},{producto.IdUser})", connection);

                return comand.ExecuteNonQuery();
            }
        }

        public static List<Producto> ObtenerProductosCargadoPorUsuario(long IdUser)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                SqlCommand comand = new SqlCommand($"Select * From Producto Where IdUsuario ={IdUser} ", connection);
                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoTemporal = new Producto();
                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Description = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUser = reader.GetInt64(5);

                        productos.Add(productoTemporal);
                    }
                }
                return productos;
            }
        }

        public static Producto ObtenerProducto(long id)
        {
            Producto producto = new Producto();
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                SqlCommand comand = new SqlCommand($"SELECT * FROM Producto WHERE id ='{id}' ", connection);
                connection.Open();

                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {

                    {
                        reader.Read();
                        producto.Id = reader.GetInt64(0);
                        producto.Description = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUser = reader.GetInt64(5);

                    }
                }
                return producto;
            }

        }


        public static int DeleteProducto(long id)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand command = new SqlCommand($" DELETE From ProductoVendido WHERE IdProducto = {id}", connection);
                    SqlCommand command1 = new SqlCommand($"DELETE FROM PRODUCTO WHERE id = {id}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return command1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("" + e.Message);
                    return -1;
                }
            }
        }

        public static int UpdateProduct(Producto product)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {

                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Producto SET Descripciones = '{product.Description}', Costo ={product.Costo}, PrecioVenta = {product.PrecioVenta}, Stock = {product.Stock}, IdUsuario ={product.IdUser}  WHERE Id = {product.Id}", connection);

                return command.ExecuteNonQuery();
            }
        }


    }
}
