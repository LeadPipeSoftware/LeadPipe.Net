using System;
using System.Linq;

namespace LeadPipe.Net
{
    public static class CombGuid
    {

        private const double Rounding = 3.333333;

        public static Guid NewGuid()
        {
            return NewGuid(GenerateDateTimeSeed(), GenerateGuidSeed());
        }

        public static Guid NewGuid(DateTime dateTimeSeed)
        {
            return NewGuid(dateTimeSeed, GenerateGuidSeed());
        }

        public static Guid NewGuid(Guid guidSeed)
        {
            return NewGuid(GenerateDateTimeSeed(), guidSeed);
        }

        public static Guid NewGuid(DateTime dateTimeSeed, Guid guidSeed)
        {
            var utcDateTimeSeed = dateTimeSeed.ToUniversalTime();

            var guidArray = guidSeed.ToByteArray();

            var baseDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Get the days and milliseconds which will be used to build the byte string
            var days = new TimeSpan(utcDateTimeSeed.Ticks - baseDate.Ticks);
            var msecs = utcDateTimeSeed.TimeOfDay;

            // Convert to a byte array
            // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333
            var daysArray = BitConverter.GetBytes(days.Days);
            var msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / Rounding));

            // Reverse the bytes to match SQL Servers ordering
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Copy the bytes into the guid
            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }

        public static DateTime GetApproximateDateTime(Guid guid)
        {
            var guidBytes = guid.ToByteArray();

            var dateTimePartBytes = guidBytes.Skip(guidBytes.Length - 6).ToArray();

            var datePartBytes = dateTimePartBytes.Take(2).Reverse().ToArray(); // 2 byte date part

            var days = BitConverter.ToUInt16(datePartBytes, 0);

            var timePartBytes = dateTimePartBytes.Skip(2).Reverse().ToArray(); // 4 byte time part

            var msecs = BitConverter.ToInt32(timePartBytes, 0) * Rounding;

            var baseDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var value = baseDate.AddDays(days).AddMilliseconds(msecs);

            return value;
        }

        private static DateTime GenerateDateTimeSeed()
        {
            return DateTime.UtcNow;
        }

        private static Guid GenerateGuidSeed()
        {
            return Guid.NewGuid();
        }

    }
}
