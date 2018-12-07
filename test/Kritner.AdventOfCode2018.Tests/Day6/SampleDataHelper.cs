using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Tests.Day6
{
    public static class SampleDataHelper
    {
        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    new string[] 
                    {
                        "1, 1",
                        "1, 6",
                        "8, 3",
                        "3, 4",
                        "5, 5",
                        "8, 9"
                    },
                    17 // largest non infinite area calculated with Manhattan distance
                }
            };
    }
}
