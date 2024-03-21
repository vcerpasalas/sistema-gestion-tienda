using SistemaGestionEntities;
using System.Data.SqlClient;

namespace ProductosData
{
    public static class ProductoData
    {
        private static string connectionString = @"Server=localhost;Database=TiendaDatabase;Trusted_Connection=True;";

        public static Producto ObtenerProducto(int id)
        {
            Producto producto = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = Convert.ToDouble(reader["Costo"]),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto: " + ex.Message);
            }
            return producto;
        }

        public static Producto ObtenerProducto(int idProducto, int idUsuario)
        {
            Producto producto = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE Id = @Id AND IdUsuario = @IdUsuario", connection);
                    command.Parameters.AddWithValue("@Id", idProducto);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = Convert.ToDouble(reader["Costo"]),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto: " + ex.Message);
            }
            return producto;
        }

        public static Producto ObtenerUltimoProducto()
        {
            Producto producto = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP (1) * FROM Producto order by Id DESC", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = Convert.ToDouble(reader["Costo"]),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto: " + ex.Message);
            }
            return producto;
        }

        public static List<Producto> ListarProductos(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", connection);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        Producto producto = new Producto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = Convert.ToDouble(reader["Costo"]),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"])
                        };
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la lista de productos: " + ex.Message);
            }
            return productos;
        }

        public static void CrearProducto(Producto producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Producto (Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Id, @Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario)", connection);
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el producto: " + ex.Message);
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE PRODUCTO SET Descripcion =@Descripcion, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el producto: " + ex.Message);
            }
        }

        public static void EliminarProducto(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM PRODUCTO WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto: " + ex.Message);
            }
        }
    }
}
