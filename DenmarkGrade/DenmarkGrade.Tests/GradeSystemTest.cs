using System;
using Xunit;
using DenmarkGrade.Core;

namespace DenmarkGrade.Tests
{
    public class GradeSystemTest
    {
        [Theory]
        [InlineData(0, -3)]
        [InlineData(7, -3)]
        [InlineData(8, 0)]
        [InlineData(33, 0)]
        [InlineData(34, 2)]
        [InlineData(41, 2)]
        [InlineData(42, 4)]
        [InlineData(57, 4)]
        [InlineData(58, 7)]
        [InlineData(77, 7)]
        [InlineData(78, 10)]
        [InlineData(89, 10)]
        [InlineData(90, 12)]
        [InlineData(100, 12)]
        public void ValidInputForGradeConversion(int percentage, int expected)
        {
            IGradeSystem gradeSystem = new GradeSystem();
            gradeSystem.ToGrade(percentage);
            Assert.Equal(expected, gradeSystem.Result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void OutOfRangeForGradeConversionExpectingArgumentException(int percentage)
        {
            IGradeSystem gradeSystem = new GradeSystem();
            Assert.Throws<ArgumentException>(() =>
            {
                gradeSystem.ToGrade(percentage);
            });
        }
    }
}
