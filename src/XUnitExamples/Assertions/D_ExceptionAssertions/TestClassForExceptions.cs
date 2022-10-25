// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - TestClassForExceptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.D_ExceptionAssertions;

public class TestClassForExceptions
{
    public void GoodAction() { }

    public void ThrowNestedExceptions() 
        => throw new InvalidOperationException("Bad op", new NotImplementedException("Must build"));

    public void ThrowBadParamExceptionAction(string paramName)
    {
        if (string.IsNullOrEmpty(paramName))
        {
            throw new ArgumentNullException(nameof(paramName));
        }
        throw new ArgumentException("ParamName");
    }

    public int ThrowBadParamExceptionFunc(int paramName) 
        => throw new ArgumentException("ParamName");

    public async Task ThrowBadParamExceptionActionAsync(string paramName)
    {
        if (string.IsNullOrEmpty(paramName))
        {
            throw new ArgumentNullException(nameof(paramName));
        }
        throw new ArgumentException("ParamName");
    }

    public async Task<int> ThrowBadParamExceptionFuncAsync(int paramName) 
        => throw new ArgumentException("ParamName");

    public IEnumerable<int> Power(int number, int exponent)
    {
        int result = 1;

        for (int i = 0; i < exponent; i++)
        {
            if (i == 2)
            {
                throw new Exception("Boo");
            }
            result = result * number;
            yield return result;
        }
    }
}