using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day9
{
    public class Player
    {
        public int PlayerId { get; set; }
        public long Points { get; set; }
        public Queue<int> Marbles { get; set; } = new Queue<int>();
    }
}
