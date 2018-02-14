using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestingClassLibrary;

namespace TestingClassLibraryTests
{
    [TestFixture]

    public class Class
    {
        static PremiumCalculator sut;

        [SetUp]
        public void Init()
        {
            sut = new PremiumCalculator();
        }

        [Test]
        public void TestNotNull()
        {
            Assert.NotNull(sut, "Object not created");
        }

        [Test]
        public void UnderageFemale()
        {
            //age is out of range
            float expectedResult = sut.CalcPremium(17, "female");
            Assert.That(expectedResult, Is.EqualTo(0.0));
        }

        [Test]
        public void UnderageMale()
        {
            //age is out of range
            float expectedResult = sut.CalcPremium(17, "male");
            Assert.That(expectedResult, Is.EqualTo(0.0));
        }

        [TestCase(18, "female", ExpectedResult = 5.0)]
        [TestCase(19, "female", ExpectedResult = 5.0)]
        [TestCase(30, "female", ExpectedResult = 5.0)]
        [TestCase(31, "female", ExpectedResult = 2.5)]
        [Test]
        public float ShouldReturn5(int a, string b)
        {
            //young female should return 5
            return sut.CalcPremium(a, b);            
        }

        [TestCase(18, "male", ExpectedResult = 6.0)]
        [TestCase(19, "male", ExpectedResult = 6.0)]
        [TestCase(35, "male", ExpectedResult = 6.0)]
        [TestCase(36, "male", ExpectedResult = 5.0)]
        [Test]
        public float ShouldReturn6(int a, string b)
        {
            //young male should return 6
            return sut.CalcPremium(a, b);
        }

        [Test]
        public void OlderPremium()
        {
            //if age >= 50, premium should decrease
            float youngerMale = sut.CalcPremium(36, "male");
            float olderMale = sut.CalcPremium(50, "male");
            Assert.AreEqual((youngerMale * 0.15), olderMale);
        }

        [TestCase(18, "female", ExpectedResult = 5.0)]
        [TestCase(18, "Female", ExpectedResult = 5.0)]
        [TestCase(18, "FEMALE", ExpectedResult = 5.0)]
        [TestCase(18, "male", ExpectedResult = 6.0)]
        [TestCase(18, "Male", ExpectedResult = 6.0)]
        [TestCase(18, "MALE", ExpectedResult = 6.0)]
        [Test] 
        public float CheckCase(int a, string b)
        {
            //should be case insensitive
            return sut.CalcPremium(a, b);
        }
    }
}