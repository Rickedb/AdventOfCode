using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public class Bag
    {
        public string Color { get; set; }

        public Dictionary<Bag, int> CanCarryBags { get; set; }
    }
}
