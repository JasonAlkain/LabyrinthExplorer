using System;
using System.Globalization;
using System.Numerics;

namespace Utilities
{
    public static class Utils
    {
        /// <summary>
        /// Returns a capitalized string from the input
        /// </summary>
        /// <param name="input">String to be capitalized</param>
        /// <returns>String in title case</returns>
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

        /// <summary>
        /// Helper function that prints the string to the console (Console.Write)
        /// </summary>
        /// <param name="_String">The string to print to the console</param>
        [Obsolete("Use the Print class from this namespace")]
        public static void Print(string _String) => Console.Write(_String);

        public static int GetEnumCount<T>()
        {
            int count = Enum.GetNames(typeof(T)).Length;
            return count;
        }
    }

    public class Print
    {
        /// <summary>
        /// Helper function that prints the string to the console (Console.Write)
        /// </summary>
        /// <param name="_string">The string to print to the console</param>
        public Print(string _string) => Console.Write(_string);
    }



}
