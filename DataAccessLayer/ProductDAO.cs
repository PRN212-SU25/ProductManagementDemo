using BusinessObjects;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static string connStr = DAO.GetConnectionString();

        public static void AddProduct(Product p)
        {
            string sql = "INSERT INTO Products (ProductName, CategoryID, UnitsInStock, UnitPrice) VALUES (@name, @cat, @stock, @price)";
            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", p.ProductName);
            cmd.Parameters.AddWithValue("@cat", p.CategoryId);
            cmd.Parameters.AddWithValue("@stock", p.UnitInStock);
            cmd.Parameters.AddWithValue("@price", p.UnitPrice);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void UpdateProduct(Product p)
        {
            string sql = "UPDATE Products SET ProductName = @name, CategoryID = @cat, UnitsInStock = @stock, UnitPrice = @price WHERE ProductID = @id";
            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", p.ProductId);
            cmd.Parameters.AddWithValue("@name", p.ProductName);
            cmd.Parameters.AddWithValue("@cat", p.CategoryId);
            cmd.Parameters.AddWithValue("@stock", p.UnitInStock);
            cmd.Parameters.AddWithValue("@price", p.UnitPrice);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void DeleteProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductID = @id";
            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static Product GetProductById(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductID = @id";
            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    ProductId = Convert.ToInt32(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString(),
                    CategoryId = Convert.ToInt32(reader["CategoryID"]),
                    UnitInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
            }
            return null;
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string sql = "SELECT * FROM Products";
            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    ProductId = Convert.ToInt32(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString(),
                    CategoryId = Convert.ToInt32(reader["CategoryID"]),
                    UnitInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                });
            }
            return list;
        }
    }
}
