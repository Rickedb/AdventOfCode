using System.Collections.Generic;

namespace AdventOfCode.Day14
{
    public class MaskedOperation
    {
        public string Mask { get; set; }
        public IList<Operation> Operations { get; set; }

        public MaskedOperation(string mask, IList<Operation> operations)
        {
            Mask = mask;
            Operations = operations;
        }
    }
}
