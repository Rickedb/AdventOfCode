using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Day10Resolver : IAdventResolver
    {
        private readonly IEnumerable<int> _adapters;
        private readonly int _lastItem;

        public Day10Resolver(IEnumerable<int> adapters)
        {
            _lastItem = adapters.Max() + 3;
            _adapters = adapters.Concat(new int[] { 0, _lastItem });
        }

        public object ResolvePartOne()
        {
            var oneJoltAdapters = 0;
            var threeJoltAdapters = 0;
            var orderedAdapters = _adapters.OrderBy(x => x).ToList();

            for (int i = 0; i < orderedAdapters.Count - 1; i++)
            {
                if (orderedAdapters[i + 1] == orderedAdapters[i] + 1)
                {
                    oneJoltAdapters++;
                }

                if (orderedAdapters[i + 1] == orderedAdapters[i] + 3)
                {
                    threeJoltAdapters++;
                }
            }

            var total = oneJoltAdapters * threeJoltAdapters;
            return total;
        }

        public object ResolvePartTwo()
        {
            var orderedAdapters = _adapters.OrderBy(x => x);
            var routes = new Dictionary<int, long> { { 0, 1 } };
            foreach(var jolt in orderedAdapters.Skip(1))
            {
                routes[jolt] = routes.GetValueOrDefault(jolt - 1) +
                               routes.GetValueOrDefault(jolt - 2) +
                               routes.GetValueOrDefault(jolt - 3);
            }

             var total = routes[orderedAdapters.Max()];
            return total;
        }
    }
}
