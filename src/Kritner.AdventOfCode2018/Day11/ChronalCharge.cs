using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day11
{
    public class ChronalCharge
    {
        private const int maxDimension = 300;
        private const int squareDimension = 3;

        private readonly Square[,] _squares = new Square[maxDimension - 2, maxDimension - 2];
        private readonly Cell[,] _cells = new Cell[maxDimension, maxDimension];
        private readonly int _gridSerialNumber;

        public ChronalCharge(int gridSerialNumber)
        {
            _gridSerialNumber = gridSerialNumber;
            PopulateCells();
            PopulateSquares();
        }

        public Cell GetMaxPowerSquareId()
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

            return cell;
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
            for (int row = 1; row + squareDimension - 1 <= maxDimension; row++)
            {
                for (var column = 1; column + squareDimension - 1 <= maxDimension; column++)
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
            var squareCells = new Cell[squareDimension, squareDimension];

            for (var cellX = row; cellX < row + squareDimension; cellX++)
            {
                for (var cellY = column; cellY < column + squareDimension; cellY++)
                {
                    try
                    {
                        squareCells[cellX - row, cellY - column] = 
                        _cells[cellX - 1, cellY - 1];
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return squareCells;
        }
    }
}
