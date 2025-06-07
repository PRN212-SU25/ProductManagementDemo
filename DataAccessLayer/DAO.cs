using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DataAccessLayer
{
    public class DAO
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyStoreDB"].ConnectionString;
        }
    }
}
