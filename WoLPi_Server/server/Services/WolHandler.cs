using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace server.Services
{
    public class WolHandler
    {
        public void Broadcast()
        {
            try
            {
                PhysicalAddress target = PhysicalAddress.Parse("2C:FD:A1:BB:A1:F6");
                //PhysicalAddress target = PhysicalAddress.Parse("00:21:70:c2:c1:88");

                SendWakeOnLan(target);
            }
            catch (Exception x) { Console.WriteLine(x.Message); }
        }

        void SendWakeOnLan(PhysicalAddress target)
        {
            var header = Enumerable.Repeat(byte.MaxValue, 6);
            var data = Enumerable.Repeat(target.GetAddressBytes(), 16).SelectMany(mac => mac);

            var magicPacket = header.Concat(data).ToArray();

            Console.WriteLine(magicPacket);

            using var client = new UdpClient();

            client.Send(magicPacket, magicPacket.Length, new IPEndPoint(IPAddress.Broadcast, 9));
        }
    }
}
