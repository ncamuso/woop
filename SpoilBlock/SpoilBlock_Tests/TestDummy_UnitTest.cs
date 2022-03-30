using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SpoilBlock.Models;

namespace SpoilBlock_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_TestDummy_CompareNumbers_ShouldBeTrue()
        {
            // Arrange
            var a = 15;
            var b = 15;

            // Act
            bool output = TestDummy.CompareNumbers(a, b);

            // Assert
            Assert.That(output, Is.True);

        }
    }
}