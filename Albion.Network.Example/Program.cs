using PacketDotNet;
using SharpPcap;
using System;
using System.Threading;

namespace Albion.Network.Example
{
    internal class Program
    {
        private static IPhotonReceiver receiver;

        private static void Main(string[] args)
        {
            ReceiverBuilder builder = ReceiverBuilder.Create();

            builder.AddRequestHandler(new MoveRequestHandler());
            builder.AddEventHandler(new MoveEventHandler());
            builder.AddEventHandler(new NewCharacterEventHandler());

            receiver = builder.Build();

            Console.WriteLine("Start");

            CaptureDeviceList devices = CaptureDeviceList.Instance;
            foreach (var device in devices)
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Open... {device.Description}");

                    device.OnPacketArrival += new PacketArrivalEventHandler(PacketHandler);
                    device.Open(DeviceMode.Promiscuous, 1000);
                    device.StartCapture();
                })
                .Start();
            }

            Console.Read();
        }

        private static void PacketHandler(object sender, CaptureEventArgs e)
        {
            UdpPacket packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data).Extract<UdpPacket>();
            if (packet != null && (packet.SourcePort == 5056 || packet.DestinationPort == 5056))
            {
                receiver.ReceivePacket(packet.PayloadData);
            }
        }
    }
}
