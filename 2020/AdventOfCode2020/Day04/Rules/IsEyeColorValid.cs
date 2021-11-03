using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day04.Rules
{
    public class IsEyeColorValid : PassportRule, IPassportRule
    {
        private readonly IEnumerable<string> _validColors;

        public IsEyeColorValid(IPassportRule rule) : base(rule)
        {
            _validColors = new string[]
            {
                "amb",
                "blu",
                "brn",
                "gry",
                "grn",
                "hzl",
                "oth"
            };
        }

        public bool Validate(Passport p)
        {
            if(!_validColors.Contains(p.EyeColor))
            {
                return false;
            }

            return ReturnTrueOrCallNext(p);
        }
    }
}
