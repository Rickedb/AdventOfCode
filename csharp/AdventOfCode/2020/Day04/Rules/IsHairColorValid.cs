﻿using System.Text.RegularExpressions;

namespace AdventOfCode.Day04.Rules
{
    public class IsHairColorValid : PassportRule, IPassportRule
    {
        public IsHairColorValid(IPassportRule rule) : base(rule)
        {
        }

        public bool Validate(Passport p)
        {
            if (!Regex.IsMatch(p.HairColor, "#[\\dabcdef]{6}"))
            {
                return false;
            }

            return ReturnTrueOrCallNext(p);
        }
    }
}
