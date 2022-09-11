using System.Data;
using System.Data.SqlClient;
using LosMellizos.Settings;

namespace LosMellizos.Methods
{
    public static class Orders
    {
        public static string Create(int Customer, string Address, List<int> Items, int ListPrice, int FinalPrice,
            string State, DateTime DeliveryDate)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.Create, conn);
            command.Parameters.AddWithValue("@Customer", Customer);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Items", Items);
            command.Parameters.AddWithValue("@ListPrice", ListPrice);
            command.Parameters.AddWithValue("@FinalPrice", FinalPrice);
            command.Parameters.AddWithValue("@State", State);
            command.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "La orden se ha creado satisfactoriamente." : "No se ha podido crear la orden";
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            finally { conn.Close(); }
            return response;
        }

        public static DataTable Read()
        {
            DataTable orders = new();
            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.Read, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }

        public static DataTable GetById(int Id)
        {
            DataTable orders = new();
            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.GetById, conn);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }

        public static DataTable GetByCustomer(int Customer)
        {
            DataTable orders = new();
            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.GetByCustomer, conn);
            command.Parameters.AddWithValue("@Customer", Customer);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }

        public static DataTable GetByCreateDate(DateTime CreateDate)
        {
            DataTable orders = new();
            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.GetByCreateDate, conn);
            command.Parameters.AddWithValue("@DeliveryDate", CreateDate);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }

        public static DataTable GetByDeliveryDate(DateTime DeliveryDate)
        {
            DataTable orders = new();
            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.GetByDeliveryDate, conn);
            command.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }
        public static DataTable GetByState(string State)
        {
            DataTable orders = new();
            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.GetByState, conn);
            command.Parameters.AddWithValue("@State", State);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }
        
        public static DataTable Update(string Address, List<int> Items, int ListPrice, int FinalPrice, DateTime DeliveryDate, int Id)
        {
            DataTable orders = new();

            var items = string.Join(", ", Items);

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.Update, conn);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Items", items);
            command.Parameters.AddWithValue("@ListPrice", ListPrice);
            command.Parameters.AddWithValue("@FinalPrice", FinalPrice);
            command.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                orders.Load(reader);

            }
            finally { conn.Close(); }
            return orders;
        }

        public static string Delete(int Id)
        {
            string response;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Orders.Delete, conn);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? $"Se ha eliminado la orden n° {Id}" : "No se ha podido eliminar";
            }
            catch (SqlException ex)
            {
                response = ex.Message;
            }
            finally { conn.Close(); }
            return response;
        }
    }
}
