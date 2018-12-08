using Kritner.AdventOfCode2018.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day7
{
    public class Puzzle
    {
        private readonly StepParser _parser = new StepParser();

        public string Puzzle1(IEnumerable<string> inputs)
        {
            var steps = _parser.ParseSteps(inputs);

            var processedSteps = new List<string>();
            GenerateSteps(steps, processedSteps);
            return string.Join("", processedSteps);
        }

        private void GenerateSteps(List<Step> steps, List<string> processedSteps)
        {
            while (steps.Count() != processedSteps.Count())
            {
                var unusedSteps = GetUnusedSteps(steps, processedSteps);
                var nextStep = GetNextStep(processedSteps, unusedSteps);

                processedSteps.Add(nextStep.Label);
            }
        }

        private List<Step> GetUnusedSteps(List<Step> steps, List<string> processedSteps)
        {
            var unusedSteps = new List<Step>();
            foreach (var step in steps)
            {
                if (!processedSteps.Contains(step.Label))
                {
                    unusedSteps.Add(step);
                }
            }

            return unusedSteps;
        }

        private Step GetNextStep(List<string> processedSteps, List<Step> unusedSteps)
        {
            foreach (var step in unusedSteps.OrderBy(ob => ob.Label).ToList())
            {
                if (step.DependantOnSteps.All(value => processedSteps.Contains(value)))
                {
                    return step;
                }
            }

            throw new Exception("Shouldn't have gotten here");
        }
    }
}
