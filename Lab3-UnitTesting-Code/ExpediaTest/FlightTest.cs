using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime startDate = new DateTime(2010, 5, 20);
        private readonly DateTime endDate = new DateTime(2010, 5, 25);
        private readonly int miles = 200;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightPriceIsCorrectForFiveDaySpan()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.AreEqual(300, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightPriceIsCorrectForOneDaySpan()
        {
            var target = new Flight(new DateTime(2010, 5, 20), new DateTime(2010, 5, 21), miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsInvalidOperationOnNegativeDays()
        {
            new Flight(new DateTime(2010, 5, 20), new DateTime(2010, 4, 20), miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsArgumentOutOfRangeExceptionOnNegativeMiles()
        {
            new Flight(startDate, endDate, -10);
        }

        [Test()]
        public void TestIfTwoFlightsAreEqual()
        {
            var target = new Flight(startDate, endDate, 20);
            var target1 = new Flight(startDate, endDate, 20);
            Assert.AreEqual(true, target.Equals(target1));
        }

        [Test()]
        public void TestIfTwoFlightsAreNotEqual()
        {
            var target = new Flight(startDate, endDate, 20);
            var target1 = new Flight(startDate, endDate, 19);
            Assert.AreEqual(false, target.Equals(target1));
        }
	}
}
