using System;
using LabyrinthExplorer;

namespace Utilities
{
    public class Print{ public Print(string line) => Console.Write(line);}

    
    public class Utils { 
        public static string Capitalize(string input)
        {
            // Check for empty string.
            string s = string.IsNullOrEmpty(input) ? 
                string.Empty : 
                char.ToUpper(input[0]) + input.Substring(1);
            
            // Return char and concat substring.
            return s;
        }

        protected static void Print(string line) => Console.Write(line);
    }
}
