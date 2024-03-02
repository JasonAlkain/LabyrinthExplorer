using System;
using System.Globalization;

namespace Utilities
{
    public static class Utils
    {
        public static string Capitalize(string input)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            // Check for empty string.
            string result = string.IsNullOrEmpty(input) ?
                string.Empty :
                textInfo.ToTitleCase(input);
            // Return char and concat substring.
            return result;
        }

        public static void Print(string line) => Console.Write(line);

        public static int GetEnumCount<T>()
        {
            int count = Enum.GetNames(typeof(T)).Length;
            return count;
        }
    }

    public class Print
    {
        //public Print(string _string)
        //{
        //    Console.WriteLine(_string);
        //}


        public Print(string _string) => Console.WriteLine(_string);
    }
}
