namespace EstateMaster.Server.Adaptor.Helpers;
using System;
using System.Globalization;

// custom exception class for throwing application specific exceptions (e.g. for validation) 
// that can be caught and handled within the application
public class DirectException : Exception
{
    public string message { get; set; }
    public DirectException() : base() { }

    public DirectException(string message) : base(message) { }

    public DirectException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}