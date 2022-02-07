using System;
using System.Text.RegularExpressions;

namespace personal_gcode_validator
{
    class Rule
    {
        private readonly string name;
        private readonly Regex rule;

        public Rule(string name, string rulePattern)
        {
            this.name = name;
            this.rule = new Regex(rulePattern);
        }

        public string Name() { return this.name; }

        public bool Validate(string input) 
        {
            return this.rule.IsMatch(input) == false;
        }
    }

}