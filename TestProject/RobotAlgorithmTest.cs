using mps360test;
using mps360test.Enums;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class RobotAlgorithmTest
    {
        [Fact]
        public void TernLeftTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.N
            };

            Robot secondRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.W
            };

            robotAlgorithm.TurnLeft(firstRobot);
            robotAlgorithm.TurnLeft(secondRobot);

            Assert.Equal(firstRobot.WorldSide, CardinalDirections.W);
            Assert.Equal(secondRobot.WorldSide, CardinalDirections.S);
        }

        [Fact]
        public void TernRightTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.N
            };

            Robot secondRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.W
            };

            robotAlgorithm.TurnRight(firstRobot);
            robotAlgorithm.TurnRight(secondRobot);

            Assert.Equal(firstRobot.WorldSide, CardinalDirections.E);
            Assert.Equal(secondRobot.WorldSide, CardinalDirections.N);
        }

        [Fact]
        public void YAxisStepTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.N
            };

            Robot secondRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.S
            };

            robotAlgorithm.yAxisStep(firstRobot);
            robotAlgorithm.yAxisStep(secondRobot);

            Assert.Equal(2, firstRobot.AxisY);
            Assert.Equal(0, secondRobot.AxisY);
        }

        [Fact]
        public void XAxisStepTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.E
            };

            Robot secondRobot = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.W
            };

            robotAlgorithm.xAxisStep(firstRobot);
            robotAlgorithm.xAxisStep(secondRobot);

            Assert.Equal(2, firstRobot.AxisX);
            Assert.Equal(0, secondRobot.AxisX);
        }

        [Fact]
        public void GetResultTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstRobot = new Robot()
            {
                AxisX = 0,
                AxisY = 2,
                WorldSide = CardinalDirections.E
            };
            Robot firstResult = new Robot()
            {
                AxisX = 1,
                AxisY = 1,
                WorldSide = CardinalDirections.E
            };

            Robot secondRobot = new Robot()
            {
                AxisX = 3,
                AxisY = 5,
                WorldSide = CardinalDirections.N
            };

            Robot secondResult = new Robot()
            {
                AxisX = 4,
                AxisY = 6,
                WorldSide = CardinalDirections.N
            };

            Command command = new Command()
            {
                Path = new List<char>() { 'R', 'F', 'L', 'F' }
            };

            robotAlgorithm.GetResult(firstRobot, command);
            robotAlgorithm.GetResult(secondRobot, command);

            Assert.Equal(firstResult.AxisX, firstRobot.AxisX);
            Assert.Equal(firstResult.AxisY, firstRobot.AxisY);
            Assert.Equal(firstResult.WorldSide, firstResult.WorldSide);

            Assert.Equal(secondResult.AxisX, secondRobot.AxisX);
            Assert.Equal(secondResult.AxisY, secondRobot.AxisY);
            Assert.Equal(secondResult.WorldSide, secondRobot.WorldSide);
        }
    }
}
