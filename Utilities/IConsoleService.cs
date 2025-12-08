using System;

namespace LabyrinthExplorer.Utilities
{
    public interface IConsoleService
    {
        void Write(string text);
        void WriteLine(string text);
        string ReadLine();
        void Clear();
        void Sleep(int milliseconds);
        ConsoleKeyInfo ReadKey(bool intercept);
    }

    public class SystemConsoleService : IConsoleService
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine(string text) => Console.WriteLine(text);

        public string ReadLine() => Console.ReadLine() ?? string.Empty;

        public void Clear() => Console.Clear();

        public void Sleep(int milliseconds) => System.Threading.Thread.Sleep(milliseconds);

        public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
    }
}
