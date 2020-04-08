using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PrimeNumbers.BLL.Services.Implementations;
using PrimeNumbers.BLL.Services.Interfaces;
using Xunit;

namespace PrimeNumbers.Services.Tests
{
    public class SegmentedPrimesGeneratorTests
    {
        [Fact]
        public void Generate_SmallRangeOfNumbers10To30_CorrectPrimesGenerated()
        {
            //Arrange
            const long minRange = 10;
            const long maxRange = 30;
            var limit = Math.Sqrt(maxRange) + 1;
            var primesGenerator = new Mock<IPrimesGenerator>();
            IList<long> primes = new List<long>() {2, 3, 5};


            primesGenerator.Setup(p => p.GenerateUsingSieveOfAtkin((int)limit,1, 1))
                .Returns(Task.FromResult((primes, 1, 1, 1)));

            var target = new SegmentedPrimesGenerator(primesGenerator.Object);

            //Act
 
            var result = (target.GeneratePrimes(minRange, maxRange)).OrderBy(i => i).Take(10);

            //Asserts
            Assert.NotNull(result);
            Assert.Collection(result, 
                item => Assert.Equal(11, item),
                item => Assert.Equal(13, item),
                item => Assert.Equal(17, item),
                item => Assert.Equal(19, item),
                item => Assert.Equal(23, item),
                item => Assert.Equal(29, item));
        }
    }
}
