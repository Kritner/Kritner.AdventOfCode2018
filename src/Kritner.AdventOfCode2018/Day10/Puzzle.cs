using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day10
{
    public class Puzzle
    {
        private readonly StarsParser _parser = new StarsParser();
        private readonly StarCharter _charter = new StarCharter();

        public string Puzzle1(IEnumerable<string> inputs)
        {
            var stars = _parser.ParseInput(inputs);

            var chart = _charter.PlotStarsUntilClosestManhattanDistance(stars.ToList());

            return chart;
        }
    }
}
