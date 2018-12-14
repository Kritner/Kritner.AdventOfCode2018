using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day11
{
    public class ChronalCharge
    {
        private const int maxDimension = 300;

        private static Dictionary<int, int[,]> CellDictionary =
            new Dictionary<int, int[,]>();

        private static readonly Dictionary<Square, bool> Squares = new Dictionary<Square, bool>();
        private readonly int _squareDimension;
        private readonly int _gridSerialNumber;

        private int[,] _cells;

        public ChronalCharge(int gridSerialNumber, int squareDimension)
        {
            _gridSerialNumber = gridSerialNumber;
            _squareDimension = squareDimension;

            PopulateCells();
        }

        public Square GetMaxPowerSquare()
        {
            Square square = null;
            
            square = new Square()
            {
                TotalPower = int.MinValue
            };

            for (int row = 1; row + _squareDimension - 1 <= maxDimension; row++)
            {
                for (var column = 1; column + _squareDimension - 1 <= maxDimension; column++)
                {
                    var squareTotal = GetTotalForSquare(row, column);
                    if (squareTotal > square.TotalPower)
                    {
                        square.X = row;
                        square.Y = column;
                        square.SquareSize = _squareDimension;
                        square.TotalPower = squareTotal;
                    }
                }
            }

            return square;
        }

        private void PopulateCells()
        {
            if (CellDictionary.TryGetValue(_gridSerialNumber, out var result))
            {
                _cells = result;
                return;
            }

            _cells = new int[maxDimension, maxDimension];

            for (var row = 1; row <= maxDimension; row++)
            {
                for (var column = 1; column <= maxDimension; column++)
                {
                    var cell = new Cell(row, column, _gridSerialNumber);
                    _cells[row - 1, column - 1] = cell.GetPowerLevel();
                }
            }

            CellDictionary.Add(_gridSerialNumber, _cells);
        }
        
        private int GetTotalForSquare(int row, int column)
        {
            int total = 0;
            for (var cellX = row; cellX < row + _squareDimension; cellX++)
            {
                for (var cellY = column; cellY < column + _squareDimension; cellY++)
                {
                    total += 
                        _cells[cellX - 1, cellY - 1];
                }
            }

            return total;
        }
    }
}
