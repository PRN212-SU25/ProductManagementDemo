using BusinessObjects;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        private static string connStr = DAO.GetConnectionString();

        public static List<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            string sql = "SELECT * FROM Categories";

            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Category
                {
                    CategoryId = Convert.ToInt32(reader["CategoryID"]),
                    CategoryName = reader["CategoryName"].ToString()
                });
            }
            return list;
        }
    }
}