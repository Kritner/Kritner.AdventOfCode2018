using Kritner.ExtensionMethods;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kritner.AdventOfCode2018.Day2
{
    public class InventoryManagement
    {
        public int GetCheckSum(IEnumerable<string> inventory)
        {
            return GetCheckSum(GetCheckSumCandidates(inventory));
        }

        public int GetCheckSum(IEnumerable<InventoryChecksumCandidates> candidates)
        {
            var checksumPieces = candidates
                .GroupBy(gb => gb.DuplicateCount)
                .Select(s => new
                {
                    s.Key,
                    Count = s.Count()
                })
                .ToList();

            Debug.Assert(checksumPieces.Count() == 2);

            return checksumPieces[0].Count * checksumPieces[1].Count;
        }

        public IEnumerable<InventoryChecksumCandidates> GetCheckSumCandidates(IEnumerable<string> inventory)
        {
            List<InventoryChecksumCandidates> list = new List<InventoryChecksumCandidates>();

            foreach (var item in inventory)
            {
                var checksumCandidate = item
                    // make everything same case (just in case)
                    .ToLower()
                    // where it's a letter
                    .Where(char.IsLetter)
                    // Group by the default (letter)
                    .GroupBy(gb => gb)
                    // Project the found values into their new type
                    .Select(s => new InventoryChecksumCandidates()
                    {
                        DuplicateCharacter = s.Key.ToString(),
                        DuplicateCount = s.Count()
                    });

                if (checksumCandidate != null)
                {
                    list.AddIfNotNull(
                        checksumCandidate.FirstOrDefault(f => f.DuplicateCount == 2)
                    );
                    list.AddIfNotNull(
                        checksumCandidate.FirstOrDefault(f => f.DuplicateCount == 3)
                    );
                }
            }

            return list;
        }
    }
}
