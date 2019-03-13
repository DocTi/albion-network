using System.Collections.Generic;

namespace Albion.Operation
{
    public class OperationMove : Operation
    {
        public OperationMove(Dictionary<byte, object> parameters) : base(parameters)
        {
            var position = (float[])parameters[1];
            var newPosition = (float[])parameters[3];

            Time = (int)parameters[0];
            Position = new Position(position[0], position[1]);
            Direction = (float)parameters[2];
            NewPosition = new Position(newPosition[0], newPosition[1]);
            Speed = (float)parameters[4];
        }

        public int Time { get; }
        public Position Position { get; }
        public float Direction { get; }
        public Position NewPosition { get; }
        public float Speed { get; }
    }
}
