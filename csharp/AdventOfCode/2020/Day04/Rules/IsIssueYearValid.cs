namespace AdventOfCode.Day04.Rules
{
    public class IsIssueYearValid : PassportRule, IPassportRule
    {
        public IsIssueYearValid(IPassportRule rule) : base(rule)
        {
        }

        public bool Validate(Passport p)
        {
            if (!p.IssueYear.HasValue || p.IssueYear < 2010 || p.IssueYear > 2020)
            {
                return false;
            }

            return ReturnTrueOrCallNext(p);
        }
    }
}
