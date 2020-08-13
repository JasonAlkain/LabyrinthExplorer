using System;

namespace Utilities
{
    
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

        public static void Print(string line) => Console.Write(line);

        public static int GetEnumCount<T>()
        {
            var count = Enum.GetNames(typeof(T)).Length;
            return count;
        }
    }
}
