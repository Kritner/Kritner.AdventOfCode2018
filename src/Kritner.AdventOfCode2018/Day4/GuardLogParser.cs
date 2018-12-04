using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day4
{
    public class GuardLogParser
    {
        public IEnumerable<GuardMonitoring> ParseGuardLog(IEnumerable<string> log)
        {
            var orderedRawLog = GetDateAndLogPortionsOrdered(log);
            return GetLogPerGuard(orderedRawLog);
        }

        /// <summary>
        /// Gets Date (Key) and body of log message
        /// </summary>
        /// <param name="log">The log message to parse</param>
        /// <returns>Date / Log</returns>
        protected IDictionary<DateTime, string> GetDateAndLogPortionsOrdered(
            IEnumerable<string> log
        )
        {
            var dict = new Dictionary<DateTime, string>();

            // Break the log into datetime and log portions
            var regex = new Regex(@"\[(?<dateTime>.*)(?=\])(?:.).<?(?<log>.*)");

            foreach (var entry in log)
            {
                var matches = regex.Match(entry);

                dict.Add(
                    DateTime.Parse(matches.Groups["dateTime"].Value),
                    matches.Groups["log"].Value
                );
            }

            // Return the dictionary ordered by date
            return dict
                .OrderBy(ob => ob.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// Place raw logs into their corresponding guard objects
        /// </summary>
        /// <param name="orderedRawLog">Date of log, content of log</param>
        /// <returns><see cref="IEnumerable{GuardMonitoring}"/></returns>
        protected IEnumerable<GuardMonitoring> GetLogPerGuard(
            IDictionary<DateTime, string> orderedRawLog
        )
        {
            List<GuardMonitoring> list = new List<GuardMonitoring>();
            var guardIdRegex = new Regex(@"(?<guardId>\d+)");

            GuardMonitoring currentGuard = null;
            foreach (var log in orderedRawLog)
            {
                // New guard/night
                if (log.Value.Contains("#"))
                {
                    var match = guardIdRegex.Match(log.Value);
                    var guardId = int.Parse(match.Groups["guardId"].Value);

                    // if the guard exists in the list, grab its reference
                    if (list.Any(a => a.GuardId == guardId))
                    {
                        currentGuard = list.First(f => f.GuardId == guardId);
                    }
                    // new guard
                    else
                    {
                        currentGuard = new GuardMonitoring()
                        {
                            GuardId = guardId
                        };
                        list.Add(currentGuard);
                    }
                    
                    // Log the activity
                    currentGuard.GuardLog.Add(
                        new GuardLog()
                        {
                            LogTime = log.Key,
                            Status = GuardStatus.StartedShift
                        }
                    );

                    continue;
                }

                // Handles guard falling asleep
                if (log.Value.Contains("falls"))
                {
                    currentGuard.GuardLog.Add(new GuardLog()
                    {
                        LogTime = log.Key,
                        Status = GuardStatus.Sleeping
                    });

                    continue;
                }

                // Handles guard waking up
                if (log.Value.Contains("wakes"))
                {
                    currentGuard.GuardLog.Add(new GuardLog()
                    {
                        LogTime = log.Key,
                        Status = GuardStatus.Awake
                    });

                    continue;
                }
            }

            return list;
        }
    }
}
