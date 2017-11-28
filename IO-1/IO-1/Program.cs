using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace IO1
{
    //******************ZAD1***************************//
    class Zad1
    {
        private static void ThreadProc(Object stateInfo)
        {
            var time = ((object[])stateInfo)[0];
            Thread.Sleep((int)time);
            Console.WriteLine("watek poczekal: " + time + " ms");
        }

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { 1000 });
            Thread.Sleep(3000);
        }
    }


    //******************ZAD2***************************//
    /*
        class Zad2
        {
            static void Main(string[] args)
            {
                ThreadPool.QueueUserWorkItem(Server);
                ThreadPool.QueueUserWorkItem(Client, "Hello from Client 1");
                ThreadPool.QueueUserWorkItem(Client, "Hello from Client 2");
                Thread.Sleep(5000);

            }

            private static void Server(Object stateInfo)
            {
                TcpListener server = new TcpListener(IPAddress.Any, 2048);
                server.Start();
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    byte[] buffer = new byte[1024];
                    client.GetStream().Read(buffer, 0, 1024);
                    Console.WriteLine("Message from client: " + Encoding.UTF8.GetString(buffer));
                    client.GetStream().Write(buffer, 0, 1024);
                    client.Close();
                }
                server.Stop();
            }

            private static void Client(Object stateInfo)
            {
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
                NetworkStream stream = client.GetStream();

                var byteMessage = new ASCIIEncoding().GetBytes((string)stateInfo);
                client.GetStream().Write(byteMessage, 0, byteMessage.Length);

                while (true)
                {
                    byte[] buffer = new byte[1024];

                    if (client.GetStream().DataAvailable)
                    {
                        client.GetStream().Read(buffer, 0, 1024);
                        Console.WriteLine("Server respond: " + Encoding.UTF8.GetString(buffer));
                    }

                }
            }
        }
        */

    //******************ZAD3***************************//
    /*
    class Zad3
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Server);
            ThreadPool.QueueUserWorkItem(Client, "Hello from Client 1");
            ThreadPool.QueueUserWorkItem(Client, "Hello from Client 2");
            Thread.Sleep(5000);
            System.Console.Read();
        }

        private static void Server(Object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(ConnectionHandler, client);
         
            }
            server.Stop();
        }

        private static void Client(Object stateInfo)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
            NetworkStream stream = client.GetStream();

            var byteMessage = new ASCIIEncoding().GetBytes((string)stateInfo);
            client.GetStream().Write(byteMessage, 0, byteMessage.Length);

            while (true)
            {
                byte[] buffer = new byte[1024];

                if (client.GetStream().DataAvailable)
                {
                    client.GetStream().Read(buffer, 0, 1024);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Server respond: " + Encoding.UTF8.GetString(buffer));
                }

            }
        }

        private static void ConnectionHandler(Object stateInfo)
        {
            var client = (TcpClient)stateInfo;
            byte[] buffer = new byte[1024];
            int a = client.GetStream().Read(buffer, 0, 1024);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Message from client: " + Encoding.UTF8.GetString(buffer));
            client.GetStream().Write(buffer, 0, a);
            client.Close();
        }
    }
    */

    //******************ZAD4***************************//
    /*
    class Zad4
    {
        public static Object thislock = new Object();

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Server);
            ThreadPool.QueueUserWorkItem(Client, "Hello from Client 1");
            ThreadPool.QueueUserWorkItem(Client, "Hello from Client 2");
            Thread.Sleep(5000);
            System.Console.Read();
        }
        
        private static void Server(Object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(ConnectionHandler, client);

            }
            // server.Stop();
        }

        private static void Client(Object stateInfo)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
            NetworkStream stream = client.GetStream();

            var byteMessage = new ASCIIEncoding().GetBytes((string)stateInfo);
            client.GetStream().Write(byteMessage, 0, byteMessage.Length);

            while (true)
            {
                byte[] buffer = new byte[1024];

                if (client.GetStream().DataAvailable)
                {
                    client.GetStream().Read(buffer, 0, 1024);
                    lock (thislock)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Server respond: " + Encoding.UTF8.GetString(buffer));
                    }
                }

            }
        }

        private static void ConnectionHandler(Object stateInfo)
        {
            var client = (TcpClient)stateInfo;
            byte[] buffer = new byte[1024];
            int a = client.GetStream().Read(buffer, 0, 1024);
            lock (thislock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Message from client: " + Encoding.UTF8.GetString(buffer));
            }
            client.GetStream().Write(buffer, 0, a);
            client.Close();
        }
    }
    
    */
    //*************************************************//

}