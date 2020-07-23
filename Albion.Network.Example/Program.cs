using Albion.Common;
using Albion.Event;
using Albion.Operation;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System;
using System.Linq;
using System.Threading;

namespace Albion.Network.Example
{
    internal class Program
    {
        private static IPhotonReceiver receiver;

        private static void Main(string[] args)
        {
            ReceiverBuilder builder = ReceiverBuilder.Create();

            builder.AddRequestHandler<MoveOperation>(OperationCodes.Move, (operation) =>
            {
                Console.WriteLine($"Move request");
            });
            builder.AddEventHandler<MoveEvent>(EventCodes.Move, (operation) =>
            {
                Console.WriteLine($"Id: {operation.Id} x: {operation.Position[0]} y: {operation.Position[1]}");
            });
            builder.AddEventHandler<NewCharacterEvent>(EventCodes.NewCharacter, (operation) =>
            {
                Console.WriteLine($"New ch Id: {operation.Id}");
            });

            receiver = builder.Build();

            Console.WriteLine("Start");

            var devices = LivePacketDevice.AllLocalMachine;
            foreach (var device in devices)
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Open... {device.Description}");

                    using (PacketCommunicator communicator = device.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
                    {
                        communicator.ReceivePackets(0, PacketHandler);
                    }
                })
                .Start();
            }

            Console.Read();
        }

        private static void PacketHandler(Packet packet)
        {
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (udp == null || (udp.SourcePort != 5056 && udp.DestinationPort != 5056))
            {
                return;
            }

            receiver.ReceivePacket(udp.Payload.ToArray());
        }
    }
}
