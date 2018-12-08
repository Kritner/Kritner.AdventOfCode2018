using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day7
{
    public class StepParser
    {
        public List<Step> ParseSteps(IEnumerable<string> inputs)
        {
            List<Step> list = new List<Step>();

            var regex = new Regex(@"Step(?<step>..).*step(?<nextStep>..)");
            foreach (var input in inputs)
            {
                var matches = regex.Match(input);

                var step = matches.Groups["step"].Value.Trim();
                var nextStep = matches.Groups["nextStep"].Value.Trim();

                // Step does not exist in list, add it
                if (!list.Any(a => a.Label == step))
                {
                    list.Add(new Step()
                    {
                        Label = step,
                        ProceedingSteps = new List<string>() { nextStep }
                    });
                }
                // Step exists, update its proceeding step
                else
                {
                    list.Where(w => w.Label == step).First().ProceedingSteps.Add(nextStep);
                }

                // Step does not exist in list, add it
                if (!list.Any(a => a.Label == nextStep))
                {
                    list.Add(new Step()
                    {
                        Label = nextStep,
                        DependantOnSteps = new List<string>() { step }
                    });
                }
                // Step exists, update its proceeding step
                else
                {
                    list.Where(w => w.Label == nextStep).First().DependantOnSteps.Add(step);
                }
            }

            return list;
        }
    }
}
