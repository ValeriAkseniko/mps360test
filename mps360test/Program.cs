using System;
using System.Linq;

namespace mps360test
{
    public static class Program
    {
        static void Main(string[] args)
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();
            for (int i = 0; i < 100; i++)
            {
                var coordinates = Console.ReadLine();
                var path = Console.ReadLine();

                Robot robot = new Robot(coordinates);

                string result = robotAlgorithm.GetResult(robot, path);

                Console.WriteLine(result);
            }            
        }        
    }
}
