using System.Linq;

namespace mps360test
{
    public class Robot
    {
        public int AxisX { get; set; }

        public int AxisY { get; set; }

        public char WorldSide { get; set; }

        public Robot(string startPosition)
        {
            var shortCoordinates = startPosition.Split(' ').ToList();
            AxisX = int.Parse(shortCoordinates[0]);
            AxisY = int.Parse(shortCoordinates[1]);
            WorldSide = shortCoordinates[2].First();
        }

        public override string ToString()
        {
            return $"{AxisX} {AxisY} {WorldSide}";
        }
    }
}
