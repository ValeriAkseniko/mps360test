using mps360test.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace mps360test
{
    public class RobotAlgorithm
    {
        const string lost = "LOST";
        public string GetResult(Robot robot, Command command)
        {
            bool isLost = false;
            for (int i = 0; i < command.Path.Count && !isLost; i++)
            {
                switch (command.Path[i])
                {
                    case (char)StepOfThePath.L:
                        TurnLeft(robot);
                        break;
                    case (char)StepOfThePath.R:
                        TurnRight(robot);
                        break;
                    case (char)StepOfThePath.F:
                        if (robot.WorldSide == CardinalDirections.N || robot.WorldSide == CardinalDirections.S)
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
                case CardinalDirections.N:
                    robot.WorldSide = CardinalDirections.W;
                    break;
                case CardinalDirections.E:
                    robot.WorldSide = CardinalDirections.N;
                    break;
                case CardinalDirections.S:
                    robot.WorldSide = CardinalDirections.E;
                    break;
                case CardinalDirections.W:
                    robot.WorldSide = CardinalDirections.S;
                    break;
            }
        }
        public void TurnRight(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case CardinalDirections.N:
                    robot.WorldSide = CardinalDirections.E;
                    break;
                case CardinalDirections.E:
                    robot.WorldSide = CardinalDirections.S;
                    break;
                case CardinalDirections.S:
                    robot.WorldSide = CardinalDirections.W;
                    break;
                case CardinalDirections.W:
                    robot.WorldSide = CardinalDirections.N;
                    break;
            }
        }

        public bool yAxisStep(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case CardinalDirections.N:
                    robot.AxisY++;
                    break;
                case CardinalDirections.S:
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
                case CardinalDirections.E:
                    robot.AxisX++;
                    break;
                case CardinalDirections.W:
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
