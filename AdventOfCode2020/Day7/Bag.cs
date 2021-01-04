using System.Collections.Generic;

namespace AdventOfCode2020.Day7
{
    public class Bag
    {
        public string Color { get; set; }

        public Dictionary<Bag, int> CanCarryBags { get; set; }
    }
}
