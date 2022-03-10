using System;
using System.Collections.Generic;
using System.Text;

namespace mps360test
{
    public class RobotAlgorithm
    {
        const string lost = "LOST";
        public string GetResult(Robot robot, string path)
        {            
            bool isLost = false;
            for (int i = 0; i < path.Length && !isLost; i++)
            {
                switch (path[i])
                {
                    case 'L':
                        PovorotLeft(robot);
                        break;
                    case 'R':
                        PovorotRight(robot);
                        break;
                    case 'F':
                        if (robot.WorldSide == 'N' || robot.WorldSide == 'S')
                        {
                            isLost = !yAxisStep(robot);
                        }
                        else
                        {
                            isLost = !xAxisStep(robot);
                        }
                        break;
                }
            }
            if (isLost)
            {
                return $"{robot.ToString()} {lost}";
            }
            return robot.ToString();
        }

        public void PovorotLeft(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case 'N':
                    robot.WorldSide = 'W';
                    break;
                case 'E':
                    robot.WorldSide = 'N';
                    break;
                case 'S':
                    robot.WorldSide = 'E';
                    break;
                case 'W':
                    robot.WorldSide = 'S';
                    break;
            }
        }
        public void PovorotRight(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case 'N':
                    robot.WorldSide = 'E';
                    break;
                case 'E':
                    robot.WorldSide = 'S';
                    break;
                case 'S':
                    robot.WorldSide = 'W';
                    break;
                case 'W':
                    robot.WorldSide = 'N';
                    break;
            }
        }

        public bool yAxisStep(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case 'N':
                    robot.AxisY++;
                    break;
                case 'S':
                    robot.AxisY--;
                    break;
            }
            if (robot.AxisY > 7)
            {
                robot.AxisY--;
                return false;
            }
            if (robot.AxisY < 0)
            {
                robot.AxisY++;
                return false;
            }
            return true;
        }
        public bool xAxisStep(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case 'E':
                    robot.AxisX++;
                    break;
                case 'W':
                    robot.AxisX--;
                    break;
            }
            if (robot.AxisX > 7)
            {
                robot.AxisX--;
                return false;
            }
            if (robot.AxisX < 0)
            {
                robot.AxisX++;
                return false;
            }
            return true;
        }
    }
}
