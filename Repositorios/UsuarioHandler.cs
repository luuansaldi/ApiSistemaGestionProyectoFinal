

using SistemaGestionProyectoFinal.Models;
using System.Data.SqlClient;

namespace SistemaGestionProyectoFinal.Repositorios
{
    internal static class UsuarioHandler
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DKO2V17;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void TraerUsuario(string username)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Usuario Where NombreUsuario = '{username}'", conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Name = reader.GetString(1);
                    usuario.Lastname = reader.GetString(2);
                    usuario.Username = reader.GetString(3);
                    usuario.Password = reader.GetString(4);
                    usuario.Email = reader.GetString(5);
                }

                Console.WriteLine($"Nombre {usuario.Name}");
                Console.WriteLine($"Apellido {usuario.Lastname}");
                Console.WriteLine($"Nombre de usuario {usuario.Username}");
                Console.WriteLine($"Contraseña {usuario.Password}");
                Console.WriteLine($"Email {usuario.Email}");

            }

        }

        public static Usuario Login(string username, string password)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comand = new SqlCommand($"Select * FROM Usuario WHERE NombreUsuario = '{username}' AND Contraseña = '{password}' ", conn);
                conn.Open();
                SqlDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Name = reader.GetString(1);
                    usuario.Lastname = reader.GetString(2);
                    usuario.Username = reader.GetString(3);
                    usuario.Password = reader.GetString(4);
                    usuario.Email = reader.GetString(5);
                    return usuario;

                }
                else
                {
                    return null;
                }

            }
        }
        public static int Register(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                SqlCommand comand = new SqlCommand($"INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail)" +
                    $" VALUES('{usuario.Name}','{usuario.Lastname}','{ usuario.Username}','{usuario.Password}','{usuario.Email}')", connection);

                return comand.ExecuteNonQuery();
            }
        }

        public static int UpdateUser(Usuario usuario)
        {
            using(SqlConnection connection = new SqlConnection(cadenaConexion))
            {

                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Usuario SET Nombre = '{usuario.Name}', Apellido = '{usuario.Lastname}', NombreUsuario = '{usuario.Username}', Contraseña = '{usuario.Password}', Mail='{usuario.Email}' WHERE Id='{usuario.Id}'", connection);

                return command.ExecuteNonQuery();
            }
        }




    }
}
