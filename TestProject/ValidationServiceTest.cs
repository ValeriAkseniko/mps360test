using mps360test;
using mps360test.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class ValidationServiceTest
    {
        [Fact]
        public void ValidationCoordinateTest()
        {
            ValidationService validationService = new ValidationService();


            string coordinate1 = "1 1 E";
            string coordinate2 = "1 1E";
            string coordinate3 = "8 1 E";
            string coordinate4 = "1 R E";
            string coordinate5 = "11 E";
            string coordinate6 = "1 1 e";
            string coordinate7 = "1 1 j";


            Assert.True(validationService.ValidationCoordinate(coordinate1));
            Assert.False(validationService.ValidationCoordinate(coordinate2));
            Assert.False(validationService.ValidationCoordinate(coordinate3));
            Assert.False(validationService.ValidationCoordinate(coordinate4));
            Assert.False(validationService.ValidationCoordinate(coordinate5));
            Assert.False(validationService.ValidationCoordinate(coordinate6));
            Assert.False(validationService.ValidationCoordinate(coordinate7));
        }

        [Fact]
        public void ValidationPathTest()
        {
            ValidationService validationService = new ValidationService();


            string path1 = "RFLF";
            string path2 = "R FLF";
            string path3 = "RFL F";
            string path4 = "RFlF";
            string path5 = "RKL1";
            string path6 = "RFjO";

            Assert.True(validationService.ValidationPath(path1));
            Assert.False(validationService.ValidationPath(path2));
            Assert.False(validationService.ValidationPath(path3));
            Assert.False(validationService.ValidationPath(path4));
            Assert.False(validationService.ValidationPath(path5));
            Assert.False(validationService.ValidationPath(path6));
        }
    }
}
