using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HelloWorldWebServer
{
    class Printer
    {
       public string ip;
    
        public string Print
        {
            get
            {
                return ip;
                
            }
          
        }
        
    }
    class Printer2
    {
        public int port;

        public int Print
        {
            get
            {
                return port;

            }
           
        }

    }/// <summary>/// <summary>
     /// Http сервер, который может обслуживать одновременно максимум одного клиента и на все запросы отвечает Hello, World!
     /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            Printer pr = new Printer();
            Printer2 pr2 = new Printer2();
            Console.WriteLine("Enter your ip:");
            pr.ip = Console.ReadLine();
            Console.WriteLine("Enter your port:");
            pr2.port = Convert.ToInt32(Console.ReadLine());
           new Server.Server().Start(pr.Print, pr2.Print);
           
            Console.ReadKey();

        }
    }
}
