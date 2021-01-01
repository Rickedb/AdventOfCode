namespace AdventOfCode2020.Day4.Rules
{
    public class IsPassportIdValid : PassportRule, IPassportRule
    {
        public IsPassportIdValid(IPassportRule rule) : base(rule)
        {
        }

        public bool Validate(Passport p)
        {
            if(p.PassportId.Length == 9 && long.TryParse(p.PassportId, out long _))
            {
                return ReturnTrueOrCallNext(p);
            }

            return false;
        }
    }
}
