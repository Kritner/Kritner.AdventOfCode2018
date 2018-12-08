using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day7
{
    public class InstructionOrderedStep
    {
        public string Label { get; set; }
        public List<InstructionOrderedStep> NextSteps { get; set; } = 
            new List<InstructionOrderedStep>();

        public void BuildDepthFirstOrder(StringBuilder sb)
        {
            sb.Append(Label);
            foreach (var nextStep in NextSteps)
            {
                nextStep.BuildDepthFirstOrder(sb);
            }
        }
    }
}
