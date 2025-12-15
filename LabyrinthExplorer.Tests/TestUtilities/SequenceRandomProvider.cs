using System;
using System.Collections.Generic;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Tests.TestUtilities
{
    public class SequenceRandomProvider : IRandomProvider
    {
        private readonly Queue<int> _values;

        public SequenceRandomProvider(IEnumerable<int> values)
        {
            _values = new Queue<int>(values);
        }

        public int Next(int maxValue)
        {
            var next = _values.Count > 0 ? _values.Dequeue() : 0;
            return Math.Abs(next) % Math.Max(1, maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            var next = _values.Count > 0 ? _values.Dequeue() : minValue;
            var range = Math.Max(1, maxValue - minValue);
            return minValue + Math.Abs(next) % range;
        }
    }
}
