using MarsRover_CaseStudy;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover_CaseStudyTests
{

    [TestFixture]
    public class RoverTests
    {
        private Rover rover;
        [SetUp]
        public void Setup()
        {
            // Created a rover with roverNumber 1
            rover = new Rover(1);
        }


        [Test]
        [TestCase(new string[] { "1", "2", "N", "5" }, false)]
        [TestCase(new string[] { "1", "2", "M" }, false)]
        [TestCase(new string[] { "6", "2", "N" }, false)]
        [TestCase(new string[] { "1", "2", "N" }, true)]
        public void InitializeRoverLocation_WhenCalled_InitializesRoverLocationIfItsValid
            (string[] _roverLocation, bool expectedResult)
        {
            var areaLimits = new List<int> { 5, 5 };

            var result = rover.InitializeRoverLocation(areaLimits, _roverLocation);

            Assert.That(result, Is.EqualTo(expectedResult));

        }

        
        [Test]
        public void MoveRover_WhenCalled_MovesAccordingToMovesList()
        {
            var areaLimits = new List<int> { 5, 5 };
            rover.InitializeRoverLocation(areaLimits, new string[] { "1", "2", "N" });


            rover.MoveRover(areaLimits,"LMLMLMLMM");

            Assert.That(rover.XCoordinate, Is.EqualTo(1));
            Assert.That(rover.YCoordinate, Is.EqualTo(3));
            Assert.That(rover.Direction, Is.EqualTo(Directions.N));
        }

        [Test]
        public void MoveRover_WhenMovementListIsOutOfBoundries_RoverStopsAtBoundryLimitOfXorY()
        {
            var areaLimits = new List<int> { 5, 5 };
            rover.InitializeRoverLocation(areaLimits, new string[] { "1", "2", "N" });


            rover.MoveRover(areaLimits, "MMMMMMM");

            Assert.That(rover.XCoordinate, Is.EqualTo(1));
            Assert.That(rover.YCoordinate, Is.EqualTo(5));
            Assert.That(rover.Direction, Is.EqualTo(Directions.N));
        }
    }
}