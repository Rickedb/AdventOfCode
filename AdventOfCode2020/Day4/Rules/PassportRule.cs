namespace AdventOfCode2020.Day4.Rules
{
    public abstract class PassportRule
    {
        private readonly IPassportRule _nextRule;

        public PassportRule(IPassportRule rule)
        {
            _nextRule = rule;
        }

        protected bool ReturnTrueOrCallNext(Passport p)
        {
            if(_nextRule != null)
            {
                return _nextRule.Validate(p);
            }

            return true;
        }
    }
}
