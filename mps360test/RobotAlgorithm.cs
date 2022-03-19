using mps360test.Enums;
using mps360test.Exceptions;
using System;

namespace mps360test
{
    public class RobotAlgorithm
    {
        public string GetResult(Robot robot, Command command)
        {
            for (int i = 0; i < command.Path.Count && !robot.IsLost; i++)
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
                            robot.IsLost = !yAxisStep(robot);
                        }
                        else
                        {
                            robot.IsLost = !xAxisStep(robot);
                        }
                        break;
                }
            }
            if (robot.IsLost)
            {
                var ex = new LostException();
                return $"{robot.AxisX} {robot.AxisY} {Enum.GetName(typeof(CardinalDirections), robot.WorldSide)} {ex.ToString()}";
            }
            return $"{robot.AxisX} {robot.AxisY} {Enum.GetName(typeof(CardinalDirections), robot.WorldSide)}";
        }

        public void TurnLeft(Robot robot)
        {
            robot.WorldSide = (CardinalDirections)((4 + ((int)robot.WorldSide - 1)) % 4);
        }
        public void TurnRight(Robot robot)
        {
            robot.WorldSide = (CardinalDirections)(((int)robot.WorldSide + 1) % 4);
        }

        public bool yAxisStep(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case CardinalDirections.N:
                    if (robot.AxisY < 7 && robot.AxisY > 0)
                    {
                        robot.AxisY++;
                        return true;
                    }
                    return false;
                case CardinalDirections.S:
                    if (robot.AxisY < 7 && robot.AxisY > 0)
                    {
                        robot.AxisY--;
                        return true;
                    }
                    return false;
            }
            return true;
        }
        public bool xAxisStep(Robot robot)
        {
            switch (robot.WorldSide)
            {
                case CardinalDirections.E:
                    if (robot.AxisX < 7 && robot.AxisX > 0)
                    {
                        robot.AxisX--;
                        return true;
                    }
                    return false;
                case CardinalDirections.W:
                    if (robot.AxisX < 7 && robot.AxisX > 0)
                    {
                        robot.AxisX++;
                        return true;
                    }
                    return false;
            }
            return true;
        }
    }
}
