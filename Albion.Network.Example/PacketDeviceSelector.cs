using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Albion.Network.Example
{
    internal static class PacketDeviceSelector
    {
        public static PacketDevice AskForPacketDevice()
        {
            // Retrieve the device list from the local machine
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                throw new Exception("No interfaces found! Make sure WinPcap is installed.");
            }

            // Print the list
            for (int i = 0; i != allDevices.Count; ++i)
            {
                LivePacketDevice device = allDevices[i];
                Console.Write((i + 1) + ". ");
                Console.Write(" " + string.Join(",",
                                  device.Addresses.Where(x => x.Address.Family == SocketAddressFamily.Internet)
                                      .Select(x => x.Address.ToString()).ToArray()) + " ");
                if (device.Description != null)
                    Console.WriteLine(" (" + device.Description + ")");
                else
                    Console.WriteLine(" (No description available)");
            }

            int deviceIndex;
            do
            {
                Console.WriteLine("Enter the interface number (1-" + allDevices.Count + "):");
                string deviceIndexString = Console.ReadLine();
                if (!int.TryParse(deviceIndexString, out deviceIndex) ||
                    deviceIndex < 1 || deviceIndex > allDevices.Count)
                {
                    deviceIndex = 0;
                }
            } while (deviceIndex == 0);

            return allDevices[deviceIndex - 1];
        }
    }
}
