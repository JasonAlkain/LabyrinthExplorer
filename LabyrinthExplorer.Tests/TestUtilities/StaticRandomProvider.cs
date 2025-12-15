using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Tests.TestUtilities
{
    public class StaticRandomProvider : IRandomProvider
    {
        private readonly int _value;

        public StaticRandomProvider(int value = 0)
        {
            _value = value;
        }

        public int Next(int maxValue) => _value % maxValue;

        public int Next(int minValue, int maxValue) => minValue;
    }
}
