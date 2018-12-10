using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day9
{
    public class Puzzle
    {
        private readonly MarbleParser _parser = new MarbleParser();

        public int Puzzle1(string input)
        {
            var gameAttributes = _parser.ParseInput(input);

            MarbleGame game = new MarbleGame(gameAttributes);

            return game.GetWinningElfScore();
        }

        public int Puzzle2(string input)
        {
            var gameAttributes = _parser.ParseInput(input);
            gameAttributes.LastMarbleValue *= 100;

            MarbleGame game = new MarbleGame(gameAttributes);

            return game.GetWinningElfScore();
        }
    }
}
