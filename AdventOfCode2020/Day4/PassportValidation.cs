using AdventOfCode2020.Day4.Rules;

namespace AdventOfCode2020.Day4
{
    public class PassportValidation
    {
        private readonly IsPassportInformationFilled _isPassportInformationFilled;
        private readonly IPassportRule _rules;

        public PassportValidation()
        {
            _isPassportInformationFilled = new IsPassportInformationFilled();
            _rules = new IsBirthYearValid(
                        new IsExpirationYearValid(
                            new IsEyeColorValid(
                                new IsHairColorValid(
                                    new IsHeightValid(
                                        new IsIssueYearValid(
                                            new IsPassportIdValid(null)))))));
        }

        public bool Validate(Passport p)
        {
            return _isPassportInformationFilled.Validate(p) && _rules.Validate(p);
        }
    }
}
