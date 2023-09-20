using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day13
{
    public class Day13Resolver : IAdventResolver
    {
        private readonly int _timestamp;
        private readonly IEnumerable<int> _busIds;
        private readonly string[] _rawIds;

        public Day13Resolver(string[] busSchedule)
        {
            _rawIds = busSchedule[1].Split(',');
            _timestamp = int.Parse(busSchedule[0]);
            _busIds = busSchedule[1].Split(',').Where(x => x != "x").Select(int.Parse);
        }

        public object ResolvePartOne()
        {
            var schedules = new Dictionary<int, long>();
            foreach (var id in _busIds)
            {
                var maxScheduleTimeStamp = id;
                while (maxScheduleTimeStamp < _timestamp)
                {
                    maxScheduleTimeStamp += id;
                }
                schedules.Add(id, maxScheduleTimeStamp);
            }

            var bestId = schedules.First(x => x.Value - _timestamp == schedules.Min(y => y.Value - _timestamp));
            var total = bestId.Key * (bestId.Value - _timestamp);
            return total;
        }

        public object ResolvePartTwo()
        {
            var timestamps = new List<long>();
            var busIds = new Dictionary<long, long>();
            for (int i = 0; i < _rawIds.Length; i++)
            {
                var busId = _rawIds[i];
                if (busId != "x")
                {
                    timestamps.Add(i);
                    busIds.Add(i, long.Parse(busId));
                }
            }


            //Using LCM
            long timestamp = busIds.ElementAt(0).Value;
            long leastCommonMultiple = busIds.ElementAt(0).Value;
            for (int i = 0; i < busIds.Count; i++)
            {
                var busId = busIds.ElementAt(i);
                while ((timestamp + busId.Key) % busId.Value != 0)
                {
                    timestamp += leastCommonMultiple;
                }

                for (int j = 1; j <= i; j++)
                {
                    var id = busIds.ElementAt(j).Value;
                    var currentMultiple = leastCommonMultiple;
                    while (leastCommonMultiple % id != 0)
                    {
                        leastCommonMultiple += currentMultiple;
                    }
                }
            }

            // Slow way:
            //timestamp = 0;
            //var busIds = _busIds.ToArray();
            //bool notMatching = true;
            //while (notMatching)
            //{
            //    timestamp++;
            //    notMatching = false;
            //    for (int j = 0; j < busIds.Length; j++)
            //    {
            //        if ((timestamps[j] + timestamp) % busIds[j] != 0)
            //        {
            //            notMatching = true;

            //            break;
            //        }
            //    }
            //}

            return timestamp;
        }
    }
}
