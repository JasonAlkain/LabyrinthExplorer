using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthExplorer.Utilities
{
    class GameConsole
    {
        /// <summary>
        /// Writes text to the console without a line break
        /// </summary>
        public static void Printf(string text) => Console.Write(text);

        /// <summary>
        /// Writes text to the console with a line break
        /// </summary>
        public static void PrintLine(string text) => Console.WriteLine(text);

        /// <summary>
        /// Pauses execution for a specified duration
        /// </summary>
        public static void Pause(int milliseconds) => Thread.Sleep(milliseconds);

        /// <summary>
        /// Waits for any key press
        /// </summary>
        public static void WaitForKey() => Console.ReadKey(true);
    }
}
