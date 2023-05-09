using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY_MANAGEMENT
{
    internal class MyConnection
    {
        public MyConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-L780H7UQ;Initial Catalog=Login;Integrated Security=True");
        }
        public static string Type;
    }
}
