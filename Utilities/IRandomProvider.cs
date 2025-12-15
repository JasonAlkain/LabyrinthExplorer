using System;

namespace LabyrinthExplorer.Utilities
{
    public interface IRandomProvider
    {
        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }

    public class RandomProvider : IRandomProvider
    {
        private readonly Random _random;

        public RandomProvider(int? seed = null)
        {
            _random = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        public RandomProvider(Random random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public Random Instance => _random;
    }
}
