using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Server
    {
        public void Start(string ip, int port)
        {
            DateTime myValue = DateTime.Now;


            // Строка ответа в соответсвии с протоколом HTTP (http://www.ietf.org/rfc/rfc2616.txt).
            var responseString = "HTTP/1.1 200 OK \r\n" +
                                 "Content-Type: text/plain \r\n" +
                                 "\r\n" +
                                 "Hello, World!";


            // Конвертируем строку в байты.
            var responseBytes = Encoding.UTF8.GetBytes(responseString);




            // Создаём буфер для считывания запросов.
            var buffer = new byte[1024];

            // Создаём Tcp сокет.
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Привязываем его к адресу http://127.0.0.1:8080/
            // (после запуска открыть ссылку в браузере, чтобы увидеть Hello, World!).
            IPAddress new_ip = IPAddress.Parse(ip);
            socket.Bind(new IPEndPoint(new_ip, port));


            // Начиинаем ждать подключений.
            socket.Listen(1);


            Console.WriteLine("Server started at " + ip + ":" + port);

            // Обрабатываем подключения в бесконечном цикле.

            while (true)
            {
                var time = DateTime.Now.ToLongTimeString();
                var ResponseString3 = "HTTP/1.1 200 OK \r\n" +
                         "Content-Type: text/plain \r\n" +
                         "\r\n" + time;
                var ResponseBytes3 = Encoding.UTF8.GetBytes(ResponseString3);


                var date = DateTime.Now.ToShortDateString();
                var responseString2 = "HTTP/1.1 200 OK \r\n" +
                                 "Content-Type: text/plain \r\n" +
                "\r\n" + date;
                var responseBytes2 = Encoding.UTF8.GetBytes(responseString2);

                // Принимаем поключение.
                using (var connection = socket.Accept())
                {
                    // Считываем запрос.
                    connection.Receive(buffer);
                    var x = Encoding.UTF8.GetString(buffer);
                    // Преобразуем запрос в строку и печатаем на экран.
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                    if (x.IndexOf("date") >= 0)
                    {
                        connection.Send(responseBytes2);
                    }
                    else if
                        (x.IndexOf("time") >= 0)
                    {

                        connection.Send(ResponseBytes3);

                    }
                    // Отправляем ответ.
                    else
                    {
                        connection.Send(responseBytes);
                    }

                }
            }
        }
    }
    public class Clibibl
    {
        public string download(int variant)
        {


            if (variant == 1)
            {
                string url = "http://127.0.0.1:8080/date";
                using (var webClient = new System.Net.WebClient())
                    return webClient.DownloadString(url);
            }
            else if (variant == 2)
            {
                string url = "http://127.0.0.1:8080/time";
                using (var webClient = new System.Net.WebClient())
                    return webClient.DownloadString(url);
            }
            else
            {
                string url = "http://127.0.0.1:8080/";
                using (var webClient = new System.Net.WebClient())
                    return webClient.DownloadString(url);
            }

        }
    }
}
