using mps360test;
using mps360test.Enums;
using Xunit;

namespace TestProject
{
    public class RobotAlgorithmTest
    {
        [Fact]
        public void TurnLeftTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstrobot = new Robot()
            {
                WorldSide = CardinalDirections.N
            };
            Robot secondRobot = new Robot()
            {
                WorldSide = CardinalDirections.E
            };
            Robot thirdRobot = new Robot()
            {
                WorldSide = CardinalDirections.S
            };
            Robot fourthRobot = new Robot()
            {
                WorldSide = CardinalDirections.W
            };


            Robot firstResult = new Robot()
            {
                WorldSide = CardinalDirections.E
            };
            Robot secondResult = new Robot()
            {
                WorldSide = CardinalDirections.S
            };
            Robot thirdResult = new Robot()
            {
                WorldSide = CardinalDirections.W
            };
            Robot fourthResult = new Robot()
            {
                WorldSide = CardinalDirections.N
            };

            robotAlgorithm.TurnLeft(firstrobot);
            robotAlgorithm.TurnLeft(secondRobot);
            robotAlgorithm.TurnLeft(thirdRobot);
            robotAlgorithm.TurnLeft(fourthRobot);

            Assert.Equal(firstrobot.WorldSide, firstResult.WorldSide);
            Assert.Equal(secondRobot.WorldSide, secondResult.WorldSide);
            Assert.Equal(thirdRobot.WorldSide, thirdResult.WorldSide);
            Assert.Equal(fourthRobot.WorldSide, fourthResult.WorldSide);
        }

        [Fact]
        public void TurnRightTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            Robot firstrobot = new Robot()
            {
                WorldSide = CardinalDirections.N
            };
            Robot secondRobot = new Robot()
            {
                WorldSide = CardinalDirections.E
            };
            Robot thirdRobot = new Robot()
            {
                WorldSide = CardinalDirections.S
            };
            Robot fourthRobot = new Robot()
            {
                WorldSide = CardinalDirections.W
            };


            Robot firstResult = new Robot()
            {
                WorldSide = CardinalDirections.W
            };
            Robot secondResult = new Robot()
            {
                WorldSide = CardinalDirections.N
            };
            Robot thirdResult = new Robot()
            {
                WorldSide = CardinalDirections.E
            };
            Robot fourthResult = new Robot()
            {
                WorldSide = CardinalDirections.S
            };

            robotAlgorithm.TurnRight(firstrobot);
            robotAlgorithm.TurnRight(secondRobot);
            robotAlgorithm.TurnRight(thirdRobot);
            robotAlgorithm.TurnRight(fourthRobot);

            Assert.Equal(firstrobot.WorldSide, firstResult.WorldSide);
            Assert.Equal(secondRobot.WorldSide, secondResult.WorldSide);
            Assert.Equal(thirdRobot.WorldSide, thirdResult.WorldSide);
            Assert.Equal(fourthRobot.WorldSide, fourthResult.WorldSide);
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

            Assert.Equal(0, firstRobot.AxisX);
            Assert.Equal(2, secondRobot.AxisX);
        }

        [Fact]
        public void GetResultTest()
        {
            RobotAlgorithm robotAlgorithm = new RobotAlgorithm();

            string firstCoordinate = "1 1 E";
            string firstPath = "RFRFRFRF";
            string firstCorrectResult = "1 1 E";
            Robot firstRobot = new Robot(firstCoordinate);
            Command firstCommand = new Command(firstPath);

            string secondCoordinate = "3 2 N";
            string secondPath = "FRRFFFRFLFFLRF";
            string secondCorrectResult = "2 0 S LOST";
            Robot secondRobot = new Robot(secondCoordinate);
            Command secondCommand = new Command(secondPath);

            string thirdCoordinate = "0 1 W";
            string thirdPath = "LLFFFLFLFL";
            string thirdCorrectResult = "0 1 E LOST";
            Robot thirdRobot = new Robot(thirdCoordinate);
            Command thirdCommand = new Command(thirdPath);

            string firstResult = robotAlgorithm.GetResult(firstRobot, firstCommand);
            string secondResult = robotAlgorithm.GetResult(secondRobot, secondCommand);
            string thirdResult = robotAlgorithm.GetResult(thirdRobot, thirdCommand);

            Assert.Equal(firstResult, firstCorrectResult);
            Assert.Equal(secondResult, secondCorrectResult);
            Assert.Equal(thirdResult, thirdCorrectResult);
        }
    }
}
