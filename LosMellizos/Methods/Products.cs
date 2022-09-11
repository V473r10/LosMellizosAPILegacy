using LosMellizos.Settings;
using Microsoft.AspNetCore.SignalR;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace LosMellizos.Methods
{
    public static class Products
    {
        public static string NewProduct(string Product, int Stock, int Price)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.Create, conn);

            command.Parameters.AddWithValue("@Product", Product);
            command.Parameters.AddWithValue("@Stock", Stock);
            command.Parameters.AddWithValue("@Price", Price);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Producto creado correctamente" : "No se ha podido crear el producto";
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }

            return response;
        }

        public static DataTable Read([Optional] int Id)
        {
            DataTable products = new();

            string query = Id == 0 ? Database.Queries.Products.Read : Database.Queries.Products.GetById;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(query, conn);
            if (Id > 0)
            {
                command.Parameters.AddWithValue("@Id", Id);
            }

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                products.Load(reader);
            }
            finally { conn.Close(); }

            return products;
        }

        public static string Update(string Product, int Price, int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.Update, conn);
            command.Parameters.AddWithValue("@Product", Product);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"El producto n° {Id} ha sido actualizado con exito" : "No se ha actualizado ningun producto";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally { conn.Close(); }

            return response;
        }

        public static string ChangePrice(int Price, int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.ChangePrice, conn);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"El precio del producto n° {Id} ha sido actualizado con exito" : "No se ha actualizado ningun precio";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally { conn.Close(); }

            return response;
        }

        public static string AddStock(int Add, int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.AddStock, conn);
            command.Parameters.AddWithValue("@Stock", Add);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"Se han sumado {Add} unidades al stock del producto n° {Id}" : "No se ha podido actualizar el stock";
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return response;
        }
        
        public static string SubStock(int Sub, int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.SubStock, conn);
            command.Parameters.AddWithValue("@Stock", Sub);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"Se han restado {Sub} unidades al stock del producto n° {Id}" : "No se ha podido actualizar el stock";
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return response;
        }
        
        public static string SetStock(int Stock, int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.SetStock, conn);
            command.Parameters.AddWithValue("@Stock", Stock);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"Se ha ajustado el stock del producto n° {Id} a {Stock} unidades" : "No se ha podido actualizar el stock";
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return response;
        }

        public static string SetAvailable(bool Available, int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.SetAvailable, conn);
            command.Parameters.AddWithValue("@Available", Available);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                if (Available == true)
                {
                    response = rows > 0
                        ? $"Se ha disponibilizado el producto n° {Id}"
                        : "No se ha podido disponibilizar el producto";
                }
                else
                {
                    response = rows > 0 ? $"El producto n° {Id} se ha quitado de exhibición" : "No se ha podido quitar el producto";
                }
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            

            return response;
        }

        public static string Delete(int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Products.Delete, conn);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"Se ha eliminado el producto n° {Id}" : "No se ha podido eliminar";
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return response;
        }

    }
}
