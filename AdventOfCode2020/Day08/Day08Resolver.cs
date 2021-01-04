using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day08
{
    public class Day08Resolver : IAdventResolver
    {
        private readonly string[] _bootCode;

        public Day08Resolver(string[] bootCode)
        {
            _bootCode = bootCode;
        }

        public object ResolvePartOne()
        {
            int instructionIndex = 0;
            int accumulator = 0;

            List<int> executedInstructionIndexes = new List<int>();
            while (instructionIndex < _bootCode.Length)
            {
                if (executedInstructionIndexes.Contains(instructionIndex))
                {
                    //StackOverflow
                    break;
                }

                executedInstructionIndexes.Add(instructionIndex);
                var instruction = _bootCode[instructionIndex].Split(' ');
                switch (instruction[0])
                {
                    case "acc":
                        accumulator += int.Parse(instruction[1]);
                        break;
                    case "jmp":
                        instructionIndex += int.Parse(instruction[1]);
                        continue;
                    case "nop":
                        //Does nothing
                        break;
                }

                instructionIndex++;
            }

            return accumulator;
        }

        public object ResolvePartTwo()
        {
            int instructionIndex = 0;
            var instructionToChangeIndex = 0;
            int accumulator = 0;

            var executedInstructionIndexes = new List<int>();
            var indexesTried = new List<int>();
            while (instructionIndex < _bootCode.Length)
            {
                var instruction = _bootCode[instructionIndex].Split(' ');
                if (executedInstructionIndexes.Contains(instructionIndex))
                {
                    SwapOperation(instructionToChangeIndex);
                    var revertLastIndex = indexesTried.LastOrDefault();
                    if(revertLastIndex != default)
                    {
                        SwapOperation(revertLastIndex);
                    }

                    indexesTried.Add(instructionToChangeIndex);
                    instructionIndex = instructionToChangeIndex = accumulator = 0;
                    executedInstructionIndexes.Clear();
                    continue;
                }

                executedInstructionIndexes.Add(instructionIndex);
                switch (instruction[0])
                {
                    case "acc":
                        accumulator += int.Parse(instruction[1]);
                        break;
                    case "jmp":
                        if(instructionToChangeIndex == 0 && !indexesTried.Contains(instructionIndex))
                        {
                            instructionToChangeIndex = instructionIndex;
                        }
                        instructionIndex += int.Parse(instruction[1]);
                        continue;
                    case "nop":
                        if (instructionToChangeIndex == 0 && !indexesTried.Contains(instructionIndex))
                        {
                            instructionToChangeIndex = instructionIndex;
                        }
                        break;
                }

                instructionIndex++;
            }

            return accumulator;
        }

        private void SwapOperation(int index)
        {
            var lastInstruction = _bootCode[index].Split(' ');
            if (lastInstruction[0] == "jmp")
            {
                _bootCode[index] = _bootCode[index].Replace("jmp", "nop");
            }
            else
            {
                _bootCode[index] = _bootCode[index].Replace("nop", "jmp");
            }
        }
    }
}
