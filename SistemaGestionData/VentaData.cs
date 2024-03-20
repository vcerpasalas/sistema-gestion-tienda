using SistemaGestionEntities;
using System;
using System.Data.SqlClient;

namespace VentasData
{
    public static class VentaData
    {
        private static string connectionString = @"Server=localhost;Database=TiendaDatabase;Trusted_Connection=True;";

        public static Venta ObtenerVenta(int id)
        {
            Venta venta = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Ventas WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        venta = new Venta
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Comentarios = reader["Comentarios"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la venta: " + ex.Message);
            }
            return venta;
        }

        public static Venta ObtenerUltimaVenta()
        {
            Venta venta = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP (1) * FROM VENTA order by Id DESC", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        venta = new Venta
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Comentarios = reader["Comentarios"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el venta: " + ex.Message);
            }
            return venta;
        }


        public static void CrearVenta(Venta venta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Venta (Id,Comentarios) VALUES (@Id, @Comentarios)", connection);
                    command.Parameters.AddWithValue("@Id", venta.Id);
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la venta: " + ex.Message);
            }
        }
    }
}