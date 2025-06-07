using BusinessObjects;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        private static string connStr = DAO.GetConnectionString();

        public static AccountMember Login(string memberId, string password)
        {
            string sql = "SELECT * FROM AccountMember WHERE MemberID = @id AND MemberPassword = @pw";

            using SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", memberId);
            cmd.Parameters.AddWithValue("@pw", password);

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new AccountMember
                {
                    MemberId = reader["MemberID"].ToString(),
                    MemberPassword = reader["MemberPassword"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    MemberRole = Convert.ToInt32(reader["MemberRole"])
                };
            }

            return null;
        }
    }
}
