using System;
using NUnit.Framework;

namespace LeadPipe.Net.Tests
{
    [TestFixture]
    public class CombGuidParseShould
    {
        [Test]
        public void ReturnSameMillisecondsAsOriginal()
        {
            var expected = GetUtcNowRoundedDownToNearestMillisecond();
            var guid = CombGuid.NewGuid(expected);
            var actual = CombGuid.GetApproximateDateTime(guid);
            
            Assert.AreEqual(expected.Kind, actual.Kind);

            Assert.AreEqual(expected.Date, actual.Date);
            
            var variance = Math.Abs(actual.TimeOfDay.TotalMilliseconds - expected.TimeOfDay.TotalMilliseconds);
            
            Assert.LessOrEqual(variance, 100, "Difference in time of day should be less than 1/10th of a second");
        }

        private static DateTime GetUtcNowRoundedDownToNearestMillisecond()
        {
            var ticks = DateTime.UtcNow.Ticks;
            ticks -= ticks % TimeSpan.TicksPerMillisecond; // Round down to the nearest millisecond
            var value = new DateTime(ticks, DateTimeKind.Utc);
            return value;
        }
    }
}