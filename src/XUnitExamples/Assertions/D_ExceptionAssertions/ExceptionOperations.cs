// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - ExceptionOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.D_ExceptionAssertions;

public class ExceptionOperations : BaseTestClass
{
    public ExceptionOperations(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact]
    public async Task ExceptionAssertsAsync()
    {
        var tc = new TestClassForExceptions();
        var T = typeof(ArgumentException); 
        //Checking an action - exact exception or a derived exception
        var ex1 = Assert.ThrowsAny<Exception>(() => throw new Exception());

        var sampleEx = new Exception();
        var ex1a = Assert.ThrowsAny<Exception>(() => throw sampleEx);

        Assert.Same(ex1a,sampleEx);
        ex1 = Assert.ThrowsAny<ArgumentException>(() => tc.ThrowBadParamExceptionAction("foo"));
        ex1 = await Assert.ThrowsAnyAsync<ArgumentException>(async () => await tc.ThrowBadParamExceptionActionAsync("foo"));
        //Checking an action - exact exception
        ex1 = Assert.Throws<ArgumentException>(() => tc.ThrowBadParamExceptionAction("foo"));
        ex1 = Assert.Throws(T,() => tc.ThrowBadParamExceptionAction("foo"));
        ex1 = await Assert.ThrowsAsync(T,async () => await tc.ThrowBadParamExceptionActionAsync("foo"));
        ex1 = await Assert.ThrowsAsync<ArgumentException>(async () => await tc.ThrowBadParamExceptionActionAsync("foo"));

        //Checking a function - exact exception or a derived exception
        var ex2 = Assert.ThrowsAny<Exception>(() => throw new Exception());
        ex2 = Assert.ThrowsAny<ArgumentException>(() => tc.ThrowBadParamExceptionFunc(1));
        ex2 = await Assert.ThrowsAnyAsync<ArgumentException>(async () => await tc.ThrowBadParamExceptionFuncAsync(2));
        //Checking an action - exact exception
        ex2 = Assert.Throws(T,() => tc.ThrowBadParamExceptionFunc(1));
        ex2 = await Assert.ThrowsAsync(T,async () => await tc.ThrowBadParamExceptionFuncAsync(1));

        try
        {
            var ex3 = Assert.ThrowsAny<NullReferenceException>(() => throw new Exception());
        }
        catch (ThrowsException ex)
        {
            TestOutputWriter.WriteLine("Successful checked for exception type");
        }
    }

    [Fact]
    public void ShouldRecordAnException()
    {
        //Better follows AAA syntax
        var ex = Record.Exception(() => ThrowAnError("Message"));
        //Doesn't check the exception type in the action
        if (!(ex is InvalidOperationException))
        {
            Assert.True(false);
        }
        Assert.Equal("Message", ex.Message);
    }

    private void ThrowAnError(string message)
    {
        throw new InvalidOperationException(message);
    }
}