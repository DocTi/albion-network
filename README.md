# Albion Network

Provides convenient work with network events Albion Online.

## v4.7.0
Brimstone & Mist

- Updating event codes

## v4.6.0
Migrating from PcapDotNet to SharpPcap. Change the target platforms .NET 4.7.1 on the .NET Standart 2.0 and .NET Core 3.1. Windows and Linux support.

STAR if you liked it, thank you!

## Installing
You should install [Albion Network with NuGet:](https://www.nuget.org/packages/Albion.Network/)
```
Install-Package Albion.Network
```

## Dependencies
* On Windows, [Npcap](https://nmap.org/download.html) (formerly WinPcap) extensions
* On Linux, [libpcap](http://www.tcpdump.org/manpages/pcap.3pcap.html)

Read more here [sharppcap](https://github.com/chmorgan/sharppcap)

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
using PacketDotNet;
using SharpPcap;
using System;
using System.Threading;

private IPhotonReceiver receiver;

...

private void PacketHandler(object sender, CaptureEventArgs e)
{
    UdpPacket packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data).Extract<UdpPacket>();
    if (packet != null && (packet.SourcePort == 5056 || packet.DestinationPort == 5056))
    {
        receiver.ReceivePacket(packet.PayloadData);
    }
}
```

A full example can be found here [Example](https://github.com/DocTi/albion-network/blob/master/Albion.Network.Example/Program.cs)

**Feedback** Discord DocTi#1410 
