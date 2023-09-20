using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace AdventOfCode.Day14
{
    public class Day14Resolver : IAdventResolver
    {
        private readonly IEnumerable<MaskedOperation> _maskedOperations;

        public Day14Resolver(IEnumerable<string> initializationProgram)
        {
            _maskedOperations = Parse(initializationProgram);
        }

        public object ResolvePartOne()
        {
            var memory = new long[_maskedOperations.SelectMany(x => x.Operations).Max(x => x.MemoryAddress)];
            foreach (var maskedOperation in _maskedOperations)
            {
                var mask = new Dictionary<int, int>();
                for (int i = 0; i < maskedOperation.Mask.Length; i++)
                {
                    var value = maskedOperation.Mask[i];
                    if (value != 'X')
                    {
                        mask.Add(maskedOperation.Mask.Length - i - 1, Convert.ToInt32(value.ToString()));
                    }
                }

                foreach (var operation in maskedOperation.Operations)
                {
                    byte[] raw = new byte[operation.ByteValue.Length];
                    Array.Copy(operation.ByteValue, raw, operation.ByteValue.Length);
                    foreach (var m in mask)
                    {
                        byte bit = (byte)(1 << m.Key % 8);
                        var isSet = Convert.ToBoolean(m.Value);
                        var byteIndex = m.Key / 8;
                        if (isSet)
                            raw[byteIndex] |= bit;
                        else
                            raw[byteIndex] &= BitConverter.GetBytes(~bit)[0];
                    }
                    var value = BitConverter.ToInt64(raw);
                    memory[operation.MemoryAddress - 1] = value;
                }
            }

            var total = memory.Sum();
            return total;
        }

        public object ResolvePartTwo()
        {
            var memory = new Dictionary<long, long>();
            foreach (var maskedOperation in _maskedOperations)
            {
                foreach (var operation in maskedOperation.Operations)
                {
                    byte[] raw = BitConverter.GetBytes(operation.MemoryAddress);
                    var floatingIndexes = new List<int>();
                    for (int i = 0; i < maskedOperation.Mask.Length; i++)
                    {
                        var bitIndex = maskedOperation.Mask.Length - i - 1;

                        byte bit = (byte)(1 << bitIndex % 8);
                        var byteIndex = bitIndex / 8;
                        switch (maskedOperation.Mask[i])
                        {
                            case '1':
                                raw[byteIndex] |= bit;
                                break;
                            case 'X':
                                floatingIndexes.Add(bitIndex);
                                break;
                        }
                    }

                    var addresses = GetMemoryAddresses(raw, floatingIndexes);
                    foreach (var address in addresses)
                    {
                        if (!memory.ContainsKey(address))
                        {
                            memory.Add(address, 0);
                        }

                        memory[address] = (long)operation.Value;
                    }
                }
            }

            var total = memory.Select(x => x.Value).Sum();
            return total;
        }
        public IEnumerable<IEnumerable<T>> Combine<T>(IEnumerable<T> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };

            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequences
                select accseq.Concat(new[] { item }));
        }

        private IEnumerable<long> GetMemoryAddresses(byte[] raw, List<int> floatingIndexes)
        {
            var qwe = "X101011X011X10101011000001X00XX0X000";

            for (int i = 0; i < qwe.Count(x=> x == 'X'); i++)
            {
                var copy = qwe;
                for(int force= 0; force < i; force++)
                {
                    copy = 
                }

                var str = qwe.Substring(i, 1) + "1" + qwe.Substring(i + 2);
                for (int j = i + 1; j <= 5; j++)
                {
                    var newStr = qwe.Substring(j, 1) + "1" + qwe.Substring(j + 1);

                }
            }



            var q = Combine(floatingIndexes);

            var values = new HashSet<long>();
            for (int i = 0; i < floatingIndexes.Count; i++)
            {
                var current = floatingIndexes[i];
                var currentBit = (byte)(1 << current % 8);
                var currentByteIndex = current / 8;

                var list = new List<int>() { current };
                var copy = new byte[raw.Length];
                Array.Copy(raw, copy, raw.Length);
                for (int j = 0; j < floatingIndexes.Count; j++)
                {
                    var secondary = floatingIndexes[j];
                    if (current == secondary) continue;

                    var secondaryBit = (byte)(1 << secondary % 8);
                    var secondaryByteIndex = secondary / 8;

                    copy[currentByteIndex] |= currentBit;
                    copy[secondaryByteIndex] |= secondaryBit;
                    values.Add(BitConverter.ToInt64(copy));
                    copy[secondaryByteIndex] &= BitConverter.GetBytes(~secondaryBit)[0];
                    values.Add(BitConverter.ToInt64(copy));


                    copy[currentByteIndex] &= BitConverter.GetBytes(~currentBit)[0];
                    copy[secondaryByteIndex] |= secondaryBit;
                    values.Add(BitConverter.ToInt64(copy));
                    copy[secondaryByteIndex] &= BitConverter.GetBytes(~secondaryBit)[0];
                    values.Add(BitConverter.ToInt64(copy));
                }
            }
            return values;
        }

        private IEnumerable<MaskedOperation> Parse(IEnumerable<string> initializationProgram)
        {
            var list = initializationProgram.ToList();
            var maskedOperations = new List<MaskedOperation>();
            int i = 0;
            while (i < list.Count)
            {
                if (list[i].StartsWith("mask"))
                {
                    var mask = list[i].Split("=")[1].Trim();
                    var operations = new List<Operation>();
                    i++;
                    while (i < list.Count && list[i].StartsWith("mem"))
                    {
                        var operation = list[i].Split("=");
                        var memoryAddress = long.Parse(operation[0].Split("[")[1].Replace("]", string.Empty));
                        var value = ulong.Parse(operation[1]);
                        operations.Add(new Operation(memoryAddress, value));
                        i++;
                    }
                    maskedOperations.Add(new MaskedOperation(mask, operations));
                }
            }

            return maskedOperations;
        }
    }
}
