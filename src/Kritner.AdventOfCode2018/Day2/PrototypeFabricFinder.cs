using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day2
{
    public class PrototypeFabricFinder
    {
        public string GetProtoTypeFabric(IEnumerable<string> inventory)
        {
            var inventoryPermutations = SwapCharForEachInventoryPermutation(inventory);
            var foundDuplicateish = inventoryPermutations
                // Group by default
                .GroupBy(gb => gb)
                // We only want the instance where there's more than
                // one in the group by (the prototype fabric)
                .Where(w => w.Count() > 1)
                .Select(s => new
                {
                    s.Key
                })
                .FirstOrDefault();
            
            // Return the prototype fabric, minus the "different" single character
            return foundDuplicateish.Key.Replace("*", "");
        }

        /// <summary>
        /// Builds and returns a <see cref="IEnumerable{string}"/>
        /// containing every permutation of iventory items, with
        /// one character (*) swapped in at a differing index.
        /// 
        /// I have no idea if that makes sense.
        /// </summary>
        /// <param name="inventory">each inventory id.</param>
        /// <returns></returns>
        private IEnumerable<string> SwapCharForEachInventoryPermutation(
            IEnumerable<string> inventory
        )
        {
            List<string> list = new List<string>();

            foreach (var item in inventory)
            {
                // Create new strings and them to the list
                // The new strings will be a copy of the original,
                // with a single character (the index) swapped in with "*"
                for (var index = 0; index < item.Length; index++)
                {
                    var charArrayOfItem = item.ToCharArray();
                    charArrayOfItem[index] = '*';

                    list.Add(new string(charArrayOfItem));
                }
            }

            return list;
        }
    }
}
