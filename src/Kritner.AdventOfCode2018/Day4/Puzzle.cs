using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day4
{
    public class Puzzle
    {
        private readonly GuardLogParser _parser = new GuardLogParser();

        public int GetPuzzle1(IEnumerable<string> input)
        {
            var parsedLogs = _parser.ParseGuardLog(input);

            // GuardId, GuardSleepingDetails
            var guardSleepDetails = new Dictionary<int, GuardSleepingDetails>();
            foreach (var guard in parsedLogs)
            {
                guardSleepDetails.Add(guard.GuardId, guard.GetMinutesAsleepDetails());
            }

            var maxTimeSleeping = guardSleepDetails.Values.Max(m => m.TotalMinutesAsleep);
            var mostAsleepGuard = guardSleepDetails.First(w => w.Value.TotalMinutesAsleep == maxTimeSleeping);
            
            // GuardId * Minute most commonly asleep
            return mostAsleepGuard.Key * mostAsleepGuard.Value.MinuteMostCommonlyAsleep;
        }

        public int GetPuzzle2(IEnumerable<string> input)
        {
            var parsedLogs = _parser.ParseGuardLog(input);

            // GuardId, GuardSleepingDetails
            var guardSleepDetails = new Dictionary<int, GuardSleepingDetails>();
            foreach (var guard in parsedLogs)
            {
                guardSleepDetails.Add(guard.GuardId, guard.GetMinutesAsleepDetails());
            }

            var timesCommonMinuteSleptIn = guardSleepDetails.Max(m => m.Value.TimesCommonMinuteSleptIn);
            var sleepyBoi =
                guardSleepDetails.First(f => f.Value.TimesCommonMinuteSleptIn == timesCommonMinuteSleptIn);
            var maxMinute = sleepyBoi.Value.MinuteMostCommonlyAsleep;

            // Guard most frequently asleep on same minute * that minute
            return sleepyBoi.Key * maxMinute;
        }
    }
}
