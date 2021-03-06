﻿using System.Collections.Generic;
using System.Linq;

namespace Kritner.AdventOfCode2018.Day1
{
    /// <summary>
    /// Chronal Calibration - see readme.
    /// 
    /// Sum some ints (can be positive or negative)
    /// Parse string into useable ints
    /// </summary>
    public class ChronalCalibration
    {
        /// <summary>
        /// Given an <see cref="IEnumerable{int}"/>, return the sum.
        /// </summary>
        /// <param name="values">The values to total</param>
        /// <returns>int</returns>
        public virtual int CalibrateChronalsOrSomething(IEnumerable<int> values)
        {
            return values.Sum();
        }

        public IEnumerable<int> ParseInts(IEnumerable<string> stringsToParse)
        {
            List<int> numbers = new List<int>();

            foreach (var s in stringsToParse)
            {
                if (int.TryParse(s, out var parsedInt))
                {
                    numbers.Add(parsedInt);
                }
            }

            return numbers;
        }
    }
}
