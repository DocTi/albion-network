using System;
using System.Threading.Tasks;

namespace Albion.Network.Example
{
    public class MoveRequestHandler : RequestPacketHandler<MoveOperation>
    {
        public MoveRequestHandler() : base(OperationCodes.Move) { }

        protected override Task OnActionAsync(MoveOperation value)
        {
            Console.WriteLine($"Move request");

            return Task.CompletedTask;
        }
    }
}
