using System;
using Xunit;

namespace RPSTest.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        //Arrange
        int x = 5;
        int y = 6;

        //Act
        int z = x + y;

        //Assert
        Assert.Equal(11, z);

        }
    }
}
