// Copyright Information
// ==================================
// SoftwareTesting - DALSample - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Exceptions;

public class CustomRetryLimitExceededException : CustomException
{
    public CustomRetryLimitExceededException()
    {
    }

    public CustomRetryLimitExceededException(string message) : base(message)
    {
    }

    public CustomRetryLimitExceededException(
	string message, RetryLimitExceededException innerException)        : base(message, innerException)
    {
    }
}
