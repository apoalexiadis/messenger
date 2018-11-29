using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class User
    {

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ID_AssignedRole { get; set; }

        public Message SMessage()
        {
            Message message = new Message();
            message.Sender.Username = Username;

            Console.WriteLine("To who:");
            string receiverUsername = Console.ReadLine();
            //if exitst check!
            message.Receiver.Username = receiverUsername;

            Console.WriteLine("Write your text");
            message.TextOfMessage = Console.ReadLine();
            if (File.Exists($@"C:\UsersContact\{message.Receiver.Username}"))
            {
                File.WriteAllText($@"C:\UsersContact\{message.Receiver.Username}\{message.Sender.Username}TO{message.Receiver.Username}.txt", message.TextOfMessage);
            }
            else
            {
                //create a folder for incoming messages
                Directory.CreateDirectory($@"C:\UsersContact\{message.Receiver.Username}");
                File.WriteAllText($@"C:\UsersContact\{message.Receiver.Username}\{message.Sender.Username}TO{message.Receiver.Username}.txt", message.TextOfMessage);
            }

            

            message.timeOfSub = DateTime.Now.Date;

            return message;
        }

        public Message SendAMessage()
        {
            Message message = new Message();
            using (DataConnection.sqlConnection)
            {
                try
                {
                    //DataConnection.sqlConnection.Open();

                    
                    Console.WriteLine("From Who");
                    message.Sender.Username = Console.ReadLine();
                    Console.WriteLine("To who");
                    message.Receiver.Username = Console.ReadLine();
                    Console.WriteLine("Enter Text");
                    message.TextOfMessage = Console.ReadLine();
                    message.timeOfSub = DateTime.Now.Date;

                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO [message](DateOfSub, ID_User_Sender, ID_User_Receiver, Text) VALUES('{message.timeOfSub}','{message.Sender.ID}','{message.Receiver.ID}','{ message.TextOfMessage}')", DataConnection.sqlConnection);
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
                    //DataConnection.sqlConnection.Close();
                }
            }
            return message;
        }

        public Message ReadMessage()
        {
            Message message = new Message();
            string text = File.ReadAllText($@"C:\UsersContact\{message.Receiver.Username}\{message.Sender.Username}TO{message.Receiver.Username}.txt");
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            return message;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .Append($"User ID is {ID}\t")
                .Append($"Username is {Username}\t")
                .Append($"Password is {Password}\t")
                .Append($"ID_AssignedRole is {ID_AssignedRole}");

            return sb.ToString();
        }


    }
}
