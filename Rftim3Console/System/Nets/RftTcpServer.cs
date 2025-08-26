using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Rftim3Console.System.Nets
{
    public class RftTcpServer
    {
        public RftTcpServer()
        {
            //_ = StartServer();
            //_ = CreateSocket();
            _ = RftServer();
        }

        public static async Task StartServer()
        {
            IPEndPoint ipEndPoint = new(IPAddress.Loopback, 50000);
            TcpListener listener = new(ipEndPoint);

            try
            {
                listener.Start();
                Console.WriteLine($"Server started on {ipEndPoint.Address}:{ipEndPoint.Port}");

                while (true)
                {
                    using TcpClient handler = await listener.AcceptTcpClientAsync();
                    await using NetworkStream stream = handler.GetStream();

                    string message = $"📅 {DateTime.Now} 🕛";
                    byte[] dateTimeBytes = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(dateTimeBytes);

                    Console.WriteLine($"Sent message: \"{message}\"");
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        public static async Task CreateSocket()
        {
            IPEndPoint ipEndPoint = new(IPAddress.Loopback, 50000);
            using Socket listener = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);

            Socket handler = await listener.AcceptAsync();
            while (true)
            {
                // Receive message.
                byte[] buffer = new byte[1_024];
                int received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                string response = Encoding.UTF8.GetString(buffer, 0, received);

                string eom = "<|EOM|>";
                if (response.IndexOf(eom) > -1 /* is end of message */)
                {
                    Console.WriteLine($"Socket server received message: \"{response.Replace(eom, "")}\"");

                    string ackMessage = "<|ACK|>";
                    byte[] echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    await handler.SendAsync(echoBytes, 0);
                    Console.WriteLine($"Socket server sent acknowledgment: \"{ackMessage}\"");

                    break;
                }
            }
        }

        public static async Task RftServer()
        {
            IPAddress ipAddress = IPAddress.Loopback;
            int port = 50000;
            TcpListener listener = new(ipAddress, port);
            listener.Start();
            await Console.Out.WriteLineAsync($"Server started on {ipAddress}:{port}");

            try
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    await Console.Out.WriteLineAsync("Client connected");

                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    await Console.Out.WriteLineAsync($"Data received: {dataReceived}");

                    string message = $"Server sent at: 📅 {DateTime.Now} 🕛";
                    byte[] dateTimeBytes = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(dateTimeBytes);

                    client.Close();
                }
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
