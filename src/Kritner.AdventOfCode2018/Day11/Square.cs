using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day11
{
    public class Square
    {
        private readonly Cell[,] _cells;

        public Cell SquareId { get; }

        public Square(Cell[,] cells)
        {
            SquareId = cells[0, 0];
            _cells = cells;
        }

        public int GetSquarePower()
        {
            int totalPower = 0;
            foreach (var cell in _cells)
            {
                totalPower += cell.GetPowerLevel();
            }

            return totalPower;
        }
    }
}
