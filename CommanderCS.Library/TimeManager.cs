namespace CommanderCS.Library
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

        public static long TomorrowEpochInMilliseconds
        {
            get
            {
                return Today.Add(new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0, milliseconds: 0)).ToUnixTimeMilliseconds();
            }
        }

        public static long TenDayEpoch
        {
            get
            {
                return Today.Add(new TimeSpan(days: 10, hours: 0, minutes: 0, seconds: 0, milliseconds: 0)).ToUnixTimeSeconds();
            }
        }

        public static DateTime ConvertUnixToDateTime(double unixTimestamp)
        {
            // Unix timestamp is seconds past epoch (UTC)
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimestamp).ToLocalTime();
            return dateTime;
        }

        public static double GetCurrentTime()
        {
            return CurrentEpoch;
        }

        public static double GetTimeDifference(double timeInSeconds)
        {
            double currentTime = CurrentEpoch;
            double difference = currentTime - timeInSeconds;
            return difference;
        }

        public static double GetTimeDifferenceInMinutes(double timeInSeconds)
        {
            double currentTimeInSeconds = CurrentEpoch;
            double differenceInSeconds = currentTimeInSeconds - timeInSeconds;

            int differenceInMinutes = (int)(differenceInSeconds / 60);

            return differenceInMinutes;
        }

        public static double GetTimeDifferenceInHours(double timeInSeconds)
        {
            double currentTimeInSeconds = CurrentEpoch;
            double differenceInSeconds = currentTimeInSeconds - timeInSeconds;

            double differenceInHours = differenceInSeconds / (60 * 60);

            return differenceInHours;
        }

        public static double GetTimeDifferenceInDays(double timeInSeconds)
        {
            double currentTimeInSeconds = CurrentEpoch;
            double differenceInSeconds = currentTimeInSeconds - timeInSeconds;

            double differenceInDays = differenceInSeconds / (60 * 60 * 24);

            return differenceInDays;
        }
    }
}