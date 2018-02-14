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
        [Test]
        public void ShouldReturnZero()
        {
            //age is out of range
            Class1 sut = new Class1();

            float expectedResult = sut.CalcPremium(17, "female");

            Assert.That(expectedResult, Is.EqualTo(0.0));
        }
    }
}