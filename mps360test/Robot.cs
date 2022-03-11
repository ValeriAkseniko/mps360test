using mps360test.Enums;
using System;
using System.Linq;

namespace mps360test
{
    public class Robot
    {
        public int AxisX { get; set; }

        public int AxisY { get; set; }

        public CardinalDirections WorldSide { get; set; }

        public Robot()
        {

        }

        public Robot(string startPosition)
        {
            var shortCoordinates = startPosition.Split(' ').ToList();
            AxisX = int.Parse(shortCoordinates[0]);
            AxisY = int.Parse(shortCoordinates[1]);
            WorldSide = Enum.Parse<CardinalDirections>(shortCoordinates[2]);
        }

        public override string ToString()
        {
            return $"{AxisX} {AxisY} {WorldSide}";
        }
    }
}
