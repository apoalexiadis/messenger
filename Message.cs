using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class Message
    {
        public User Sender;
        public User Receiver;
        public List<User> UserList;
        public DateTime timeOfSub;
        public string TextOfMessage { get; set; }

        public Message()
        {
            Sender = new User();
            Receiver = new User();
            UserList = new List<User>();
            timeOfSub = DateTime.Now;
        }

        public override string ToString()
        {        
            var sb = new StringBuilder();
            sb
                .AppendLine("-----------")
                .Append("Date of sub: ")
                .Append(timeOfSub.Date)
                .AppendLine()
                .Append("From: ")
                .Append(Sender.Username)
                .AppendLine()
                .Append("To: ")
                .Append(Receiver.Username)
                .AppendLine()
                .Append("Text:")
                .Append(TextOfMessage)
                .AppendLine()
                .AppendLine()
                .Append("-----------");


            return sb.ToString();
        }
    }
}
