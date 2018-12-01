using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kritner.AdventOfCode2018.Day1.Puzzle1
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
        public int CalibrateChronalsOrSomething(IEnumerable<int> values)
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

        public IEnumerable<string> GetFileContents(string filePath)
        {
            List<string> lines = new List<string>();

            using (var file = new StreamReader(filePath))
            {
                string line;
                while((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
