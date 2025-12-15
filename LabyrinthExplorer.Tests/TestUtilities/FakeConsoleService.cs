using System;
using System.Collections.Generic;
using System.Text;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Tests.TestUtilities
{
    public class FakeConsoleService : IConsoleService
    {
        private readonly Queue<string> _inputs;

        public FakeConsoleService(IEnumerable<string> inputs)
        {
            _inputs = new Queue<string>(inputs);
        }

        public StringBuilder Output { get; } = new();

        public int ReadKeyCount { get; private set; }

        public int RemainingInputs => _inputs.Count;

        public void Write(string text) => Output.Append(text);

        public void WriteLine(string text) => Output.AppendLine(text);

        public string ReadLine()
        {
            if (_inputs.Count == 0)
            {
                throw new InvalidOperationException("No more scripted input available.");
            }

            return _inputs.Dequeue();
        }

        public void Clear() => Output.Clear();

        public void Sleep(int milliseconds)
        {
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            ReadKeyCount++;
            return new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
        }
    }
}
