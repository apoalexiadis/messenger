using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{

    class SuperAdmin : User
    {



        public SuperAdmin()
        {
            Username = "Admin";
            Password = "Admin";
        }

        public void CreateAUser()
        {
            using (DataConnection.sqlConnection)
            {
                try
                {
                    DataConnection.sqlConnection.Open();

                    Console.WriteLine("Enter Username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter Role 1,2 or 3");
                    int id_assignedRole = int.Parse(Console.ReadLine());

                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO [user](Username, Password, ID_AssignedRole) VALUES('{username}','{password}','{id_assignedRole}')", DataConnection.sqlConnection);
                    int rowsInserted = cmdInsert.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine("Insertion Successful");
                        Console.WriteLine($"{rowsInserted} rows inserted Successfully");
                        
                    }
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

        public void ViewAllUsers()
        {
            using (DataConnection.sqlConnection)
            {
                try
                {
                    DataConnection.sqlConnection.Open();

                    List<User> users = new List<User>();
                    SqlCommand cmdUsers = new SqlCommand($"SELECT ID,Username, Password, ID_AssignedRole FROM [user]", DataConnection.sqlConnection);
                    SqlDataReader readerUsers = cmdUsers.ExecuteReader();
                    Console.WriteLine("Users: ");
                    while (readerUsers.Read())
                    {
                        User user = new User()
                        {
                            ID = readerUsers.GetInt32(0),
                            Username = readerUsers.GetString(1),
                            Password = readerUsers.GetString(2),
                            ID_AssignedRole = readerUsers.GetInt32(3)
                        };
                        users.Add(user);

                    }

                    foreach (User user in users)
                    {
                        Console.WriteLine(user);
                    }

                    readerUsers.Close();
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

        public void DeleteAUser()
        {
            using (DataConnection.sqlConnection)
            {
                try
                {
                    DataConnection.sqlConnection.Open();

                    Console.WriteLine("Enter a user to DELETE:");
                    string usernameForDelete = Console.ReadLine();
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM [user] WHERE Username = '{usernameForDelete}'", DataConnection.sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    if (rowsDeleted > 0)
                    {
                        Console.WriteLine("Delete Succesfull");
                        Console.WriteLine($"{rowsDeleted} rows deleted successfully");
                    }
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

        public void UpdateAUser()
        {
            using (DataConnection.sqlConnection)
            {
                try
                {
                    DataConnection.sqlConnection.Open();

                    Console.WriteLine("Enter a User for Update: ");
                    string usernameForUpdate = Console.ReadLine();
                    Console.WriteLine("Enter a new Password for User: ");
                    string newPassword = Console.ReadLine();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE [user] SET Password = '{newPassword}' WHERE Name = '{usernameForUpdate}'", DataConnection.sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Succesfull");
                        Console.WriteLine($"{rowsUpdated} rows updates successfully");
                    }
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

        public void AssignARole()
        {
            using (DataConnection.sqlConnection)
            {
                try
                {
                    DataConnection.sqlConnection.Open();

                    Console.WriteLine("Enter a User for Update: ");
                    string usernameForUpdate = Console.ReadLine();
                    Console.WriteLine("Enter a new Role for User: ");
                    int newRole = int.Parse(Console.ReadLine());
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE [user] SET ID_AssignedRole = '{newRole}' WHERE Username = '{usernameForUpdate}'", DataConnection.sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        Console.WriteLine("Update Succesfull");
                        Console.WriteLine($"{rowsUpdated} rows updates successfully");
                    }
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
