using MarsRover_CaseStudy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_CaseStudyTests
{


    [TestFixture]
    class UtilTests
    {

        [Test]
        public void IsInteger_WhenCalledWithStringCastableToInteger_ReturnsTrue()
        {
            var result = Util.IsInteger("25");
            Assert.That(result, Is.True);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("-")]
        public void IsInteger_WhenCalledWithWrongValues_ReturnsFalse(string _str)
        {
            var result = Util.IsInteger(_str);
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsDirection_WhenCalledWithDirectionEnumString_ReturnsTrue()
        {
            var result = Util.IsValidDirection("N");
            Assert.That(result, Is.True);
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("MN")]
        [TestCase("M")]
        public void IsDirection_WhenCaledWithWrongValues_ReturnsFalse(string _str)
        {
            var result = Util.IsInteger(_str);
            Assert.That(result, Is.False);
        }

    }
}
