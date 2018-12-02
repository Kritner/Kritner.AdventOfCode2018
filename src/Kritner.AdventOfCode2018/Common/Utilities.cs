using System.Collections.Generic;
using System.IO;

namespace Kritner.AdventOfCode2018.Common
{
    public static class Utilities
    {
        public static IEnumerable<string> GetFileContents(string filePath)
        {
            List<string> lines = new List<string>();

            using (var file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
