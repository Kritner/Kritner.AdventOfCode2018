using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day4
{
    public class GuardSleepingDetails
    {
        /// <summary>
        /// The total number of minutes asleep for this guard.
        /// </summary>
        public int TotalMinutesAsleep { get; set; }
        /// <summary>
        /// The minute that most commonly has this guard sleeping.
        /// </summary>
        public int MinuteMostCommonlyAsleep { get; set; }
        /// <summary>
        /// The amount of times a guard was sleeping in the most commonly slept minute
        /// </summary>
        public int TimesCommonMinuteSleptIn { get; set; }
    }
}
