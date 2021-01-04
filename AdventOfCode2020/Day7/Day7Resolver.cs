using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day7
{
    public class Day7Resolver : IAdventResolver
    {
        private readonly IEnumerable<Bag> _bags;

        public Day7Resolver(IEnumerable<string> bagsInfo)
        {
            _bags = ParseBags(bagsInfo);
        }

        public object ResolvePartOne()
        {
            var bags = GetBagsThatContains("shiny gold");
            var total = bags.Count();
            return total;
        }

        public object ResolvePartTwo()
        {
            var total = CalculateTotalBagsInside("shiny gold"); //the shiny gold bag
            return total;
        }

        private IEnumerable<Bag> GetBagsThatContains(string color)
        {
            var bags = _bags.Where(x => x.CanCarryBags.Keys.Any(y => y.Color == color));
            var innerBags = bags.SelectMany(x => GetBagsThatContains(x.Color));
            return bags.Concat(innerBags).Distinct();
        }

        private int CalculateTotalBagsInside(string color)
        {
            var bag = _bags.First(x => x.Color == color);
            var totalInnerBags = bag.CanCarryBags.Values.Sum();
            return totalInnerBags + bag.CanCarryBags.Select(x => CalculateTotalBagsInside(x.Key.Color) * x.Value).Sum();
        }

        private IEnumerable<Bag> ParseBags(IEnumerable<string> bagsInfo)
        {
            var bags = new List<Bag>();
            foreach (var bagInfo in bagsInfo)
            {
                var splitted = bagInfo.Split("contain");
                bags.Add(new Bag()
                {
                    Color = splitted[0].Replace("bags", string.Empty).Trim(),
                    CanCarryBags = new Dictionary<Bag, int>()
                });
            }

            foreach (var bagInfo in bagsInfo)
            {
                var splitted = bagInfo.Split("contain");
                var bag = bags.First(x => x.Color == splitted[0].Replace("bags", string.Empty).Trim());

                var canCarryBags = splitted[1].Split(',');
                foreach (var canCarryBag in canCarryBags)
                {
                    var trimmed = canCarryBag.Trim();
                    if (!trimmed.Contains("no other bags"))
                    {
                        var quantity = int.Parse(trimmed.Substring(0, 1));
                        var bagColor = trimmed[1..].Replace("bags", string.Empty).Replace("bag", string.Empty).Replace(".", string.Empty).Trim();
                        bag.CanCarryBags.Add(bags.First(x => x.Color == bagColor), quantity);
                    }
                }
            }

            return bags;
        }
    }
}
