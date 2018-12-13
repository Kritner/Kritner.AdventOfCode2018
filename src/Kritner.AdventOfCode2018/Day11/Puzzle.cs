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
            var result = subject.GetMaxPowerSquare();
            
            return new Cell(result.X, result.Y, gridSerialNumber);
        }

        public Square Puzzle2(int gridSerialNumber)
        {
            int x = 0;
            int y = 0;
            int maxSquareLength = 0;
            int maxSquarePower = int.MinValue;

            for (var squareLength = 1; squareLength <= 300; squareLength++)
            {
                var subject = new ChronalCharge(gridSerialNumber, squareLength);
                var result = subject.GetMaxPowerSquare();

                if (result.TotalPower > maxSquarePower)
                {
                    x = result.X;
                    y = result.Y;
                    maxSquareLength = squareLength;
                    maxSquarePower = result.TotalPower;
                }
            }

            return new Square()
            {
                X = x,
                Y = y,
                SquareSize = maxSquareLength,
                TotalPower = maxSquarePower
            };
        }
    }
}
