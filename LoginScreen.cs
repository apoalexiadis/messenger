using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class LoginScreen
    {

        public static void Login()
        {
            using (DataConnection.sqlConnection)
            {
                try
                {
                    DataConnection.sqlConnection.Open();

                    //Login
                    Console.WriteLine("Enter username and password to Login:");
                    string usernameInserted = Console.ReadLine();
                    string passwordInserted = Console.ReadLine();

                    SqlCommand cmdLogin = new SqlCommand($"SELECT  Username, Password FROM [user] WHERE Username = '{usernameInserted}'AND Password = '{passwordInserted}'", DataConnection.sqlConnection);
                    SqlDataReader reader = cmdLogin.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("You have been Logged In Successfully");

                        ApplicationMenu.AppMenuOptions();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DataConnection.sqlConnection.Close();
                }
            }
        }
    }
}
