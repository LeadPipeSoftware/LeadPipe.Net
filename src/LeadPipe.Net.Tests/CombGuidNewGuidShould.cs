using System;
using NUnit.Framework;

namespace LeadPipe.Net.Tests
{
    [TestFixture]
    public class CombGuidNewGuidShould
    {

        [Test]
        public void ReturnAPredictableGuidWhenSpecifyingBothSeedValues()
        {
            var seedMoment = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var seedGuid = Guid.Empty;
            var expected = Guid.Empty;
            var actual = CombGuid.NewGuid(seedMoment, seedGuid);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void ReturnAPredictableGuidWhenSpecifyingMomentInLocalTime()
        {
            var seedMoment = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var seedGuid = Guid.Empty;
            var expected = GetExpectedGuidBasedOnTimezoneOffset();
            var actual = CombGuid.NewGuid(seedMoment, seedGuid);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void ReturnAPredictableGuidWhenSpecifyingMomentInUnspecifiedTime()
        {
            var seedMoment = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            var seedGuid = Guid.Empty;
            var expected = GetExpectedGuidBasedOnTimezoneOffset();
            var actual = CombGuid.NewGuid(seedMoment, seedGuid);
            Assert.AreEqual(actual, expected);
        }

        private static Guid GetExpectedGuidBasedOnTimezoneOffset()
        {
            switch (GetTimezoneOffsetInHours())
            {
                case -6:
                    return Guid.Parse("00000000-0000-0000-0000-00000062e080");
                case -5:
                    return Guid.Parse("00000000-0000-0000-0000-0000005265c0");
                default:
                    Assert.Inconclusive("Unsupported timezone offset");
                    return Guid.Empty;
            }
        }

        private static int GetTimezoneOffsetInHours()
        {
            var local = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var utc = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var difference = utc.ToUniversalTime().Subtract(local.ToUniversalTime());
            return (int)difference.TotalHours;
        }
    }
}
