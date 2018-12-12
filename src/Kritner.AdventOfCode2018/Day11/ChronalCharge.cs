using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day11
{
    public class ChronalCharge
    {
        private const int maxDimension = 300;

        private readonly Cell[,] _cells = new Cell[maxDimension, maxDimension];
        private readonly Square[,] _squares;
        private readonly int _squareDimension;
        private readonly int _gridSerialNumber;

        public ChronalCharge(int gridSerialNumber, int squareDimension)
        {
            _gridSerialNumber = gridSerialNumber;
            _squareDimension = squareDimension;

            _squares = new Square[
                maxDimension - _squareDimension + 1,
                maxDimension - _squareDimension + 1
            ];

            PopulateCells();
            PopulateSquares();
        }

        public (Cell cell, int maxPower) GetMaxPowerSquareId()
        {
            int maxPower = int.MinValue;
            Cell cell = null;

            foreach (var s in _squares)
            {
                var squarePower = s.GetSquarePower();

                if (squarePower > maxPower)
                {
                    maxPower = squarePower;
                    cell = s.SquareId;
                }
            }

            return (cell, maxPower);
        }

        private void PopulateCells()
        {
            for (var row = 1; row <= maxDimension; row++)
            {
                for (var column = 1; column <= maxDimension; column++)
                {
                    var cell = new Cell(row, column, _gridSerialNumber);
                    _cells[row - 1, column - 1] = cell;
                    cell.GetPowerLevel();
                }
            }
        }

        private void PopulateSquares()
        {
            for (int row = 1; row + _squareDimension - 1 <= maxDimension; row++)
            {
                for (var column = 1; column + _squareDimension - 1 <= maxDimension; column++)
                {
                    var squareCells = PopulateCellsForSquare(row, column);
                    _squares[row - 1, column - 1] = new Square(
                        squareCells
                    );
                }
            }
        }

        private Cell[,] PopulateCellsForSquare(int row, int column)
        {
            var squareCells = new Cell[_squareDimension, _squareDimension];

            for (var cellX = row; cellX < row + _squareDimension; cellX++)
            {
                for (var cellY = column; cellY < column + _squareDimension; cellY++)
                {
                    squareCells[cellX - row, cellY - column] = 
                    _cells[cellX - 1, cellY - 1];
                }
            }

            return squareCells;
        }
    }
}
