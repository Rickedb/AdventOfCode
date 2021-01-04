using AdventOfCode2020.Day04.Rules;
using System.Collections.Generic;

namespace AdventOfCode2020.Day04
{
    public class Day04Resolver : IAdventResolver
    {
        private readonly IEnumerable<Passport> _passports;

        public Day04Resolver(string file)
        {
            _passports = ParseFile(file);
        }

        public object ResolvePartOne()
        {
            var totalValidPassports = 0;

            var isFilled = new IsPassportInformationFilled();
            foreach(var passport in _passports)
            {
                if(isFilled.Validate(passport))
                {
                    totalValidPassports++;
                }
            }

            return totalValidPassports;
        }

        public object ResolvePartTwo()
        {
            var totalValidPassports = 0;

            var validation = new PassportValidation();
            foreach (var passport in _passports)
            {
                if (validation.Validate(passport))
                {
                    totalValidPassports++;
                }
            }

            return totalValidPassports;
        }

        private IEnumerable<Passport> ParseFile(string file)
        {
            var passports = file.Split("\r\n\r\n");
            foreach(var passport in passports)
            {
                var obj = new Passport();
                var lineByLineData = passport.Split("\r\n");
                foreach(var line in lineByLineData)
                {
                    var datas = line.Split(" ");
                    foreach(var data in datas)
                    {
                        var keyValue = data.Split(":");
                        switch(keyValue[0])
                        {
                            case "byr":
                                obj.BirthYear = int.Parse(keyValue[1]);
                                break;
                            case "iyr":
                                obj.IssueYear = int.Parse(keyValue[1]);
                                break;
                            case "eyr":
                                obj.ExpirationYear = int.Parse(keyValue[1]);
                                break;
                            case "hgt":
                                obj.Height = keyValue[1];
                                break;
                            case "hcl":
                                obj.HairColor = keyValue[1];
                                break;
                            case "ecl":
                                obj.EyeColor = keyValue[1];
                                break;
                            case "pid":
                                obj.PassportId = keyValue[1];
                                break;
                            case "cid":
                                obj.CountryId = int.Parse(keyValue[1]);
                                break;
                        }
                    }
                }

                yield return obj;
            }
        }
    }

    
}
