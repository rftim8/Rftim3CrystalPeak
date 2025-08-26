using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Rftim3WinFormsUCL.RftSockets
{
    public partial class RftTCPIPUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftTCPIPUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //_ = StartClient();
            //_ = CreateClient();
            //_ = RftClient();
        }

        public static async Task StartClient()
        {
            IPEndPoint ipEndPoint = new(IPAddress.Loopback, 50000);

            using TcpClient client = new();
            await client.ConnectAsync(ipEndPoint);
            await using NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1_024];
            int received = await stream.ReadAsync(buffer);

            string message = Encoding.UTF8.GetString(buffer, 0, received);
            Console.WriteLine($"Message received: \"{message}\"");
        }

        public static async Task CreateClient()
        {
            IPEndPoint ipEndPoint = new(IPAddress.Loopback, 50000);
            using Socket client = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            await client.ConnectAsync(ipEndPoint);
            while (true)
            {
                // Send message.
                string message = "Hi friends 👋!<|EOM|>";
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message}\"");

                // Receive ack.
                byte[] buffer = new byte[1_024];
                int received = await client.ReceiveAsync(buffer, SocketFlags.None);
                string response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.WriteLine($"Socket client received acknowledgment: \"{response}\"");
                    break;
                }
            }

            client.Shutdown(SocketShutdown.Both);
        }

        public async Task RftClient()
        {
            IPEndPoint ipEndPoint = new(IPAddress.Loopback, 50000);

            TcpClient client = new();
            await client.ConnectAsync(ipEndPoint);
            NetworkStream stream = client.GetStream();

            string send = $"From client";
            byte[] sendMessage = Encoding.UTF8.GetBytes(send);
            await stream.WriteAsync(sendMessage);

            byte[] buffer = new byte[1_024];
            int received = await stream.ReadAsync(buffer);
            string message = Encoding.UTF8.GetString(buffer, 0, received);
            textBox2.Text += $"Message received: \"{message}\"\n";
        }
    }
}
