namespace AdventOfCode2020.Day04.Rules
{
    public class IsPassportInformationFilled : IPassportRule
    {
        public bool Validate(Passport p)
        {
            var props = typeof(Passport).GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetValue(p) == null)
                {
                    if (prop.Name != nameof(Passport.CountryId))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
