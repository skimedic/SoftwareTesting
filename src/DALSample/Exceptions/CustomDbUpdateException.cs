// Copyright Information
// ==================================
// SoftwareTesting - DALSample - CustomDbUpdateException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Exceptions;

public class CustomDbUpdateException : CustomException
{
    public CustomDbUpdateException()
    {
    }

    public CustomDbUpdateException(string message) : base(message)
    {
    }

    public CustomDbUpdateException(string message, DbUpdateException innerException)
        : base(message, innerException)
    {
    }
}
