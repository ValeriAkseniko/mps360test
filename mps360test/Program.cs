using System;
using System.Linq;

namespace mps360test
{
    public static class Program
    {
        const string cardinalDirections = "NESW";
        const string numbers = "01234567";
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine();
            var path = Console.ReadLine();
            string result;

            result = Function(coordinates, path);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string Function(string coordinates, string path)
        {
            var shortCoordinates = coordinates.Split(' ').ToList();
            int axisX = int.Parse(shortCoordinates[0]);
            int axisY = int.Parse(shortCoordinates[1]);
            string worldSide = shortCoordinates[2];
            string isLost = string.Empty;
            for (int i = 0; i < path.Length; i++)
            {
                if (isLost == "LOST")
                {
                    continue;
                }
                switch (path[i])
                {
                    case 'L':
                        worldSide = PovorotLeft(worldSide);
                        break;
                    case 'R':
                        worldSide = PovorotRight(worldSide);
                        break;
                    case 'F':
                        if (worldSide == "N" || worldSide == "S")
                        {
                            axisY = yAxisStep(axisY, worldSide);
                            if (axisY > 7)
                            {
                                isLost = "LOST";
                                axisY--;
                            }
                            else if (axisY < 0)
                            {
                                isLost = "LOST";
                                axisY++;
                            }
                        }
                        else
                        {
                            axisX = xAxisStep(axisX, worldSide);
                            if (axisX > 7)
                            {
                                isLost = "LOST";
                                axisX--;
                            }
                            else if (axisX < 0)
                            {
                                isLost = "LOST";
                                axisX++;
                            }
                        }
                        break;
                }
            }

            string result = $"{axisX} {axisY} {worldSide} {isLost}";
            return result;
        }

        public static string PovorotLeft(string cardinalDirections)
        {
            if (cardinalDirections == "N")
            {
                cardinalDirections = "W";
            }
            else if (cardinalDirections == "E")
            {
                cardinalDirections = "N";
            }
            else if (cardinalDirections == "S")
            {
                cardinalDirections = "E";
            }
            else if (cardinalDirections == "W")
            {
                cardinalDirections = "S";
            }
            return cardinalDirections;
        }
        public static string PovorotRight(string cardinalDirections)
        {
            if (cardinalDirections == "N")
            {
                cardinalDirections = "E";
            }
            else if (cardinalDirections == "E")
            {
                cardinalDirections = "S";
            }
            else if (cardinalDirections == "S")
            {
                cardinalDirections = "W";
            }
            else if (cardinalDirections == "W")
            {
                cardinalDirections = "N";
            }
            return cardinalDirections;
        }

        public static int yAxisStep(int axisY,string worldSide)
        {
            switch (worldSide)
            {
                case "N":
                    axisY++;
                    break;
                case "S":
                    axisY--;
                    break;
            }
            return axisY;
        }
        public static int xAxisStep(int axisX, string worldSide)
        {
            switch (worldSide)
            {
                case "E":
                    axisX++;
                    break;
                case "W":
                    axisX--;
                    break;
            }
            return axisX;
        }
    }
}
