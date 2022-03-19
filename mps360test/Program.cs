using System;

namespace mps360test
{
    public static class Program
    {
        static void Main(string[] args)
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();
            ValidationService validationService = new ValidationService();
            for (;;)
            {
                var coordinates = Console.ReadLine();
                var path = Console.ReadLine();
                if (!validationService.ValidationCoordinate(coordinates))
                {
                    Console.WriteLine("coordinate input error");
                    continue;
                }

                if (!validationService.ValidationPath(path))
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
