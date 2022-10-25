// Copyright Information
// ==================================
// SoftwareTesting - DALSample - CustomConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Exceptions;

public class CustomConcurrencyException : CustomException
{
    public CustomConcurrencyException()
    {
    }

    public CustomConcurrencyException(string message) : base(message)
    {
    }

    public CustomConcurrencyException(string message, DbUpdateConcurrencyException innerException)
        : base(message, innerException)
    {
    }
}
