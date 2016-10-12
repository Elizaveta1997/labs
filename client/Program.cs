using System;
using System.Threading;

namespace client
{
    class client
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your ip:");
            string ip = Console.ReadLine();
            Console.WriteLine("Enter your port:");
            var port = Convert.ToInt32(Console.ReadLine());

            var client = new Server.Clibibl();

            while (true)
            {

                Console.WriteLine("1)Date or 2)Time or 3) to exit");
                int variant = Convert.ToInt32(Console.ReadLine());

                if (variant == 1)
                {
                    Console.WriteLine(client.download(variant));
                }
                if (variant == 2)
                {
                    Console.WriteLine(client.download(variant));
                }
                if (variant == 3)
                {
                    break;
                }
            }

        }

    }
}
