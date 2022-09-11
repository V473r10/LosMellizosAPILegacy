using LosMellizos.Settings;
using System.Data;
using System.Data.SqlClient;

namespace LosMellizos.Methods
{
    public static class Users
    {
        public static string SignUp(string FirstName, string LastName, string Email, string UserName, string Pass, int UserLevel)
        {
            string response = string.Empty;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Users.Create, conn);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Pass", Pass);
            command.Parameters.AddWithValue("@UserLevel", UserLevel);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Usuario creado correctamente" : "No se pudo crear el usuario";
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

        public static dynamic Login(string UserName, string Pass)
        {
            bool response = false;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Users.Login, conn);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Pass", Pass);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                response = reader.HasRows;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return response;
            
        }

        public static string Update(string FirstName, string LastName, string Email, string UserName, int Id)
        {
            string response = string.Empty;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Users.Update, conn);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Usuario actualizado correctamente" : "No se pudo actualizar el usuario";
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

        public static string ChangePass(int Id, string Pass)
        {
            string response = string.Empty;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Users.ChangePass, conn);

            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Pass", Pass);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Contraseña cambiada correctamente" : "No se pudo cambiar la contraseña";
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
            string response = string.Empty;

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Users.Delete, conn);

            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                conn.Open();
                int rows = command.ExecuteNonQuery();
                response = rows > 0 ? "Usuario eliminado correctamente" : "No se pudo eliminar el usuario";
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

        public static DataTable Read()
        {
            DataTable Users = new();

            SqlConnection conn = new(Database.ConnectionString);
            SqlCommand command = new(Database.Queries.Users.Read, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Users.Load(reader);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Users;
        }
    }
}
