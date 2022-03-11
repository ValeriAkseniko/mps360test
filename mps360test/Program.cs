using System;
using System.Linq;

namespace mps360test
{
    public static class Program
    {
        static void Main(string[] args)
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();
            ValidationService validationService = new ValidationService();
            for (int i = 0; i < 100; i++)
            {
                var coordinates = Console.ReadLine();
                var path = Console.ReadLine();
                if (!validationService.ValidationCoordinate(coordinates) || coordinates == string.Empty)
                {
                    Console.WriteLine("coordinate input error");
                    continue;
                }

                if (!validationService.ValidationPath(path) || path == string.Empty)
                {
                    Console.WriteLine("path input error");
                    continue;
                }
                Command commands = new Command(path);
                Robot robot = new Robot(coordinates);


                string result = robotAlgorithm.GetResult(robot, commands);

                Console.WriteLine(result);
            }            
        }        
    }
}
