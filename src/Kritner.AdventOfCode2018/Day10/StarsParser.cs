using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day10
{
    public class StarsParser
    {
        public IEnumerable<Star> ParseInput(IEnumerable<string> inputs)
        {
            List<Star> list = new List<Star>();

            var regex = new Regex(@"\<(?<xPosition>.*),(?<yPosition>.*)\>.*\<(?<xVelocity>.*),(?<yVelocity>.*)\>");

            foreach (var input in inputs)
            {
                var matches = regex.Match(input);

                list.Add(new Star(
                    int.Parse(matches.Groups["xPosition"].Value.Trim()),
                    int.Parse(matches.Groups["yPosition"].Value.Trim()),
                    int.Parse(matches.Groups["xVelocity"].Value.Trim()),
                    int.Parse(matches.Groups["yVelocity"].Value.Trim())
                ));
            }

            return list;
        }
    }
}
