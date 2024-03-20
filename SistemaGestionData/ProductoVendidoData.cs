using SistemaGestionEntities;
using System.Data.SqlClient;

namespace ProductosVendidoData
{
    public static class ProductoVendidoData
    {
        private static string connectionString = @"Server=localhost;Database=TiendaDatabase;Trusted_Connection=True;";

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            ProductoVendido productoVendido = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM ProductosVendidos WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        productoVendido = new ProductoVendido
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto vendido: " + ex.Message);
            }
            return productoVendido;
        }
        public static List<ProductosVendidos> ListarProductosVendidos(List<Producto> productos)
        {
            ProductoVendido productoVendido = null;
            List<ProductosVendidos> productosVendidos = new();
            ProductosVendidos productosVendidos1 = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (var producto in productos)
                    {
                        SqlCommand command = new SqlCommand("SELECT pv.Id, pv.IdProducto, p.Descripcion, p.PrecioVenta, p.Costo, pv.Stock, pv.IdVenta FROM ProductoVendido pv JOIN Producto p on p.Id = pv.IdProducto WHERE pv.IdProducto = @IdProducto", connection);
                        command.Parameters.AddWithValue("@IdProducto", producto.Id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            productosVendidos1 = new ProductosVendidos
                            {
                                id = Convert.ToInt32(reader["Id"]),
                                idProducto = Convert.ToInt32(reader["IdProducto"]),
                                idVenta = Convert.ToInt32(reader["IdVenta"]),
                                descripcion = reader["Descripcion"].ToString(),
                                costo = Convert.ToDouble(reader["Costo"]),
                                precioVenta = Convert.ToDouble(reader["PrecioVenta"]),
                                stock = Convert.ToInt32(reader["Stock"]),
                            };
                            productosVendidos.Add(productosVendidos1);
                        }

                        reader.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto vendido: " + ex.Message);
            }
            return productosVendidos;
        }

        public static ProductoVendido ObtenerUltimoProductoVendido()
        {
            ProductoVendido productoVendido = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP (1) * FROM ProductoVendido order by Id DESC", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        productoVendido = new ProductoVendido
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto vendido: " + ex.Message);
            }
            return productoVendido;
        }

        public static void CargarProductos(List<Producto> productos, int correlativoProductoVendido, int idVenta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (var producto in productos)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO ProductoVendido (Id, IdProducto, IdVenta) values (@Id, @IdProducto, @IdVenta)", connection);
                        command.Parameters.AddWithValue("@Id", correlativoProductoVendido);
                        command.Parameters.AddWithValue("@IdProducto", producto.Id);
                        command.Parameters.AddWithValue("@IdVenta", idVenta);
                        command.ExecuteNonQuery();
                        correlativoProductoVendido++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el producto vendido: " + ex.Message);
            }
        }
    }
}