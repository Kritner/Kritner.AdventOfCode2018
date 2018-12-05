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
            // Refactored to stack with input from others solutions at: 
            // https://dev.to/rpalo/aoc-day-5-alchemical-reduction-5b2f/comments

            Stack<string> stack = new Stack<string>();
            foreach (var c in polymer)
            {
                var s = new string(new[] { c });

                // the top item in the stack (or empty string if we haven't yet added to stack)
                var top = stack.Count == 0 ? string.Empty : stack.Peek();

                // if the top item is the same letter, 
                // but different case than the currently evaluated character,
                // remove the top item from the stack, and don't add the current character.
                if (top != "" && top.ToLower() == s.ToLower() && top != s)
                {
                    stack.Pop();
                }
                // No match, add the character to the stack
                else
                {
                    stack.Push(s);
                }
            }

            // Is there a better way to project the stack back into a contiguous string?
            var sb = new StringBuilder();
            while(stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString();
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
