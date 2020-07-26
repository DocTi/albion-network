# Albion Network

Provides convenient work with network events Albion Online.

## Installing
You should install [Albion Network with NuGet:](https://www.nuget.org/packages/Albion.Network/)
```
Install-Package Albion.Network
```

## Dependencies
[WinPcap](https://www.winpcap.org) which comes with [Wireshark](https://www.wireshark.org)

## Example
In this example, we enable the processing of the message "Operation.Move".
```c#

using Albion.Common;
using Albion.Operation;
using Albion.Network;

ReceiverBuilder builder = ReceiverBuilder.Create();

builder.AddRequestHandler(new MoveRequestHandler());

IPhotonReceiver receiver = builder.Build();
            
```

```c#
using Albion.Common;
using Albion.Operation;
using System;

namespace Albion.Network.Example
{
    public class MoveRequestHandler : RequestPacketHandler<MoveOperation>
    {
        public MoveRequestHandler() : base(OperationCodes.Move) { }

        protected override void OnAction(MoveOperation value)
        {
            Console.WriteLine($"Move request");
        }
    }
}
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
  
  receiver.ReceivePacket(udp.Payload.ToArray());
}
```

A full example can be found here [Example](https://github.com/DocTi/albion-network/blob/master/Albion.Network.Example/Program.cs)
