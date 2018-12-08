using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day7
{
    public class Step
    {
        public string Label { get; set; }
        public List<string> DependantOnSteps { get; set; } = new List<string>();
        public List<string> ProceedingSteps { get; set; } = new List<string>();
    }
}
