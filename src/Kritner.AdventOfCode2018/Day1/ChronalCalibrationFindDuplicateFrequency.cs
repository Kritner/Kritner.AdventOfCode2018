using System.Collections.Generic;

namespace Kritner.AdventOfCode2018.Day1
{
    public class ChronalCalibrationFindDuplicateFrequency : ChronalCalibration
    {
        private HashSet<int> _calculatedFrequencies = new HashSet<int>();
        private bool _duplicateFrequencyFound = false;

        public override int CalibrateChronalsOrSomething(IEnumerable<int> values)
        {
            var sum = 0;
            _calculatedFrequencies.Add(sum);
            _duplicateFrequencyFound = false;

            while (!_duplicateFrequencyFound)
            {
                FindDuplicateFrequency(values, ref sum);
            }

            return sum;
        }

        private void FindDuplicateFrequency(IEnumerable<int> values, ref int sum)
        {
            foreach (var value in values)
            {
                sum = sum + value;

                // Add the value to the hashset if it's not already in there
                if (!_calculatedFrequencies.Contains(sum))
                {
                    _calculatedFrequencies.Add(sum);
                }
                // The duplicate frequency was found
                else
                {
                    _duplicateFrequencyFound = true;
                    break;
                }
            }
        }
    }
}
