using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day04.Rules
{
    public class IsHeightValid : PassportRule, IPassportRule
    {
        public IsHeightValid(IPassportRule rule) : base(rule)
        {
        }

        public bool Validate(Passport p)
        {
            if (!string.IsNullOrEmpty(p.Height) && IsHeightValueValid(p))
            {
                return ReturnTrueOrCallNext(p);
            }

            return false;
        }

        private bool IsHeightValueValid(Passport p)
        {
            if (p.Height.Contains("cm"))
            {
                var height = int.Parse(p.Height.Replace("cm", string.Empty));
                return height >= 150 && height <= 193;
            }
            else if (p.Height.Contains("in"))
            {
                var height = int.Parse(p.Height.Replace("in", string.Empty));
                return height >= 59 && height <= 76;
            }

            return false;
        }
    }
}
