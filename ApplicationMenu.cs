using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual
{
    class ApplicationMenu
    {
        public static int MenuOption { get; set; }
        public static User user = new User();



        public static void AppMenuOptions()
        {
            Console.WriteLine("Here are all the menu options");
            Console.WriteLine("To send a message press 1");
            Console.WriteLine("To view a message press 2");
            Console.WriteLine("To update a message press 3");
            Console.WriteLine("To delete a message press 4");
            MenuOption = Convert.ToInt32(Console.ReadLine());
            switch (MenuOption)
            {
                case 1:
                    var message = user.SendAMessage();
                    Console.WriteLine(message);
                    break;
                case 2:
                    user.ReadMessage();


                    break;
                case 3:
                    //from all save messages update one
                    break;
                case 4:
                    //from all save messages delete one
                    break;
                default:

                    break;
            }
        }
    }
}
