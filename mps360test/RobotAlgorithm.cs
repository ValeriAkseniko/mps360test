using mps360test.Enums;
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
                    case (char)StepOfThePath.L:
                        TurnLeft(robot);
                        break;
                    case (char)StepOfThePath.R:
                        TurnRight(robot);
                        break;
                    case (char)StepOfThePath.F:
                        if (robot.WorldSide == (char)CardinalDirections.N || robot.WorldSide == (char)CardinalDirections.S)
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

        public void TurnLeft(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case (char)CardinalDirections.N:
                    robot.WorldSide = (char)CardinalDirections.W;
                    break;
                case (char)CardinalDirections.E:
                    robot.WorldSide = (char)CardinalDirections.N;
                    break;
                case (char)CardinalDirections.S:
                    robot.WorldSide = (char)CardinalDirections.E;
                    break;
                case (char)CardinalDirections.W:
                    robot.WorldSide = (char)CardinalDirections.S;
                    break;
            }
        }
        public void TurnRight(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case (char)CardinalDirections.N:
                    robot.WorldSide = (char)CardinalDirections.E;
                    break;
                case (char)CardinalDirections.E:
                    robot.WorldSide = (char)CardinalDirections.S;
                    break;
                case (char)CardinalDirections.S:
                    robot.WorldSide = (char)CardinalDirections.W;
                    break;
                case (char)CardinalDirections.W:
                    robot.WorldSide = (char)CardinalDirections.N;
                    break;
            }
        }

        public bool yAxisStep(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case (char)CardinalDirections.N:
                    robot.AxisY++;
                    break;
                case (char)CardinalDirections.S:
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
                case (char)CardinalDirections.E:
                    robot.AxisX++;
                    break;
                case (char)CardinalDirections.W:
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
