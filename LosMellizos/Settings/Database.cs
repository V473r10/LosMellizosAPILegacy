namespace LosMellizos.Settings
{
    public static class Database
    {
        public static string ConnectionString { get; } = "DATA SOURCE = MSI; INITIAL CATALOG = LosMellizos; USER = sa; PASSWORD=v473r10;";

        public static class Queries
        {
            public static class Users
            {
                public static string Create { get; } = @"INSERT INTO Users SELECT
                                                            @FirstName,
                                                            @LastName,
                                                            @Email,
                                                            @UserName,
                                                            @Pass,
                                                            @UserLevel ";

                public static string Login { get; } = @"SELECT * FROM Users WHERE UserName = @UserName AND Pass = @Pass";
                public static string ChangePass { get; } = @"UPDATE Users SET Pass = @Pass WHERE Id = @Id";
                public static string Read { get; } = @"SELECT * FROM Users";
                public static string Update { get; } = @"UPDATE Users SET
                                                            FirstName = @FirstName,
                                                            LastName = @LastName,
                                                            Email = @Email,
                                                            UserName = @UserName
                                                            WHERE
                                                            Id = @Id ";

                public static string Delete { get; } = @"DELETE Users WHERE Id = @Id";
            }
            
            public static class Products
            {
                public static string Create { get; } = @"INSERT INTO Products SELECT
                                                            @Product,
                                                            @Stock,
                                                            @Price";

                public static string Read { get; } = @"SELECT * FROM Products";
                public static string GetById { get; } = @"SELECT * FROM Products WHERE Id = @Id";
                public static string Update { get; } = @"UPDATE Products SET
                                                            Product = @Product,
                                                            Price = @Price
                                                            WHERE Id = @Id";

                public static string ChangePrice { get; } = @"UPDATE Products SET
                                                            Price = @Price
                                                            WHERE Id = @Id";

                public static string AddStock { get; } = @"UPDATE Products SET
                                                            Stock = Stock + @Add
                                                            WHERE Id = @Id";
                
                public static string SubStock { get; } = @"UPDATE Products SET
                                                            Stock = Stock - @Sub
                                                            WHERE Id = @Id";

                public static string SetStock { get; } = @"UPDATE Products SET
                                                            Stock = @Stock
                                                            WHERE Id = @Id";

                public static string SetAvailable { get; } = @"UPDATE Products SET
                                                                Available = @Available
                                                                WHERE Id = @Id";

                public static string Delete { get; } = @"DELETE Products WHERE Id = @Id";
            }

            public static class Orders
            {
                public static string Read { get; } = @"SELECT * FROM Orders";
                public static string GetByState { get; } = @"SELECT * FROM Orders WHERE State = @State";
                public static string GetByCustomer { get; } = @"SELECT * FROM Orders WHERE Customer = @Customer";
                public static string GetById { get; } = @"SELECT * FROM Orders WHERE Id = @Id";
                public static string GetByCreateDate { get; } = @"SELECT * FROM Orders WHERE CONVERT(VARCHAR, CreateDate, 23) = @CreateDate";
                public static string GetByDeliveryDate { get; } = @"SELECT * FROM Orders WHERE CONVERT(VARCHAR, DeliveryDate, 23) = @DeliveryDate";
                public static string Create { get; } = @"INSERT INTO Orders SELECT @Customer, @Address, @Items, @ListPrice, @FinalPrice, @State, GETDATE(), @DeliveryDate";
                public static string Update { get; } = @"UPDATE Orders SET Address = @Address, Items = @Items, ListPrice = @ListPrice, FinalPrice = @FinalPrice, DeliveryDate = @DeliveryDate WHERE Id = @Id";
                public static string Delete { get; } = @"DELETE Orders WHERE Id = @Id";
            }

            public static class Customers
            {
                public static string Create { get; } = @"INSERT INTO Customers SELECT @FirstName, @LastName, @UserName, @Email, @Pass, @Address, @Phone, @Class";
                public static string Read { get; } = @"SELECT * FROM Customers";
                public static string GetById { get; } = @"SELECT * FROM Customers WHERE Id = @Id";
                public static string Update { get; } = @"UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Email = @Email, Pass = @Pass, Address = @Address, Phone = @Phone, Class = @Class WHERE Id = @Id";
                public static string ChangeClass { get; } = @"UPDATE Customers SET Class = @Class WHERE Id = @Id";
                public static string Delete { get; } = @"DELETE Customers WHERE Id = @Id";
            }

            public static class CustomersClasses
            {
                public static string Create { get; } = @"INSERT INTO CustomersClasses SELECT @Id, @Threshold, @Discount";
                public static string Read { get; } = @"SELECT * FROM CustomersClasses";
                public static string GetById { get; } = @"SELECT * FROM CustomersClasses WHERE Id = @Id";
                public static string Update { get; } = @"UPDATE CustomersClasses SET Threshold = @Threshold, Discount = @Discount WHERE Id = @Id";
                public static string Delete { get; } = @"DELETE CustomersClasses WHERE Id = @Id";
            }
        }
    }
}
