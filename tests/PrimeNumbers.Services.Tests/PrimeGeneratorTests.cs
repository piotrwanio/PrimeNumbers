using PrimeNumbers.BLL.Services.Implementations;
using System;
using System.Linq;
using Xunit;

namespace PrimeNumbers.Services.Tests
{
    public class PrimeGeneratorTests
    {
        [Fact]
        public void GenerateUsingSieveOfAtkin_LimitEquals100_CorrectPrimesGenerated()
        {
            //Arrange
            var target = new PrimesGenerator();

            //Act
            var result = (target.GenerateUsingSieveOfAtkin(1000, -DateTime.Now.Ticks).Result.Item1).OrderBy(i => i).Take(10);

            //Asserts
            Assert.NotNull(result);
            Assert.Collection(result, item => Assert.Equal(2, item),
                               item => Assert.Equal(3, item),
                               item => Assert.Equal(5, item),
                               item => Assert.Equal(7, item),
                               item => Assert.Equal(11, item),
                               item => Assert.Equal(13, item),
                               item => Assert.Equal(17, item),
                               item => Assert.Equal(19, item),
                               item => Assert.Equal(23, item),
                               item => Assert.Equal(29, item));
        }
    }
}
