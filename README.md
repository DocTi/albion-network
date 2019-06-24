# Albion Network

Provides convenient work with network events Albion Online.

Project Description:

**Albion.Common** - contains common classes.  
**Albion.Event** - classes "Event" of events.  
**Albion.Operation** - classes "Operation" of events.  
**Albion.Network** - main project.  

Usage example:

In this example, we enable the processing of the message "Operation.Move".
```c#

using Albion.Common;
using Albion.Operation;
using Albion.Network;

var albionParser = new AlbionParser();
albionParser.AddRequestHandler<MoveOperation>(OperationCodes.Move, (operation) =>
{
  Console.WriteLine($"Move request");
});
            
```

To capture network packets we need **PcapDotNet**.
```c#
using Albion.Network;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;

var albionParser = new AlbionParser();

void PacketHandler(Packet packet)
{
  IpV4Datagram ip = packet.Ethernet.IpV4;
  UdpDatagram udp = ip.Udp;
  
  if (udp == null || (udp.SourcePort != 5056 && udp.DestinationPort != 5056))
  {
    return;
  }
  
  albionParser.ReceivePacket(udp.Payload.ToArray());
}
```

A full example can be found here [Example](https://github.com/DocTi/albion-network/blob/master/Albion.Network.Example/Program.cs)

## Dependencies
[WinPcap](https://www.winpcap.org) which comes with [Wireshark](https://www.wireshark.org)

## NuGet
[Albion.Common](https://www.nuget.org/packages/Albion.Common/)  
[Albion.Network](https://www.nuget.org/packages/Albion.Network/)  
[Albion.Event](https://www.nuget.org/packages/Albion.Event/)  
[Albion.Operation](https://www.nuget.org/packages/Albion.Operation/)  
