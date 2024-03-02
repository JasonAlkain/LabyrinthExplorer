using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

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


    /// <summary>
    /// Generic class that implements the INotifyPropertyChanged interface to notify subscribers when a property changes.
    /// </summary>
    /// <typeparam name="T">The type of the property that can be observed for changes.</typeparam>
    public class Notifier<T> : INotifyPropertyChanged, IDisposable
    {
        private T _Prop;
        private bool _disposed = false; // Flag to track whether Dispose has been called

        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        /// <remarks>
        /// When the value is set, it checks if the new value is different from the current value.
        /// If so, it updates the property and raises the PropertyChanged event.
        /// </remarks>
        public T Prop
        {
            get { return _Prop; }
            set
            {
                if (!EqualityComparer<T>.Default.Equals(_Prop, value))
                {
                    _Prop = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        /// <param name="propertyName">Name of the property that has changed.
        /// This value is automatically obtained through the CallerMemberName attribute.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Releases all resources used by the Notifier.
        /// </summary>
        /// <remarks>
        /// Call <see cref="Dispose"/> when you are finished using the Notifier. The Dispose method
        /// leaves the Notifier in an unusable state. After calling Dispose, you must release all references
        /// to the Notifier so the garbage collector can reclaim the memory that the Notifier was occupying.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Notifier and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects)
                    PropertyChanged = null; // Unsubscribe from events to avoid memory leaks
                }

                // Free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Set large fields to null

                _disposed = true;
            }
        }

        // Override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Notifier()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
    }
}
