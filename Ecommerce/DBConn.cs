using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ecommerce
{
    public class DBConn
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DbCommConnectionString"].ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

    }
}