using Client.ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        static InstanceContext site = new InstanceContext(new Client());
        static ServerService.ServerClient proxy = new ServerService.ServerClient(site);
        //static ServerServiceMex.ServerClient proxy = new ServerServiceMex.ServerClient(site);
        static void Main(string[] args)
        {
            bool loggedIn = false;
            while (!loggedIn)
            {
                Client Client = new Client();
                Console.Write("Enter Login: ");
                string login = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                loggedIn = proxy.Authenticate(login, password);
            }
            Console.WriteLine("Login Successful");
            Console.WriteLine("Enter 'start' to start byte transfer, 'stop' to stop byte transfer, 'logout' to logout");
            while (true)
            {
                Console.Write("Enter Command: ");
                string command = Console.ReadLine();
                if (command.Equals("start"))
                    proxy.StartDataTransfer();
                else if (command.Equals("stop"))
                    proxy.StopDataTransfer();
                else if (command.Equals("logout"))
                {
                    proxy.Logout();
                    break;
                }
                else
                    Console.WriteLine("Invalid command");
            }
        }
    }
}
