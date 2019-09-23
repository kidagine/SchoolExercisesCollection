using System;
using Xunit;
using TeenagerChecker.Core;

namespace TeenagerChecker.Tests
{
    public class TeenagerCheckerTest
    {
        [Theory]
        [InlineData(13)]
        [InlineData(19)]
        public void ValidInputForTeenagerChecker(int year)
        {
            DateTime birthday = DateTime.Now.AddYears(-year);
            ITeenagerCheck teenagerCheck = new TeenagerCheck();
            Assert.True(teenagerCheck.IsTeenager(birthday));
        }

        [Theory]
        [InlineData(12)]
        [InlineData(20)]
        public void OutOfBoundaryForTeenagerChecker(int year)
        {
            DateTime birthday = DateTime.Now.AddYears(-year);
            ITeenagerCheck teenagerCheck = new TeenagerCheck();
            Assert.False(teenagerCheck.IsTeenager(birthday));
        }
    }
}
