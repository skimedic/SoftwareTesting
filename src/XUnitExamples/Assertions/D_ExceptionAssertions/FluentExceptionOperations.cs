// Copyright Information
// ==================================
// SoftwareTesting - XUnitExamples - FluentExceptionOperations.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace XUnitExamples.Assertions.D_ExceptionAssertions;

public class FluentExceptionOperations
{
    [Fact]
    public void BasicSyntax()
    {
        var sut = new TestClassForExceptions();

        sut.Invoking(y => y.ThrowBadParamExceptionAction("Hello"))
            .Should().Throw<ArgumentException>()
            .WithMessage("ParamName");

        //AAA Syntax - 
        Action act = () => sut.ThrowBadParamExceptionAction("Hello");

        act.Should().ThrowExactly<ArgumentException>().WithMessage("paramName");

        act = () => sut.ThrowBadParamExceptionAction(string.Empty);

        act.Should().ThrowExactly<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'paramName')");

        act.Should().ThrowExactly<ArgumentNullException>()
            .Where(e => e.ParamName.Equals("paramName", StringComparison.OrdinalIgnoreCase));
        act.Should().ThrowExactly<ArgumentNullException>().WithParameterName("paramName");

        act.Should().Throw<Exception>().WithMessage("Value cannot be null. (Parameter 'paramName')");

        //Other exceptions are ok
        act.Should().NotThrow<NotImplementedException>();

        act = () => sut.GoodAction();
        act.Should().NotThrow();

        act = () => sut.ThrowNestedExceptions();
        //Check inner exception
        act.Should().Throw<InvalidOperationException>()
            .WithInnerException<NotImplementedException>()
            .WithMessage("Must build");


        //Wilcard specifier	Matches
        //* (asterisk)	Zero or more characters in that position.
        //? (question mark)	Exactly one character in that position.

        act = () => sut.ThrowBadParamExceptionAction(string.Empty);
        act
            .Should().Throw<ArgumentNullException>()
            .WithMessage("Valu? cannot*");

        //also works with Func
        var func = () => sut.ThrowBadParamExceptionFunc(0);

        func.Should().Throw<ArgumentException>();

        //Timing of actions/functions
        //Action act = () => service.IsReady().Should().BeTrue();
        //act.Should().NotThrowAfter(10.Seconds(), 100.Milliseconds());

        var func2 = () => sut.Power(1, 1);
        func2.Enumerating().Should().NotThrow<Exception>();

        func2 = () => sut.Power(1, 3);
        func2.Enumerating().Should().Throw<Exception>();

        sut.Enumerating(x => x.Power(1, 3)).Should().Throw<Exception>();

    }
    [Fact]
    public async Task AsyncFluentExceptionHandling()
    {
        var sut = new TestClassForExceptions();
        Func<Task> act = () => sut.ThrowBadParamExceptionActionAsync("hello");
        await act.Should().ThrowAsync<ArgumentException>();
        
        //await act.Should().NotThrowAsync();
    }
}