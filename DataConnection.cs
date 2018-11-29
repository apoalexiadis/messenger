using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class DataConnection
    {
        public static string connectionString =
            @"Server = APOSTOLOS-PC\SQLEXPRESS;Database = EducationalContactDB; Trusted_Connection =True";
   
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);

        
    }
}
