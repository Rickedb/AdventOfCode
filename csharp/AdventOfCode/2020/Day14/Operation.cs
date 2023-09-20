using System;

namespace AdventOfCode.Day14
{
    public class Operation
    {
        public long MemoryAddress { get; }
        public byte[] ByteValue { get; }
        public ulong Value { get => BitConverter.ToUInt64(ByteValue); }

        public Operation(long memoryAddress, ulong value)
        {
            MemoryAddress = memoryAddress;
            ByteValue = BitConverter.GetBytes(value);
        }
    }
}
