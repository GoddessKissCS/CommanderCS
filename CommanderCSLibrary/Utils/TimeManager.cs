using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCSLibrary.Utils
{
    public class TimeManager
    {
        private static DateTimeOffset Now
        {
            get
            {
                var now = DateTimeOffset.Now;
                now = now.Add(now.Offset);
                // Game Offset
                now = now.Add(new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 0));
                return now;
            }
        }

        private static DateTimeOffset Today
        {
            get
            {
                var now = Now;
                return now.Subtract(new TimeSpan(days: 0, hours: now.Hour, minutes: now.Minute, seconds: now.Second, milliseconds: now.Millisecond));
            }
        }

        public static long CurrentEpoch
        {
            get
            {
                return Now.ToUnixTimeSeconds();
            }
        }

        public static long CurrentEpochMilliseconds
        {
            get
            {
                return Now.ToUnixTimeMilliseconds();
            }
        }

        public static long TodayEpoch
        {
            get
            {
                return Today.ToUnixTimeSeconds();
            }
        }

        //public static int CurrentEpochInInt
        //{
        //    get
        //    {
        //        return (int)Now.ToUnixTimeSeconds();
        //    }
        //}

        public static long TomorrowEpoch
        {
            get
            {
                return Today.Add(new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0, milliseconds: 0)).ToUnixTimeSeconds();
            }
        }

        public static long TenDayEpoch
        {
            get
            {
                return Today.Add(new TimeSpan(days: 10, hours: 0, minutes: 0, seconds: 0, milliseconds: 0)).ToUnixTimeSeconds();
            }
        }

        public static double GetTimeDifference(double timeInSeconds)
        {
            double currentTime = CurrentEpoch;
            double difference = currentTime - timeInSeconds;
            return difference;
        }

    }
}
