// Copyright Information
// ==================================
// SoftwareTesting - DALSample - CustomException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Exceptions;

public class CustomException : Exception
{
    public CustomException()
    {
    }

    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
