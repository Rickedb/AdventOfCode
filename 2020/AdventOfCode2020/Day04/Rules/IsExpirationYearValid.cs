namespace AdventOfCode2020.Day04.Rules
{
    public class IsExpirationYearValid : PassportRule, IPassportRule
    {
        public IsExpirationYearValid(IPassportRule rule) : base(rule)
        {
        }

        public bool Validate(Passport p)
        {
            if (!p.ExpirationYear.HasValue || p.ExpirationYear < 2020 || p.ExpirationYear > 2030)
            {
                return false;
            }

            return ReturnTrueOrCallNext(p);
        }
    }
}
