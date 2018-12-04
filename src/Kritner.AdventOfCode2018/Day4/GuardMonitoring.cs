using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day4
{
    public class GuardMonitoring
    {
        public int GuardId { get; set;}
        public List<GuardLog> GuardLog { get; set; } = new List<GuardLog>();

        public GuardSleepingDetails GetMinutesAsleepDetails()
        {
            DateTime beganSlumber = new DateTime();
            DateTime endedSlumber = new DateTime();

            var minutesInHourSleepTracking = InstantiateDictionary();

            foreach (var log in GuardLog)
            {
                switch (log.Status)
                {
                    case GuardStatus.Sleeping:
                        beganSlumber = log.LogTime;
                        break;
                    case GuardStatus.Awake:
                        endedSlumber = log.LogTime;
                        GetTimeSpentSleeping(beganSlumber, endedSlumber, ref minutesInHourSleepTracking);
                        break;
                }
            }

            var maxTimesMinuteSlept = minutesInHourSleepTracking.Values.Max();
            var mostAsleepMinute = maxTimesMinuteSlept;
            
            return new GuardSleepingDetails()
            {
                TotalMinutesAsleep = minutesInHourSleepTracking.Values.Sum(),
                MinuteMostCommonlyAsleep = minutesInHourSleepTracking
                    .First(f => f.Value == mostAsleepMinute).Key,
                TimesCommonMinuteSleptIn = maxTimesMinuteSlept
            };
        }

        /// <summary>
        /// Keyed on the minute,
        /// valued on the number of times minute is slept in by a specific guard
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, int> InstantiateDictionary()
        {
            var minutesInHourSleepTracking = new Dictionary<int, int>();

            // one index for each minute in an hour
            for (var i = 0; i < 60; i++)
            {
                minutesInHourSleepTracking.Add(i, 0);
            }

            return minutesInHourSleepTracking;
        }

        private void GetTimeSpentSleeping(DateTime beganSlumber, DateTime endedSlumber, ref Dictionary<int, int> minutesInHourSleepTracking)
        {
            int startMinute = beganSlumber.Minute;
            int endMinute = endedSlumber.Minute;

            for (var i = startMinute; i < endMinute; i++)
            {
                minutesInHourSleepTracking[i]++;
            }
        }
    }
}
