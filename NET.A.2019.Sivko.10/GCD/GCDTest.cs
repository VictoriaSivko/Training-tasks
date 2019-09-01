// <copyright file="GCDTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GCDTask
{
    using System;
    using GCDTask;
    using NUnit.Framework;

    /// <summary>
    /// Tests the functionality of the GCD class.
    /// </summary>
    [TestFixture]
    class GCDTest
    {
        [Test]
        public void EuklidException_ZeroLenght_Test()
        {
            var ex = Assert.Catch<Exception>(() => GCD.Euklid());
            StringAssert.Contains("No parameters were sent to the method for finding the GCD", ex.Message);
        }

        [Test]
        public void EuklidException_IntMinValue_Test()
        {
            var ex = Assert.Catch<Exception>(() => GCD.Euklid(int.MaxValue, 0, int.MinValue));
            StringAssert.Contains("int.MinValue is beyond the acceptable parameter value", ex.Message);
        }

        [TestCase(15, ExpectedResult = 15)]
        [TestCase(-32, ExpectedResult = 32)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Euklid_OneParameter_Test(int i)
        {
            return GCD.Euklid(i);
        }

        [TestCase(15, 35, ExpectedResult = 5)]
        [TestCase(-32, -16, ExpectedResult = 16)]
        [TestCase(-15, 70, ExpectedResult = 5)]
        [TestCase(15, -70, ExpectedResult = 5)]
        [TestCase(0, 17, ExpectedResult = 17)]
        [TestCase(17, 0, ExpectedResult = 17)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Euklid_TwoParameters_Test(int i, int j)
        {
            return GCD.Euklid(i, j);
        }

        [TestCase(2, 30, 44, 14, ExpectedResult = 2)]
        [TestCase(-32, -16, -4, -16, ExpectedResult = 4)]
        [TestCase(-15, int.MaxValue, -10, 0, ExpectedResult = 1)]
        [TestCase(17, 17, -34, 0, ExpectedResult = 17)]
        [TestCase(0, 0, 0, 7, ExpectedResult = 7)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        public int Euklid_ManyParameters_Test(int i, int j, int k, int z)
        {
            return GCD.Euklid(i, j, k, z);
        }

        [Test]
        public void SteinException_ZeroLenght_Test()
        {
            var ex = Assert.Catch<Exception>(() => GCD.Stein());
            StringAssert.Contains("No parameters were sent to the method for finding the GCD", ex.Message);
        }

        [Test]
        public void SteinException_IntMinValue_Test()
        {
            var ex = Assert.Catch<Exception>(() => GCD.Stein(int.MaxValue, 0, int.MinValue));
            StringAssert.Contains("int.MinValue is beyond the acceptable parameter value", ex.Message);
        }

        [TestCase(15, ExpectedResult = 15)]
        [TestCase(-32, ExpectedResult = 32)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Stein_OneParameter_Test(int i)
        {
            return GCD.Stein(i);
        }

        [TestCase(15, 35, ExpectedResult = 5)]
        [TestCase(-32, -16, ExpectedResult = 16)]
        [TestCase(-15, 70, ExpectedResult = 5)]
        [TestCase(15, -70, ExpectedResult = 5)]
        [TestCase(0, 17, ExpectedResult = 17)]
        [TestCase(17, 0, ExpectedResult = 17)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Stein_TwoParameters_Test(int i, int j)
        {
            return GCD.Stein(i, j);
        }

        [TestCase(2, 30, 44, 14, ExpectedResult = 2)]
        [TestCase(-32, -16, -4, -16, ExpectedResult = 4)]
        [TestCase(-15, int.MaxValue, -10, 0, ExpectedResult = 1)]
        [TestCase(17, 17, -34, 0, ExpectedResult = 17)]
        [TestCase(0, 0, 0, 7, ExpectedResult = 7)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        public int Stein_ManyParameters_Test(int i, int j, int k, int z)
        {
            return GCD.Stein(i, j, k, z);
        }
    }
}