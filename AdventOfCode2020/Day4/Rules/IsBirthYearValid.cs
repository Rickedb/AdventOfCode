namespace AdventOfCode2020.Day4.Rules
{
    public class IsBirthYearValid : PassportRule, IPassportRule
    {
        public IsBirthYearValid(IPassportRule rule) : base(rule)
        {
        }

        public bool Validate(Passport p)
        {
            if (!p.BirthYear.HasValue || p.BirthYear < 1920 || p.BirthYear > 2002)
            {
                return false;
            }

            return ReturnTrueOrCallNext(p);
        }
    }
}
