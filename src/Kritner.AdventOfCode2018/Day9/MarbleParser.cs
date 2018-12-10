using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day9
{
    public class MarbleParser
    {
        public GameAttributes ParseInput(string input)
        {
            var regex = new Regex("(?<players>.*)(?= players)(?:.*)worth <?(?<lastMarble>.*)(?: points)");
            var matches = regex.Match(input);

            var players = int.Parse(matches.Groups["players"].Value.Trim());
            var lastMarbleValue = int.Parse(matches.Groups["lastMarble"].Value.Trim());

            return new GameAttributes()
            {
                NumberOfPlayers = players,
                LastMarbleValue = lastMarbleValue
            };
        }
    }
}
