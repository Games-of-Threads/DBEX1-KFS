using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEX1_KFS
{
    class Program
    {
        static void Main(string[] args)
        {
            string state = "start";
            bool running = true;
            simple_db db = new simple_db();
            while (running)
            {
                switch (state)
                {
                    case "start":
                        Console.WriteLine("Welcome to the program \n add: to add people \n check: to check for people \n exit: to exit the program");
                        state = Console.ReadLine();
                        break;
                    case "add":
                        Console.WriteLine("What do you wish to add?");
                        Console.WriteLine("ID can be selected or defaulted with 0");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name?");
                        string name = Console.ReadLine();
                        Console.WriteLine("Current occupation?");
                        string status = Console.ReadLine();
                        Console.WriteLine("Great one moment...");
                        db.AddPerson(id, name, status);
                        Console.ReadKey();
                        Console.Clear();
                        state = "start";
                        break;
                    case "check":
                        Console.WriteLine("What do you wish to check?");
                        db.CheckPerson(int.Parse(Console.ReadLine()));
                        Console.ReadKey();
                        Console.Clear();
                        state = "start";
                        break;
                    case "exit":
                        Console.WriteLine("bye bye!");
                        Console.ReadKey();
                        running = false;
                        state = "";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
