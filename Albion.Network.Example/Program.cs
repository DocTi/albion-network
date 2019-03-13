using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System;
using System.Linq;

namespace Albion.Network.Example
{
    class Program
    {
        static AlbionParser albionParser;

        static void Main(string[] args)
        {
            albionParser = new AlbionParser();

            Console.WriteLine("Start");

            var device = PacketDeviceSelector.AskForPacketDevice();

            using (PacketCommunicator communicator = device.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                communicator.ReceivePackets(0, PacketHandler);
            }

            Console.Read();
        }

        static void PacketHandler(Packet packet)
        {
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (udp == null || (udp.SourcePort != 5056 && udp.DestinationPort != 5056))
            {
                return;
            }

            albionParser.ReceivePacket(udp.Payload.ToArray());
        }
    }
}
