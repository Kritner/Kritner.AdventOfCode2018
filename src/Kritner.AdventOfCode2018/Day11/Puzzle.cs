using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day11
{
    public class Puzzle
    {
        public Cell Puzzle1(int gridSerialNumber)
        {
            var subject = new ChronalCharge(gridSerialNumber);

            return subject.GetMaxPowerSquareId();
        }
    }
}
