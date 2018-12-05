using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day5
{
    public class AlchemicalReduction
    {
        public string ReducePolymer(string polymer)
        {
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                var previousChar = "";

                for (int i = 0; i < polymer.Length; i++)
                {
                    string currentChar = new string(new[] { polymer[i] });

                    // Same letter
                    if (currentChar.Equals(previousChar, StringComparison.OrdinalIgnoreCase))
                    {
                        // different case
                        if (!currentChar.Equals(previousChar, StringComparison.Ordinal))
                        {
                            // Remove the last character from the builder, don't add this character
                            sb.Remove(i - 1, 1);
                            // Add the remaining characters to the builder
                            sb.Append(polymer.Substring(i + 1, polymer.Length - i - 1));
                            // reset the previous char for next entry into for loop
                            previousChar = "";
                            break;
                        }
                    }

                    // Record new previous char, append the current char to the builder
                    previousChar = currentChar;
                    sb.Append(currentChar);
                }

                // Completed for loo pass, build the string
                var newString = sb.ToString();
                
                // break out of while loop if they're the same string (has been reduced by maximum amount)
                if (polymer == newString)
                {
                    break;
                }

                // Work with the newly modified string within the for loop
                polymer = newString;
            }

            return polymer;
        }

        public string FullyReducePolymerByEliminatingSingleUnit(string polymer)
        {
            var originalPolymer = polymer;
            var normalizedPolymer = originalPolymer.ToUpper();

            // get the individual "types" within the polymer
            var groupsOfTypes = normalizedPolymer
                .GroupBy(gb => gb)
                .Select(s => s.Key);

            // builds new list of potential polymers, removing a single type from the chain in each run
            List<string> newPotentialPolymers = new List<string>();
            foreach (var s in groupsOfTypes)
            {
                // Removes a single type from the potential polymer
                var charToRemove = new string(new[] { s });
                var regex = new Regex(charToRemove, RegexOptions.IgnoreCase);

                newPotentialPolymers.Add(regex.Replace(originalPolymer, ""));
            }

            // Run the new potential polymers
            List<string> reducedPolymers = new List<string>();
            foreach (var potentialPolymer in newPotentialPolymers)
            {
                reducedPolymers.Add(ReducePolymer(potentialPolymer));
            }

            // return the smallest one
            var minLengthPolymer = reducedPolymers.Min(m => m.Length);
            return reducedPolymers.Where(w => w.Length == minLengthPolymer).First();
        }
    }
}
