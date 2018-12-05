using System;
using System.Text;

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
                            // Remove the last character, don't add this character
                            sb.Remove(i - 1, 1);
                            // Add the remaining characters
                            sb.Append(polymer.Substring(i + 1, polymer.Length - i - 1));
                            previousChar = "";
                            break;
                        }
                    }

                    // Record new previous char, append the current char to the builder
                    previousChar = currentChar;
                    sb.Append(currentChar);
                }

                var newString = sb.ToString();
                
                // break out of while loop if they're the same string
                if (polymer == newString)
                {
                    break;
                }

                polymer = newString;
            }

            return polymer;
        }
    }
}
