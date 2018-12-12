using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day11
{
    public class Puzzle
    {
        public Cell Puzzle1(int gridSerialNumber)
        {
            var subject = new ChronalCharge(gridSerialNumber, 3);

            return subject.GetMaxPowerSquareId().cell;
        }

        public (Cell cell, int squareLength) Puzzle2(int gridSerialNumber)
        {
            Cell maxCell = null;
            int maxSquareLength = 0;
            int maxSquarePower = int.MinValue;

            for (var squareLength = 1; squareLength <= 300; squareLength++)
            {
                var subject = new ChronalCharge(gridSerialNumber, squareLength);
                var result = subject.GetMaxPowerSquareId();

                if (result.maxPower > maxSquarePower)
                {
                    maxCell = result.cell;
                    maxSquareLength = squareLength;
                    maxSquarePower = result.maxPower;
                }
            }

            return (maxCell, maxSquareLength);
        }
    }
}
